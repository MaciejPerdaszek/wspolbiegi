﻿using Dane;
using System.Diagnostics;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _diameter;
        private double _mass;
        private IBall _dataBall;
        private LogicBallChangedEventHandler? _ballChangedEventHandler;

        public double X
        {
            get { return _dataBall.X; }
        }

        public double Y
        {
            get { return _dataBall.Y; }
        }

        public double Diameter { get => _diameter; set => _diameter = value; }

        public double speedX { get => _dataBall.speedX; set => _dataBall.speedX = value; }
        public double speedY { get => _dataBall.speedY; set => _dataBall.speedY = value; }
        public double Mass { get => _mass; set => _mass = value; }
        public int directionX { get => _dataBall.directionX; set => _dataBall.directionX = value; }
        public int directionY { get => _dataBall.directionY; set => _dataBall.directionY = value; }


        public LogicBall(IBall dataBall, double diameter, double mass)
        {
            _diameter = diameter;
            _mass = mass;
            _dataBall = dataBall;
            dataBall.DataBallChanged += DataBall_DataBallChanged;
        }

        private void DataBall_DataBallChanged(IBall sender)
        {
            OnBallChangedEvent();
        }

        private void OnBallChangedEvent()
        {
            _ballChangedEventHandler?.Invoke(this);
        }

        public event LogicBallChangedEventHandler LogicBallChanged
        {
            add
            {
                _ballChangedEventHandler += value;
            }
            remove
            {
                _ballChangedEventHandler -= value;
            }
        }

        public void Dispose()
        {
            _dataBall.Dispose();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public void Collide(LogicBall other)
        {
            double dx = other.X - X;
            double dy = other.Y - Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= 15)
            {
                lock (LogicModel.collisionLock)
                {
                    double nx = dx / distance;
                    double ny = dy / distance;

                    double dvx = other.speedX - speedX;
                    double dvy = other.speedY - speedY;

                    double prod = dvx * nx + dvy * ny;

                        double impulse = 2 * Mass * other.Mass * prod / ((Mass + other.Mass) * distance);

                        speedX += impulse * nx / Mass;
                        speedY += impulse * ny / Mass;
                        other.speedX += impulse * nx / other.Mass;
                        other.speedY += impulse * ny / other.Mass;

                        directionX = directionX * -1;
                        directionY = directionY * -1;
                        other.directionX = other.directionX * -1;
                        other.directionY = other.directionY * -1;
                    
                }
            }
        }
    }
}
