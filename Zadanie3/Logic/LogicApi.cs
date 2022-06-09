using System.ComponentModel;
using System.Numerics;
using System.Text.Json;
using Data;

namespace Logic;

public sealed class LogicApi : LogicAbstractApi
{
    private readonly DataAbstractApi _dataAbstractApi;
    private readonly object _lockLogger = new();
    private readonly object _lockBalls = new();
    public LogicApi(DataAbstractApi dataAbstractApi)
    {
        _dataAbstractApi = dataAbstractApi;
    }
    public override List<BallLogic> GetBalls() => BallsLogics;
    public override int Canvas_Height => _dataAbstractApi.Height;
    public override int Canvas_Width => _dataAbstractApi.Width;
    public override void GenerateBalls(int ballsNumber)
    {
        BallsLogics = new List<BallLogic>();
        _dataAbstractApi.CreateBalls(ballsNumber);
        foreach (var ball in _dataAbstractApi.GetBalls())
        {
            BallsLogics.Add(new BallLogic(ball));
            ball.PropertyChanged += DetectCollision;
        }
    }
    private void DetectCollision(object sender, PropertyChangedEventArgs e)
    {
        var b = (Data.Data)sender;
        if (e.PropertyName != "Vector") return;
        BallCollision(b);
    }

    private void BallCollision(Data.Data data)
    {
        var opt = new JsonSerializerOptions {WriteIndented = true};
        foreach (var ball in BallsLogics.Where(ball => ball.Data != data))
        {
            // Lock on balls data
            lock (_lockBalls)
            {
                float x1 = data.X + data.Radius / 2 + data.PredkoscX;
                float y1 = data.Y + data.Radius / 2 + data.PredkoscY;
                float x2 = ball.Data.X + ball.Data.Radius / 2 + ball.Data.PredkoscX;
                float y2 = ball.Data.Y + ball.Data.Radius / 2 + ball.Data.PredkoscY;
                
                var distance = Vector2.Distance(data.Vector, ball.Data.Vector);

                if (!(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) <= (data.Radius / 2 + ball.Data.Radius / 2))) continue;
                if (!(Vector2.Distance(data.Vector, ball.Data.Vector) >
                      Vector2.Distance(data.Vector + data.Velocity,
                          ball.Data.Vector + ball.Data.Velocity))) continue;
                
                var newV1 = (data.Velocity * (data.Weight - ball.Data.Weight) + ball.Data.Velocity * 2 * ball.Data.Weight) / (data.Weight + ball.Data.Weight);
                var newV2 = (ball.Data.Velocity * (ball.Data.Weight - data.Weight) + data.Velocity * 2 * data.Weight) / (data.Weight + ball.Data.Weight);

                var logStr = "[ \"Time\": \"" + DateTime.Now + "\",\n  \"Collision\": "
                             + "\n\"Ball 1\": " + JsonSerializer.Serialize(ball.Data, opt) +
                             " \"New Velocity_X\": " + JsonSerializer.Serialize(newV1.X, opt)
                             + "\n  \"New Velocity_Y\": " + JsonSerializer.Serialize(newV1.Y, opt)
                             + "\n\"Ball 2\": " + JsonSerializer.Serialize(data, opt) +
                             " \"New Velocity_X\": " + JsonSerializer.Serialize(newV2.X, opt)
                             + "\n  \"New Velocity_Y\": " + JsonSerializer.Serialize(newV2.Y, opt) + " ]\n";
                data.Velocity = newV1;
                ball.Data.Velocity = newV2;

                lock (_lockLogger)
                {
                    File.AppendAllText("../../../../../log.json", logStr);
                }

                JsonSerializer.Serialize(data);
            }

        }

        // WallCollision
        float diameter = data.Radius;

        float right = 650 - diameter;

        float down = 430 - diameter;


        if (data.X <= 0)
        {
            data.X = 0;
            data.PredkoscX = -data.PredkoscX;
        }

        else if (data.X >= right)
        {
            data.X = right;
            data.PredkoscX = -data.PredkoscX;
        }
        if (data.Y <= 0)
        {
            data.Y = 0;
            data.PredkoscY = -data.PredkoscY;
        }

        else if (data.Y >= down)
        {
            data.Y = down;
            data.PredkoscY = -data.PredkoscY;
        }
    }
}