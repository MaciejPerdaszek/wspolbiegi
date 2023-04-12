using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prezentacja.Model;
using Dane;
using System.Windows.Controls;
using System.Reactive;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Animation;
using System.Drawing;
using System.Windows.Media.Media3D;
using System.Diagnostics;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable
    { 
        private ModelAbstractAPI ModelApi;

        private int amountOfBalls;

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
            ModelApi.CreateBalls(amountOfBalls, 5);

            foreach (ViewBall b in ModelApi.GetViewBalls())
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

