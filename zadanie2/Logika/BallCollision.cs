using Data;
using System;

namespace Logic
{
    internal class BallService
    {
        private readonly DataAbstractApi _data;

        public BallService(DataAbstractApi data)
        {
            _data = data;
        }

        public void WallCollision(IBall ball)
        {

            double diameter = ball.R;

            double right = _data.BoardWidth - diameter;

            double down = _data.BoardHeight - diameter;


            if (ball.X <= 0)
            {
                ball.X = 0;
                ball.XSpeed = -ball.XSpeed;
            }

            else if (ball.X >= right)
            {
                ball.X = right;
                ball.XSpeed = -ball.XSpeed;
            }
            if (ball.Y <= 0)
            {
                ball.Y = 0;
                ball.YSpeed = -ball.YSpeed;
            }

            else if (ball.Y >= down)
            {
                ball.Y = down;
                ball.YSpeed = -ball.YSpeed;
            }
        }

        public void BallCollision(IBall ball)
        {
            for (int i = 0; i < _data.Count(); i++)
            {
                IBall secondBall = _data.GetBall(i);
                if (ball == secondBall)
                {
                    continue;
                }
                if (ball != null || secondBall != null)
                {
                    // sprawdzanie czy wystapi kolizja
                    double x1 = ball.X + ball.R / 2 + ball.XSpeed;
                    double y1 = ball.Y + ball.R / 2 + ball.YSpeed;
                    double x2 = secondBall.X + secondBall.R / 2 + secondBall.XSpeed;
                    double y2 = secondBall.Y + secondBall.R / 2 + secondBall.YSpeed;

                    if (Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) <= (ball.R / 2 + secondBall.R / 2))
                    {
                        double vektor_1_x =
                            (ball.Weight - secondBall.Weight) * ball.XSpeed / (ball.Weight + secondBall.Weight) +
                            (2 * secondBall.Weight) * secondBall.XSpeed / (ball.Weight + secondBall.Weight);
                        double vektor_1_y =
                            (ball.Weight - secondBall.Weight) * ball.YSpeed / (ball.Weight + secondBall.Weight) +
                            (2 * secondBall.Weight) * secondBall.YSpeed / (ball.Weight + secondBall.Weight);
                        double vektor_2_x = 2 * ball.Weight * ball.XSpeed / (ball.Weight + secondBall.Weight) +
                                            (secondBall.Weight - ball.Weight) * secondBall.XSpeed /
                                            (ball.Weight + secondBall.Weight);
                        double vektor_2_y = 2 * ball.Weight * ball.YSpeed / (ball.Weight + secondBall.Weight) +
                                            (secondBall.Weight - ball.Weight) * secondBall.YSpeed /
                                            (ball.Weight + secondBall.Weight);
                        ball.XSpeed = vektor_1_x;
                        ball.YSpeed = vektor_1_y;
                        secondBall.XSpeed = vektor_2_x;
                        secondBall.YSpeed = vektor_2_y;
                        return;
                    }
                    
                }
            }
        }
    }
}
