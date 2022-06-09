using System.Collections.ObjectModel;

namespace Data;

public class DataApi : DataAbstractApi
{
    private BallCreate _ballCreate = new();

    public override void CreateBalls(int number)
    {
        _ballCreate = new BallCreate();
        _ballCreate.CreateBalls(number);
    }
    public override ObservableCollection<Data> GetBalls() => _ballCreate.Balls;

    public override int Width => BallCreate.BoardWidth;
    public override int Height => BallCreate.BoardHeight;
}