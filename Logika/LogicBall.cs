using Dane;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _diameter;
        private IBall _dataBall;

        public double X
        {
            get { return _dataBall.X; }
            set { _dataBall.X = value; PropertyChangedEvent("X"); }
        }
        public double Y
        {
            get { return _dataBall.Y; }
            set { _dataBall.Y = value; PropertyChangedEvent("Y"); }
        }

        public double Diameter { get => _diameter; set => _diameter = value; }

        public LogicBall(IBall dataBall, double diameter)
        {
            _diameter = diameter;
            _dataBall = dataBall;
            dataBall.PropertyChanged += DataBall_PropertyChanged;
        }

        private void DataBall_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X")
            {
                PropertyChangedEvent("X");
            }
            else if (e.PropertyName == "Y")
            {
                PropertyChangedEvent("Y");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void PropertyChangedEvent([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
        public void Dispose()
        {
            _dataBall.Dispose();
        }
    }
}
