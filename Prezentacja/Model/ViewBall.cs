using Dane;
using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prezentacja.Model
{
    public class ViewBall : IViewBall
    {
        private double _x;
        private double _y;
        private double _diameter;
        private ILogicBall _logicBall;

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
        public double diameter { get => _diameter; set => _diameter = value; }

        public ViewBall(ILogicBall logicBall)
        {
            _x = logicBall.X;
            _y = logicBall.Y;
            _diameter = logicBall.Diameter;
            _logicBall = logicBall;
            logicBall.PropertyChanged += LogicBall_PropertyChanged;
        }

        private void LogicBall_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null) { 
                IBall ball = (IBall)sender;
                X = ball.X;
                Y = ball.Y;
            }   
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void Dispose()
        {
            _logicBall.Dispose();
        }
    }
}
