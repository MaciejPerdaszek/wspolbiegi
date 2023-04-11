using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prezentacja.Model;
using Dane;
using System.Windows.Controls;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable, INotifyPropertyChanged
    {
        #region private

        private ModelAbstractAPI ModelApi;
        private ObservableCollection<IBall> Balls;
        private int amountOfBalls;

        #endregion

        #region INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            ModelApi = ModelAbstractAPI.CreateApi();
            CreateBallsCommand = new Commands(CreateBallsOnBoard);
            Balls = ModelApi.getBalls();
            Balls.CollectionChanged += BallsCollectionChangedEvent;
        }

        #endregion

        #region IDispose

        public void Dispose()
        {
            ModelApi.Dispose();
        }

        #endregion

        #region Public Api

        public Canvas MyCanvas { get; } = new Canvas();

        public ICommand CreateBallsCommand { get; set; }

        public string Amount
        {
            get => Convert.ToString(amountOfBalls);
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

        private void BallsCollectionChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (IBall b in Balls)
            {
                var ellipse = new System.Windows.Shapes.Ellipse
                {
                    Width = 15,
                    Height = 15,
                    Fill = System.Windows.Media.Brushes.Black,
                    Stroke = System.Windows.Media.Brushes.Red,
                };

                MyCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, b.X);
                Canvas.SetTop(ellipse, b.Y);

                // Subscribe to ball property changed event
                b.PropertyChanged += Ball_PropertyChanged;
            }


        }

        private void Ball_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Ball.X) || e.PropertyName == nameof(Ball.Y))
            {
                var ball = (Ball)sender;
                foreach (System.Windows.Shapes.Ellipse ellipse in MyCanvas.Children)
                {
                    if (Canvas.GetLeft(ellipse) == ball.X && Canvas.GetTop(ellipse) == ball.Y)
                    {
                        Canvas.SetLeft(ellipse, ball.X);
                        Canvas.SetTop(ellipse, ball.Y);
                    }
                }
            }
        }

        #endregion
    }
}