using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Triangles
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IObservable<Point> leftClicks =
                from e in Observable.FromEventPattern<MouseButtonEventArgs>(
                    _canvas, nameof(_canvas.MouseDown))
                where e.EventArgs.LeftButton == MouseButtonState.Pressed
                select e.EventArgs.GetPosition(_canvas);

            IObservable<Polygon> triangles = leftClicks
                .Buffer(3)
                .Select((IList<Point> points) => new Polygon
                {
                    Points = new PointCollection(points),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                });

            triangles.Subscribe(t => _canvas.Children.Add(t));

            _clearButton.Click += (s, e) => _canvas.Children.Clear();
        }
    }
}
