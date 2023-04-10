using System;
using System.Windows;
using System.Windows.Media;
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
        Cat.UserControlFinish[] finishes = new Cat.UserControlFinish[3];
        Cat.UserControlPosition[] positions = new Cat.UserControlPosition[3];
        DispatcherTimer timer, timerUpdateSpeed;
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
                cats[i] = new Cat.UserControlNyanCat(0);
                canvases[i].Children.Add(cats[i]); 
                finishes[i] = new Cat.UserControlFinish();
                Canvas.SetRight(finishes[i], 0);
                canvases[i].Children.Add(finishes[i]);
                positions[i] = new Cat.UserControlPosition();
                Canvas.SetLeft(positions[i], 50);
                canvases[i].Children.Add(positions[i]);
            }

            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(100);
            timer.Tick += new EventHandler(timer_Tick);

            timerUpdateSpeed = new DispatcherTimer();
            timerUpdateSpeed.Interval = new TimeSpan(0, 0, 2);
            timerUpdateSpeed.Tick += new EventHandler(timerUpdateSpeed_Tick);

        }

        private void timerUpdateSpeed_Tick(object? sender, EventArgs e)
        {

            for (int i = 0; i < 3; i++)
            {
                if (cats[i].isFinished) continue;
                cats[i].UpdateSpeed(random.Next(30, 80));
            }

        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                cats[i].XCat = 0;
                cats[i].UpdateSpeed(0);
                cats[i].isFinished = false;
                finishes[i].Visibility = Visibility.Visible;
                positions[i].Visibility = Visibility.Hidden;
            }
            timerUpdateSpeed.Stop();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cats.Length; i++)
            {
                cats[i].UpdateSpeed(0);
                
            }
            timerUpdateSpeed.Stop();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cats.Length; i++)
            {
                if (cats[i].isFinished) continue;
                finishes[i].Visibility = Visibility.Visible;
                
                cats[i].UpdateSpeed(random.Next(20, 50));
                


            }
            timer.Start();
            timerUpdateSpeed.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            for(int i = 0; i < cats.Length; i++)
            {
                if (cats[i].isFinished) continue;

                int k = 0; //cat position
                for (int j = 0; j < cats.Length; j++)
                {
                    if (cats[j].isFinished || cats[i].XCat <= cats[j].XCat)
                        k++;
                }      
                if(cats[i].XCat < 780 && cats[i].isFinished == false)
                {
                    cats[i].UpdatePosition(k);
                    cats[i].XCat += (float)cats[i].GetSpeed() / 2000f;

                   
                } else
                {
                    finishes[i].Visibility = Visibility.Hidden;
                    positions[i].Visibility = Visibility.Visible;
                    cats[i].UpdatePosition(k);
                    positions[i].SetPosition(k);
                    cats[i].isFinished = true;
                    cats[i].UpdateSpeed(0);
                }
                
            }
            

        }

        

    }
}
