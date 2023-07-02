
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace BD
{
    public partial class MainWindow : Window
    {
        PC pc;
        ObservableCollection<PC> collection = new ObservableCollection<PC>();
        public MainWindow()
        {
            InitializeComponent();
            pc = new PC();
            stackpanelPerson.DataContext = pc;
            listBox.DataContext = collection;
            FillData();
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            collection.Clear();
            foreach (var p in PC.getAllPersons())
            {
                collection.Add(p);
            }
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            pc.Insert();
            FillData();
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            pc = PC.Find(textBoxBrand.Text);
            if (pc == null)
            {
                MessageBox.Show("Нет такой записи!");
                pc = new PC();
            }
            else
                MessageBox.Show(pc.ToString());
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нет выбранной записи!");
                return;
            }
            pc.Id = ((PC)listBox.SelectedItem).Id;

            if (textBoxBrand.Text.Length > 0)
                pc.Brand = textBoxBrand.Text;
            else
                pc.Brand = ((PC)listBox.SelectedItem).Brand;

            decimal d = Convert.ToDecimal(textBoxPrice.Text);
            if (d != 0)
                pc.Price = d;
            else
                pc.Price = ((PC)listBox.SelectedItem).Price;
            pc.Update();
            FillData();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нет выбранной записи!");
                return;
            }
            var id = ((PC)listBox.SelectedItem).Id;
            PC.Delete(id);
            FillData();
        }
    }
}
