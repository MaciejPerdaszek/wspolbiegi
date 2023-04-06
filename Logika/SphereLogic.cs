using Dane;

namespace Logika
{
    public class SphereLogic
    {
        private List<Sphere> sphereList;

        public List<Sphere> SphereList
        {
            get
            {
                return sphereList;
            }
        }

        public void createSpheres(int amount, double radius)
        {
            sphereList = new List<Sphere>();
            for(int  i = 0; i < amount; i++)
            {
                double x = radius * i;
                double y = radius * i;  
                Sphere sphere = new Sphere(radius, x, y);
                sphereList.Add(sphere);
            }
        }
    }
}
