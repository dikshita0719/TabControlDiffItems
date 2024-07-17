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
using System.Windows.Threading;

namespace deletelater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer();
        bool nachrechts = true;
        public MainWindow()
        {
            timer1.Interval = TimeSpan.FromMilliseconds(30);
            timer1.Tick += MoveTheBus;
            timer1.Tick += ColorsOfBus;
            InitializeComponent();
        }
        Brush myColor;
        private void ColorsOfBus(object sender, EventArgs e)
        {
            
            Random r = new Random();

            myColor = new SolidColorBrush(Color.FromRgb((byte)(r.Next(1, 255)), (byte)(r.Next(1, 255)), (byte)(r.Next(1, 255))));
            myRect.Fill =myColor;
            myBall1.Fill =myColor;
            myBall2.Fill =myColor;
        }
        private void MoveTheBus(object sender, EventArgs e)
        {


            var x = Canvas.GetLeft(myRect);
            var y = Canvas.GetLeft(myBall1);
            var z = Canvas.GetLeft(myBall2);

            if(nachrechts)
            {
                Canvas.SetLeft(myRect, x + 2);
                Canvas.SetLeft(myBall1, y + 2);
                Canvas.SetLeft(myBall2, z + 2);
            }
            else
            {
                Canvas.SetLeft(myRect, x - 2);
                Canvas.SetLeft(myBall1, y - 2);
                Canvas.SetLeft(myBall2, z - 2);
            }

            if( x > myCanvas.ActualWidth - myRect.ActualWidth ) 
            {
                nachrechts = false;
                Canvas.SetLeft(myRect, x -2  );
                Canvas.SetLeft(myBall1, y-2);
                Canvas.SetLeft(myBall2, z -2);
            }
            else if(x<= 0) { nachrechts=true; }
        }
        int zahl;
        
       
        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            if(timer1.IsEnabled) { timer1.Stop(); }
            else { timer1.Start(); }
            myRect.Visibility = Visibility.Visible;
            myBall1.Visibility = Visibility.Visible;
            myBall2.Visibility = Visibility.Visible;
        }

        private void btn21_Click(object sender, RoutedEventArgs e)
        {
            zahl = Convert.ToInt32(eingabe.Text);
            if(zahl % 7 == 0)
            {
                for(int i=1; i<zahl ; i++)
                {
                    if(zahl% i  == 0)
                    {
                        ausgabe.Items.Add(i.ToString());
                    }
                }
                ausgabe.Items.Add(eingabe.Text);
            }
            else
            {
                MessageBox.Show("Bitte richtig lesen", "505 ERROR FOUND" ,MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn22_Click(object sender, RoutedEventArgs e)
        {
            ausgabe.Items.Clear();
            eingabe.Text = "";
        }

        private void btn31_CLick(object sender, RoutedEventArgs e)
        {
            if(rect1.Visibility == Visibility.Collapsed &&
                rect2.Visibility == Visibility.Collapsed &&
                rect3.Visibility == Visibility.Collapsed
                )
            {
                rect1.Visibility = Visibility.Visible;
                rect2.Visibility = Visibility.Visible;
                rect3.Visibility = Visibility.Visible ;
            }
            else if(rect1.Visibility == Visibility.Visible &&
                rect1.Visibility == Visibility.Visible &&
                rect1.Visibility == Visibility.Visible)
                {
                rect1.Visibility = Visibility.Collapsed;
                rect2.Visibility = Visibility.Collapsed;
                rect3.Visibility = Visibility.Collapsed;
            }
        }
    }
}
