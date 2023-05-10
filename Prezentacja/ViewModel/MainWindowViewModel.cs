using System;
using System.Windows.Input;
using Prezentacja.Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable
    { 
        private ModelAbstractAPI ModelApi;

        private int amountOfBalls;

        private List<IViewBall> viewBalls;

        public MainWindowViewModel()
        {
            ModelApi = ModelAbstractAPI.CreateApi();
            CreateBallsCommand = new Commands(CreateBallsOnBoard);
        }

        public void Dispose()
        {
            ModelApi.Dispose();
        }


        public Canvas MyCanvas { get; } = new Canvas();

        public double CanvasWidth { get; set; }

        public double CanvasHeight { get; set; }

        public ICommand CreateBallsCommand { get; set; }

        public string Amount
        {
            get => Convert.ToString(amountOfBalls);
            set
            {
                amountOfBalls = Convert.ToInt32(value);
            }
        }

        private void CreateBallsOnBoard(object obj)
        {
            ModelApi.CreateTable(500, 300);
            foreach (IViewBall b in ModelApi.CreateBalls(amountOfBalls, 2, 1))
            {
                var ellipse = new Ellipse
                {
                    Width = 15,
                    Height = 15,
                    Fill = System.Windows.Media.Brushes.Black,
                    Stroke = System.Windows.Media.Brushes.Red,
                };

                Binding bindingX = new("X")
                {
                    Source = b
                };
                Binding bindingY = new("Y")
                {
                    Source = b
                };
                ellipse.SetBinding(Canvas.LeftProperty, bindingX);
                ellipse.SetBinding(Canvas.TopProperty, bindingY);
                MyCanvas.Children.Add(ellipse);
            }

        }
    }
}

