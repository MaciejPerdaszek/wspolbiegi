namespace Dane
{

    public delegate void DataBallChangedEventHandler(ILogicBall sender);
    public interface ILogicBall : IDisposable
    {

        double X { get; internal set; }
        double Y { get; internal set; }

        double speedX { get; set; }
        double speedY { get; set; }

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

        public abstract ILogicBall CreateBall(double x, double y);

    }
}
