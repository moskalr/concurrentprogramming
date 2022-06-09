using System.Collections.ObjectModel;
using System.Numerics;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Data
{
    public class BallOperations
    {
        private CancellationTokenSource _tokenSource;
        private CancellationToken token;
        private readonly List<Task> _tasks = new List<Task>();
        private readonly object _lock = new object();
        public string JsonFilename { get; set; } = "../../../../../log.json";
        Random rand = new Random();
        public ObservableCollection<BallData> Balls { get; } = new ObservableCollection<BallData>();

        public static int BoardHeight => 430;
        public static int BoardWidth => 650;
        private static int Radius => 30;

        public void CreateBalls(int number)
        {
            float x;
            float y;
            float xSpeed;
            float ySpeed;
            if (number > 0)
            {
                _tokenSource = new CancellationTokenSource();
                token = _tokenSource.Token;
                for (int i = 0; i < number; i++)
                {
                    x = rand.Next(10, BoardWidth - 10);
                    y = rand.Next(10, BoardHeight - 10);
                    xSpeed = (float)(0.1 + rand.NextDouble());
                    ySpeed = (float)(0.1 + rand.NextDouble());
                    var velocity = new Vector2(xSpeed, ySpeed);
                    Balls.Add(new BallData(x, y, Radius, 50, velocity));
                }
            }
            MoveBalls();
        }

        /**
         * ================
         * CRITICAL SECTION
         * ================
         */
        private void MoveBalls()
        {
            // Update balls positions
            foreach (var ball in Balls)
            {
                Task task = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(5);
                        ball.Update();
                        try { token.ThrowIfCancellationRequested(); }
                        catch (OperationCanceledException) { break; }
                    }
                });
                _tasks.Add(task);
            }

            // Write diagnostic data
            _tasks.Add(Task.Run(async () =>
            {
                lock (_lock)
                {
                    File.WriteAllText(JsonFilename, string.Empty);
                }

                while (true)
                {
                    var opt = new JsonSerializerOptions { WriteIndented = true };
                    var ballsSerialized = JsonSerializer.Serialize(Balls, opt);
                    var jsonString = "[ \"DateTime\": \"" + DateTime.Now + "\",\n  \"Balls\": " + ballsSerialized + " ]\n";
                    lock (_lock)
                    {
                        File.AppendAllText(JsonFilename, jsonString);
                    }
                    try { token.ThrowIfCancellationRequested(); }
                    catch (OperationCanceledException) { break; }
                    await Task.Delay(1000);
                }
            }));
        }
    }
}