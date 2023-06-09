﻿using System;
using System.Windows.Input;
using Prezentacja.Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Prezentacja.ViewModel
{
    public class MainWindowViewModel : IDisposable
    { 
        private ModelAbstractAPI ModelApi;

        private int amountOfBalls;

        private int diameter = 30;

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
            ModelApi.CreateTable(500 - diameter, 300 - diameter);
            foreach (IViewBall b in ModelApi.CreateBalls(amountOfBalls, diameter, 1))
            {
                var ellipse = new Ellipse
                {
                    Width = b.Diameter-5,
                    Height = b.Diameter-5,
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

