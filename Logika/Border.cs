namespace Logika
{
    public class Border
    {
        private double width;
        private double height; 

        public Border(double width, double height)
        {
            this.width = width;
            this.height = height;
        }   

        public double Width { 
            get { 
                return width; 
            }
        }

        public double Height {
            get {
                return height;
            }
        }


    }
}
