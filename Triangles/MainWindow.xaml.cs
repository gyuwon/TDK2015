using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Triangles
{
    public partial class MainWindow : Window
    {
        private readonly List<Point> _buffer = new List<Point>();

        public MainWindow()
        {
            InitializeComponent();

            _canvas.MouseDown += _canvas_MouseDown;
            _clearButton.Click += (s, e) => _canvas.Children.Clear();
        }

        private void _canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point point = e.GetPosition(_canvas);
                _buffer.Add(point);
                if (_buffer.Count == 3)
                {
                    _canvas.Children.Add(new Polygon
                    {
                        Points = new PointCollection(_buffer),
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    });
                    _buffer.Clear();
                }
            }
        }
    }
}
