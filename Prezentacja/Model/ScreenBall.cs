using Dane;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prezentacja.Model
{
    public class ScreenBall : IScreenBall
    {
        private double _x;
        private double _y;
        private double _d;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
        public double diameter { get => _d; set => _d = value; }

        public ScreenBall(IBall ball, double diameter)
        {
            this.X = ball.X;
            this.Y = ball.Y;
            this.diameter = diameter;
            ball.PropertyChanged += Ball_PropertyChanged;
        }

        private void Ball_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null) { 
                IBall ball = (IBall)sender;
                this.X = ball.X;
                this.Y = ball.Y;
            }   
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Dispose()
        {
            this.Dispose();
        }
    }
}
