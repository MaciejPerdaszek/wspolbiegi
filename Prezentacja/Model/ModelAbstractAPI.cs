using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prezentacja.Model
{

    public interface IViewBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; set; }
        double Y { get; set; }

        double Diameter { get; set; }
    }
    public abstract class ModelAbstractAPI : IDisposable
    {
        public List<IViewBall> viewBallsList = new();
        public static ModelAbstractAPI CreateApi()
        {
            return new Model();
        }

        public abstract void CreateBalls(int amount, int radius);

        public abstract void CreateTable(int width, int height);

        public abstract List<IViewBall> GetViewBalls();

        public abstract void Dispose();

    }
}
