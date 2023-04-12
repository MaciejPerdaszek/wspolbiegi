using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prezentacja.Model
{

    public interface IScreenBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; set; }
        double Y { get; set; }

        double diameter { get; set; }
    }
    public abstract class ModelAbstractAPI : IDisposable
    {

        public static ModelAbstractAPI CreateApi()
        {
            return new Model();
        }

        public abstract void CreateBalls(int amount);
        public abstract void CreateTable(int width, int height);

        public abstract List<ScreenBall> GetScreenBalls();

        public abstract void Dispose();

    }
}
