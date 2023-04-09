using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Lab_4_10333
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas[] canvases = new Canvas[3];
        Space.UserControlNyanCat cat = new Space.UserControlNyanCat();
        DispatcherTimer timer;
        Random random = new Random();
        public MainWindow()
        {
           
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            this.ResizeMode = ResizeMode.NoResize;
            for(int i = 0; i < canvases.Length; i++)
            {
                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);
            }


            canvases[1].Children.Add(cat);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
           
            

            

        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            cat.YCat += cat.GetSpeed() / 800f;

        }

    }
}
