using System.ComponentModel;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Data;

public sealed class Data : INotifyPropertyChanged
{
    private Vector2 _predkosc;
    
    private Vector2 _vector;
    

    public Data(float pozycja_X, float pozycja_Y, int radius, float weight, Vector2 predkosc)
    {
        _vector.X = pozycja_X;
        _vector.Y = pozycja_Y;
        Radius = radius;
        Weight = weight;
        _predkosc = predkosc;
    }
    
    public void Update()
    {
        _vector += _predkosc;
        OnPropertyChanged(nameof(Vector));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    [JsonIgnore]
    public Vector2 Vector => _vector;

    [JsonIgnore]
    
    public float PredkoscX
    {
        get => _predkosc.X;
        set
        {
            value = value switch
            {
                > 4 => 4,
                < -4 => -4,
                _ => value
            };
            _predkosc.X = value;
        }
    }

    public float PredkoscY
    {
        get => _predkosc.Y;
        set
        {
            value = value switch
            {
                > 4 => 4,
                < -4 => -4,
                _ => value
            };
            _predkosc.Y = value;
        }
    }
    public Vector2 Velocity
    {
        get => _predkosc;
        set => _predkosc = value;
    }

    public float X
    {
        get => _vector.X;
        set
        {
            _vector.X = value;
            OnPropertyChanged(nameof(X)); 
        }
    }

    public float Y
    {
        get => _vector.Y;
        set => _vector.Y = value;
    }

    public int Radius { get; }

    public float Weight { get; }

}