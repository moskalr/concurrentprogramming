using System.Collections.ObjectModel;
using System.Numerics;
using System.Text.Json;

namespace Data
{
    public class BallCreate 
    {
        private CancellationTokenSource? _tokenSource;
        private readonly List<Task> _tasks = new();
        private readonly object _lock = new();
        public static int BoardHeight => 430;
        public static int BoardWidth => 650;
        private static int Radius => 30;
        public string JsonFilename { get; set; } = "../../../../../log.json";
        
        Random rand = new Random();
        public ObservableCollection<Data> Balls { get; } = new();

        public void CreateBalls(int number)
        {
            float x;
            float y;
            float xSpeed;
            float ySpeed;
            if (number > 0)
            { 
                _tokenSource = new CancellationTokenSource();
                for (int i = 0; i < number; i++)
                {
                    x = rand.Next(10,  BoardWidth - 10);
                    y = rand.Next(10,  BoardHeight - 10);
                    xSpeed = (float)(0.1 + rand.NextDouble());
                    ySpeed = (float)(0.1 + rand.NextDouble());
                    var velocity = new Vector2(xSpeed, ySpeed);
                    Balls.Add(new Data(x, y, Radius, 50,velocity));
                }
            }
            Move();
        }
        
         // CRITICAL SECTION
         private void Move()
        {
            // BallCollision
            foreach (var ball in Balls)
            {
                _tasks.Add(Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(5);
                        ball.Update();
                        try { _tokenSource!.Token.ThrowIfCancellationRequested(); }
                        catch (OperationCanceledException) { break; }
                    }
                }, _tokenSource!.Token));
            }
            
            // WallCollision
            _tasks.Add(Task.Run(async () =>
            {
                lock (_lock)
                {
                    File.WriteAllText(JsonFilename, string.Empty);
                }

                while (true)
                {
                    var opt = new JsonSerializerOptions {WriteIndented = true};
                    var ballsSerialized =  JsonSerializer.Serialize(Balls, opt);
                    var jsonString = "[ \"DateTime\": \"" + DateTime.Now + "\",\n  \"Balls\": " + ballsSerialized + " ]\n";
                    lock (_lock)
                    {
                        File.AppendAllText(JsonFilename, jsonString);
                    }
                    try { _tokenSource!.Token.ThrowIfCancellationRequested(); }
                    catch (OperationCanceledException) { break; }
                    await Task.Delay(1000);
                }
            }));
        }
    }
}