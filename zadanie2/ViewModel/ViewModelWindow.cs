using System.Collections;
using System.Windows.Input;
using ModelPresentation;

namespace PresentationViewModel
{
        public class ViewModelWindow : ViewModel
        {
            private int _ballNumber;
            private readonly Model _model;
            private IList _balls;

            public ViewModelWindow()
            {
                _model = Model.CreateApi();
                Start = new RelayCommand(StartAction);
            }

            private void StartAction(object obj)
            {
                Balls = _model.Balls(_ballNumber);
                _model.Start(Balls);
            }

            public int BallNumber
            {
                get => _ballNumber;
                set
                {
                    if (value.Equals(_ballNumber))
                        return;
                    if (value < 0)
                        value = 0;
                    if (value > 100)
                        value = 100;
                    _ballNumber = value;
                    OnPropertyChanged(nameof(BallNumber));
                }
            }

            public ICommand Start { get; set; }

            public IList Balls
            {
                get => _balls;
                set
                {
                    if (value.Equals(_balls))
                        return;
                    _balls = value;
                    OnPropertyChanged(nameof(Balls));
                }
            }
        }
    }
