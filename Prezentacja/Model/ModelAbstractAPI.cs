using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prezentacja.Model
{

    public interface IViewBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; internal set; }
        double Y { get; internal set; }

        double Diameter { get; internal set; }

        int id { get; internal set; }
    }
    public abstract class ModelAbstractAPI : IDisposable
    {
        public List<IViewBall> viewBallsList = new();
        public static ModelAbstractAPI CreateApi()
        {
            return new Model();
        }

        public abstract void CreateBalls(int amount, double radius, double mass);

        public abstract void CreateTable(int width, int height);

        public abstract int getBallsCount();

        public abstract List<IViewBall> GetViewBalls();

        public abstract void Dispose();

    }
}
