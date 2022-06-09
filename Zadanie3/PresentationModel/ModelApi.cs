﻿using System.Collections.ObjectModel;
using Logic;

namespace PresentationModel;

internal class ModelApi : ModelAbstractApi
{
    private readonly LogicAbstractApi _logicAbstractApi;
    private readonly ObservableCollection<BallModel> _ballsModel = new();
    public override int CanvasHeight => _logicAbstractApi.Canvas_Height;
    public override int CanvasWidth => _logicAbstractApi.Canvas_Width;
    public override int ActualBallsNumber => _ballsModel.Count;

    public ModelApi(LogicAbstractApi logicAbstractApi)
    {
        _logicAbstractApi = logicAbstractApi;
    }

    public override ObservableCollection<BallModel> GenerateHandler(int ballsNumber)
    {
        _logicAbstractApi.GenerateBalls(ballsNumber);
        _ballsModel.Clear();
        foreach (var ball in _logicAbstractApi.GetBalls())
        {
            _ballsModel.Add(new BallModel(ball));
        }
        return _ballsModel;
    }

    
}