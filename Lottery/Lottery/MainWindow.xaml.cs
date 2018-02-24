using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lottery
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> list = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            for (int i = 1; i < 55; i++)
            {
                list.Add(i);
            }
            if (File.Exists("D:\\test.txt"))
            {
                File.Delete("D:\\test.txt");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int num = r.Next(100000) % list.Count;
            int num2 =list[num];
            left1.Content = num2 / 10;
            right1.Content = num2 % 10;
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grid1.Visibility = Visibility.Visible;
            grid2.Visibility = Visibility.Collapsed;
            grid.ReleaseMouseCapture();
            if (timer.IsEnabled)
            {
                timer.Stop();
                int num = (int)left1.Content*10 + (int)right1.Content;
                list.Remove(num);
                //MessageBox.Show(num.ToString());
                File.AppendAllText("D:\\test.txt", num.ToString() + "  ");
            }
            else
            {
                timer.Start();
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grid1.Visibility = Visibility.Collapsed;
            grid2.Visibility = Visibility.Visible;
            grid.CaptureMouse();
        }
    }
}
