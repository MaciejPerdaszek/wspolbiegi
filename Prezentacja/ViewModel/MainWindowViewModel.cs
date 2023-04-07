using Dane;
using Prezentacja.Model;
using Prezentacja.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable, INotifyPropertyChanged
    {
        #region private

        private readonly ModelAbstractAPI ModelApi;

        private ObservableCollection<IBall> Balls;



        #endregion private
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged
        #region public API
        public MainWindowViewModel()
        {
            ModelApi = ModelAbstractAPI.CreateApi();
            Balls = ModelApi.getBalls();
            Balls.CollectionChanged += BallsCollectionChangedEvent;
        }

        public Canvas MyCanvas { get; set; }
        private void BallsCollectionChangedEvent(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (IBall b in Balls) {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 15;
                ellipse.Height = 15;
                ellipse.Fill = Brushes.Black;
                ellipse.Stroke = Brushes.Black;
                Canvas.SetLeft(ellipse, b.X);
                Canvas.SetTop(ellipse, b.Y);

                Canvas canvas = MainWindow.FindName("canvas");
            }
        }

        #endregion public API

        #region IDisposable
        public void Dispose()
        {
            ModelApi.Dispose();
        }
        #endregion IDisposable
    }
}
