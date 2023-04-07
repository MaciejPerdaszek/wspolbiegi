using System;
using System.ComponentModel;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        #region public API
        public MainWindowViewModel()
        {
            //ModelLayer = ModelApi.CreateApi();
            //ModelLayer.Start();
        }
        
        //public ObservableCollection storing Balls

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion public API

        #region IDisposable
        public void Dispose()
        {
            //ModelLayer.Dispose();
        }

        #region private

        //private ModelAPI ModelLayer;

        #endregion private
    }
}
