using Dane;
using Prezentacja.Model;
using Prezentacja.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable, INotifyPropertyChanged
    {
        #region private

        private ModelAbstractAPI ModelApi;

        private ObservableCollection<IBall> Balls;

        private int amountOfBalls;

        #endregion private
       
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

        #region public API
        public MainWindowViewModel()
        {
            MyCanvas = new Canvas();
            ModelApi = ModelAbstractAPI.CreateApi();
            CreateBallsCommand = new Commands(CreateBallsOnBoard);
            Balls = ModelApi.getBalls();
            Balls.CollectionChanged += BallsCollectionChangedEvent;
        }

        public Canvas MyCanvas { get; set; }

        public ICommand CreateBallsCommand { get; set; }

        public string Amount
        {
            get
            {
                return Convert.ToString(amountOfBalls);
            }
            set
            {
                amountOfBalls = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }

        private void CreateBallsOnBoard(object obj)
        {
            ModelApi.CreateBalls(amountOfBalls);
            
        }

        private void BallsCollectionChangedEvent(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (IBall b in Balls)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Width = 15;
                ellipse.Height = 15;
                ellipse.Fill = Brushes.Black;
                ellipse.Stroke = Brushes.Black;
                Canvas.SetLeft(ellipse, b.X);
                Canvas.SetTop(ellipse, b.Y);

                MyCanvas.Children.Add(ellipse);
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
