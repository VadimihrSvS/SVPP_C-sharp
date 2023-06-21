using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Integral integral;

        public Window1()
        {
            InitializeComponent();
            integral = new Integral(0, 10, 200);
            grid.DataContext = integral;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
