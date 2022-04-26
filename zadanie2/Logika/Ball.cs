using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Ball(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get => x;
            set
            {
                if (value.Equals(x)) return;
                x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        public double Y
        {
            get => y;
            set
            {
                if (value.Equals(y)) return;
                y = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

    }
} 
