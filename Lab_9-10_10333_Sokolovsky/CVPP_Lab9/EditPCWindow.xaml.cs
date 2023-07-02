using Microsoft.Win32;
using SVPP_Lab9.Commands;
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
using System.Windows.Shapes;

namespace SVPP_Lab9
{
    /// <summary>
    /// Логика взаимодействия для EditPCWindow.xaml
    /// </summary>
    public partial class EditPCWindow : Window
    {
        public EditPCWindow()
        {
            InitializeComponent();
        }
        #region properties

        public string Brand
        {
            get { return (string)GetValue(BrandProperty); }
            set { SetValue(BrandProperty, value); }
        }

        public static readonly DependencyProperty BrandProperty
            = DependencyProperty.Register("Brand", typeof(string),
                typeof(EditPCWindow), new PropertyMetadata(default(string)));

        public DateTime BuildDate
        {
            get { return (DateTime)GetValue(BuildDateProperty); }
            set { SetValue(BuildDateProperty, value); }
        }

        public static readonly DependencyProperty BuildDateProperty
            = DependencyProperty.Register("BuildDate",
                typeof(DateTime), 
                typeof(EditPCWindow), new PropertyMetadata(default(DateTime)));

        public decimal Price
        {
            get { return (decimal)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty
            = DependencyProperty.Register("Price",
                typeof(decimal),
                typeof(EditPCWindow), new PropertyMetadata(default(decimal)));

        public string ImagePass
        {
            get { return (string) GetValue(ImagePassProperty); }
            set { SetValue(ImagePassProperty, value); }
        }

        public static readonly DependencyProperty ImagePassProperty
            = DependencyProperty.Register("ImagePass", typeof(string),
                typeof(EditPCWindow), new PropertyMetadata(default(string)));


        #endregion

        private ICommand _selectImageCommand;
        public ICommand SelectImageCommand =>
            _selectImageCommand
            ?? new RelayCommand(OnSelectImageExecuted);

        public void OnSelectImageExecuted(object param)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ImagePass = dialog.FileName;
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand =>
            _okCommand
            ?? new RelayCommand(OnOkExecuted);

        public void OnOkExecuted(object param)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
