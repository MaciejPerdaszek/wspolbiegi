namespace Dane
{

    public delegate void DataBallChangedEventHandler(IDataBall sender, double x, double y);
    public interface IDataBall : IDisposable
    {
        double speedX { get; set; }
        double speedY { get; set; }

        int directionX { get; set; }
        int directionY { get; set; }

        int Id { get; }

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
        public abstract IDataBall CreateBall(double x, double y);

    }
}
