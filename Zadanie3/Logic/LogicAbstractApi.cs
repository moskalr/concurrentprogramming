using Data;

namespace Logic;

public abstract class LogicAbstractApi
{
    protected List<BallLogic> BallsLogics = null!;

    public abstract void GenerateBalls(int ballsNumber);

    public abstract List<BallLogic> GetBalls();
    public abstract int Canvas_Height { get; }
    public abstract int Canvas_Width { get; }

    public static LogicAbstractApi CreateApi(DataAbstractApi dataAbstractApi = default!)
    {
        return new LogicApi(dataAbstractApi);
    }
}