using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Integral integral;
        BackgroundWorker backgroundWorker;
        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker = (BackgroundWorker)this.Resources["worker"];
        }

        private void buttonParams_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            if (window1.ShowDialog() != true) return;
            integral = window1.integral;
            MessageBox.Show(integral.ToString());
        }

        private void buttonD_Click(object sender, RoutedEventArgs e) 
        {
            listBox.Items.Clear();
            if (integral == null) return;
            Thread thread = new Thread(Calculate);
            buttonD.IsEnabled = false;
            buttonW.IsEnabled = false;
            buttonA.IsEnabled = false;
            thread.Start();
            
        }

        private void buttonW_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            buttonD.IsEnabled = false;
            buttonW.IsEnabled = false;
            buttonA.IsEnabled = false;
            backgroundWorker.RunWorkerAsync();

        }

        private async void buttonA_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            if(integral == null) return;
            buttonD.IsEnabled = false;
            buttonW.IsEnabled = false;
            buttonA.IsEnabled = false;
            IAsyncEnumerable<(double, double, double)> data = integral.GetDoublesAsync();
            await foreach(var d in data)
            {
                listBox.Items.Add($"x = {d.Item1:0.00} S = {d.Item2:0.00000}");
                pBar.Value = d.Item3 * 100;
            }
            buttonD.IsEnabled = true;
            buttonW.IsEnabled = true;
            buttonA.IsEnabled = true;
        }



        private void Calculate()
        {
            if (integral == null) return;
            int n = integral.N;
            double h = (integral.B - integral.A) / n;
            double S = 0.0;
            var step = Math.Round((double)n / 100);
            for (int i = 0; i <= n; i++)
            {
                double x = integral.A + h * i;
                S += integral.f(x) * h;
                if (i % step == 0)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => pBar.Value = i/step));
                }
                Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() => listBox.Items.Add($"x = {x:0.00} S = {S:0.00000}")));
                Thread.Sleep(20);
            }
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { buttonD .IsEnabled = buttonW.IsEnabled = buttonA.IsEnabled = true; }));
            
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (integral == null) return;
            
            int n = integral.N;
            double h = (integral.B - integral.A) / n;
            double S = 0.0;
            var step = Math.Round((double)n / 100);
            for (int i = 0; i <= n; i++)
            {
                double x = integral.A + h * i;
                S += integral.f(x) * h;
                var data = (x, S);
                    if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
                        backgroundWorker.ReportProgress((int)(i /step), data);
                Thread.Sleep(20);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progressData = (ValueTuple<double, double>) e.UserState;
            pBar.Value = e.ProgressPercentage;
            listBox.Items.Add($"x = {progressData.Item1:0.00} S = {progressData.Item2:0.00000}");
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonD.IsEnabled = true;
            buttonW.IsEnabled = true;
            buttonA.IsEnabled = true;
        }
    }
}
