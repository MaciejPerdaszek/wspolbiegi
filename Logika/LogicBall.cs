using Dane;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _x; 
        private double _y;
        private double _diameter;
        private IBall _dataBall;

        public double X
        {
            get { return _x; }
            set { _x = value; _dataBall.X = value; PropertyChangedEvent(); }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; _dataBall.Y = value; PropertyChangedEvent(); }
        }
        
        public double Diameter { get => _diameter; set => _diameter = value; }

        public LogicBall(IBall dataBall, double diameter)
        {
            _x = dataBall.X;
            _y = dataBall.Y;
            _diameter = diameter;
            _dataBall = dataBall;
            dataBall.PropertyChanged += DataBall_PropertyChanged;
        }

        private void DataBall_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(sender != null) { 
                IBall b = (IBall)sender;
                X = b.X; 
                Y = b.Y;
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
