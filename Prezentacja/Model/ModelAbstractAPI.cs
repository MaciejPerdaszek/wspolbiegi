using Dane;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Prezentacja.Model
{
    public abstract class ModelAbstractAPI : IDisposable
    {

        public static ModelAbstractAPI CreateApi()
        {
            return new Model();
        }

        public abstract void CreateBalls(int amount);

        public abstract ObservableCollection<IBall> getBalls();

        #region IDisposable

        public abstract void Dispose();

        #endregion IDisposable
    }
}
