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
        Cat.UserControlNyanCat[] cats = new Cat.UserControlNyanCat[3];
        DispatcherTimer timer;
        Random random = new Random();
        public MainWindow()
        {
           
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            for(int i = 0; i < canvases.Length; i++)
            {
                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);
                cats[i] = new Cat.UserControlNyanCat();
                canvases[i].Children.Add(cats[i]);
            }


            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
           
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            for(int i = 0; i < cats.Length; i++)
            {
                cats[i].YCat += cats[i].GetSpeed() / 800f;
            }
            

        }

        

    }
}
