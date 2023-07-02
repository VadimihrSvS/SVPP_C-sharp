using SVPP_Lab_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace SVPP_Lab_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EntityContext entityContext;
        public MainWindow()
        {
            InitializeComponent();
            entityContext = new EntityContext();
            entityContext.PCs.Load();
            dGrid.ItemsSource = entityContext.PCs.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PC pc = new PC();
            WindowEdit windowEdit = new WindowEdit(pc);
            if (windowEdit.ShowDialog() == false)
                return;
            entityContext.PCs.Add(pc);
            entityContext.SaveChanges();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить записи", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.No) return;
     
            if(dGrid.SelectedItems.Count > 0)
            {
                for(int i = dGrid.SelectedItems.Count - 1; i >= 0 ; i--)
                {
                    PC pc = dGrid.SelectedItems[i] as PC;
                    if(pc != null)
                    {
                        entityContext.PCs.Remove(pc);
                    }
                }
            }
            entityContext.SaveChanges();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PC pc = dGrid.SelectedItem as PC;
            WindowEdit windowEdit = new WindowEdit(pc);
            if (windowEdit.ShowDialog() == true)
            {
                entityContext.SaveChanges();
            }
            else
            {
                entityContext.Entry(pc).Reload();
                dGrid.DataContext = null;
                dGrid.DataContext = entityContext.PCs.Local.ToBindingList();
            }

            entityContext.SaveChanges();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            entityContext.Dispose();
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
