namespace Dane
{
    public class Sphere
    {
        private double radius;
        private double x;
        private double y;
        private double updatedPositionX;
        private double updatedPositionY;

        public Sphere(double radius, double x, double y)
        {
            this.radius = radius;   
            this.x = x; 
            this.y = y;    
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get {
                return y;
            }
            set { 
            y = value;  
            }
        }

        public double Radius 
        { 
            get { 
                return radius; 
            }
            set {
                radius = value;
            }
        }

        public void UpdatePosition()
        {
            Random random = new Random();
            updatedPositionX = random.NextDouble() * 2 - 1;
            updatedPositionY = random.NextDouble() * 2 - 1;
            this.x += this.updatedPositionX;
            this.y += this.updatedPositionY;
        }   

    }
}