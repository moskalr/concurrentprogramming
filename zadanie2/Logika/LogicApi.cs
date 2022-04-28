using System.Collections;
namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateBallAPI() => new Moving_the_Balls();
        public abstract IList Create(int number);
        public abstract void Start();
    }
}
