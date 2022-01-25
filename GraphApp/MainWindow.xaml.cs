using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double x_coordinate =0,y_coordinate =0; //variables to keep track of the location of the points
        public static double x_origin =0,y_origin =0;
        public static Boolean IsInitialized = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        // funciton that will enable us to draw a line
        private void drawLine(double x, double y, double x2, double y2)
        {
            Line line =new Line();
            line.X1 = x;
            line.Y1 = y; 
            line.X2 = x2;
            line.Y2 = y2;
            line.StrokeThickness = 2;
            line.Stroke=Brushes.White;
            canvas.Children.Add(line);
        }

        // function that will enable us to add a lable to the canvas
        private void addLabel(double x, double y,String content)
        {
            Label label = new Label();
            label.Content = content;
            label.Margin = new Thickness(x,y,this.Width-x-50,this.Height-y-100);
            label.Foreground = Brushes.White;
            label.FontSize = 10;
            grid.Children.Add(label);
            
        }
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsInitialized)
            {
                double temp_x_coordinate = e.GetPosition(canvas).X;
                double temp_y_coordinate = e.GetPosition(canvas).Y;

                drawLine(x_coordinate, y_coordinate, temp_x_coordinate, temp_y_coordinate);
                drawLine(x_origin, y_coordinate, x_origin, temp_y_coordinate);
                drawLine(x_coordinate, y_origin, temp_x_coordinate, y_origin);
                double temp = temp_x_coordinate - x_origin;
                addLabel(temp_x_coordinate,y_origin+10,temp_x_coordinate.ToString());
                temp = canvas.Height - temp_y_coordinate -y_origin;
                addLabel(x_origin-50, temp_y_coordinate,temp_y_coordinate.ToString());
                x_coordinate = temp_x_coordinate;
                y_coordinate = temp_y_coordinate;
            }
            else
            {
                IsInitialized = true;
                x_coordinate = e.GetPosition(canvas).X;
                y_coordinate = e.GetPosition(canvas).Y;
                x_origin = x_coordinate;
                y_origin = y_coordinate;
            }
        }
    }
}
