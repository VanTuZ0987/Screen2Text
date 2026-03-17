using System;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenshotReader
{
    class SelectorForm : Form
    {
        private Point _startPoint;
        private int _clickCount = 0;
        private Point _endPoint;
        public Rectangle SelectedArea { get; private set; }
        public SelectorForm()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;
            Opacity = 0.5;
            TopMost = true;
            MouseClick += OnMouseClick;
            FormClosing += OnFormClosing;

        }
    
    
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            _clickCount = (_clickCount + 1) % 3;
            _startPoint = _clickCount == 1 ? e.Location : _startPoint;
            _endPoint = _clickCount == 2 ? e.Location : _endPoint;
            
            if(_clickCount == 2)
            {
                CreateSelectionFromPoints();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        
        
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine($"Start Point: {_startPoint}");
            Console.WriteLine($"End Point: {_endPoint}");    
        }


        private void CreateSelectionFromPoints()
        {
            SelectedArea = new Rectangle(
                Math.Min(_startPoint.X, _endPoint.X),
                Math.Min(_startPoint.Y, _endPoint.Y),
                Math.Abs(_startPoint.X - _endPoint.X),
                Math.Abs(_startPoint.Y - _endPoint.Y)
            );
        }
    }
}