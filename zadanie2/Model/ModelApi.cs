using System.Collections;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public abstract class ModelApi
    {
        public abstract ObservableCollection<Ball> Balls(int ball_number);
        public abstract void Start(IList balls);
        public static ModelApi CreateApi()
        {
            return new ModelAPI();
        }
    }
    internal class ModelAPI : ModelApi
    {
        private readonly Moving_the_Balls creator = new Moving_the_Balls();
        public override ObservableCollection<Ball> Balls(int ball_number) => creator.Create(ball_number);
        public override void Start(IList balls) => creator.Start();
    }
}
