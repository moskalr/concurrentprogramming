﻿using System;
using System.Collections;

namespace ModelPresentation
{
    public abstract class Model
    {
        public abstract IList Balls(int ballNumber);
        public static Model CreateApi()
        {
            return new ModelApi();
        }
        public abstract void Start(IList balls);
        public abstract double BoardWidth { get; }
        public abstract double BoardHeight { get; }
    }
}