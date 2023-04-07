using Logika;
using System.ComponentModel;

namespace Model
{
    public class API
    {
        public static void createSpheres(int amount, double radius)
        {
            Logika.SphereLogic l = new Logika.SphereLogic();
            l.createSpheres(amount, radius);
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}