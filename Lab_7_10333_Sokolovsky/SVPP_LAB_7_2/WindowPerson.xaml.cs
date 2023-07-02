using System.Windows;

namespace BD_Adapter
{
    public partial class WindowPerson : Window
    {
        public WindowPerson(PC pc)
        {
            InitializeComponent();
            grid.DataContext = pc;
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
