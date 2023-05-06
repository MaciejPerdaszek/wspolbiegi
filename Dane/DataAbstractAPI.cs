﻿namespace Dane
{

    public delegate void DataBallChangedEventHandler(IBall sender);
    public interface IBall : IDisposable
    {

        double X { get; internal set; }
        double Y { get; internal set; }

        double speedX { get; set; }
        double speedY { get; set; }
        double Mass { get; set; }

        int directionX { get; set; }
        int directionY { get; set; }

        public event DataBallChangedEventHandler DataBallChanged
        {
            add
            {
                DataBallChanged += value;
            }
            remove
            {
                DataBallChanged -= value;
            }
        }

    }



    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateApi()
        {
            return new DataModel();   
        }

        public abstract IBall CreateBall(double x, double y);

    }
}
