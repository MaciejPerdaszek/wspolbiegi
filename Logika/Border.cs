namespace Logika
{
    public class Border
    {
        private int width;
        private int height; 

        public Border(int width, int height)
        {
            this.width = width;
            this.height = height;
        }   

        public int Width { 
            get { 
                return width; 
            }
        }

        public int Height {
            get {
                return height;
            }
        }


    }
}
