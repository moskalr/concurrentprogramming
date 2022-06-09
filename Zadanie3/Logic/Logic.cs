using System.ComponentModel;

namespace Logic;

public class BallLogic : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public BallLogic(Data.Data data)
    {
        Data = data;
        data.PropertyChanged += (_, _) => OnPropertyChanged("Vector");
    }

    public Data.Data Data { get; }

    public float X
    {
        get => Data.X;
        set
        {
            Data.X = value;
            OnPropertyChanged(nameof(X));
        }
    }
    public float Y
    {
        get => Data.Y;
        set
        {
            Data.Y = value;
            OnPropertyChanged(nameof(Y));
        }
    }
    public float Radius => Data.Radius;
    
}