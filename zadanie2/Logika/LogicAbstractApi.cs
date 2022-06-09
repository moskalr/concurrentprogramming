using Data;
using System.Collections.Generic;

namespace Logic {

    public abstract class LogicAbstractApi
    {
        protected List<BallLogic> BallsLogics = default;

        public abstract void GenerateBalls(int ballsNumber);
        public abstract List<BallLogic> GetBalls();
        public abstract int CanvasHeight { get; }
        public abstract int CanvasWidth { get; }

        public static LogicAbstractApi CreateApi(DataAbstractApi dataAbstractApi = default)
        {
            return new LogicApi(dataAbstractApi);
        }
    }
}