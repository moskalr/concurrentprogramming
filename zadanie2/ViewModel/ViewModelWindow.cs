using System.Collections;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ViewModelWindow : ViewModel
    {
        private int ball_number;
        private IList balls;
        private readonly ModelApi modelapi;
        
        public ViewModelWindow() : this(ModelApi.CreateApi()) { }
        public ViewModelWindow(ModelApi modelapi)
        {
            this.modelapi = modelapi;
            Start = new RelayCommand(() => start());
        }
        public ICommand Start { get; set; }

        public void start()
        {
            Balls = this.modelapi.Balls(ball_number);
            this.modelapi.Start(Balls);
        }
        public int Ball_Number
        {
            get => ball_number;
            set
            {
                if (value.Equals(ball_number))
                    return;
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;
                ball_number = value;
                RaisePropertyChanged(nameof(ball_number));
            }
        }
        public IList Balls
        {
            get => this.balls;
            set
            {
                if (value.Equals(this.balls)) return;
                this.balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }
    }
}
