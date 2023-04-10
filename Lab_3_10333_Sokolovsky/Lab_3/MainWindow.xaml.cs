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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Driver driver = new Driver();
        public MainWindow()
        {
            
            InitializeComponent();

            //foreach (COLOREYES color in Enum.GetValues(typeof(COLOREYES)))
            //{
            //    comboBoxEyes.Items.Add(color);
            //}
            newDriver();
            grid.DataContext = driver;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            driver.Name = textBoxName.Text;
            driver.Number = textBoxNumber.Text;
            driver.Address = textBoxAddress.Text;
            driver.Class1 = (textBoxClass.Text.Length > 0) ? textBoxClass.Text[0] : 'A';
            driver.Dob = (datePickerDOB.SelectedDate == null) ? DateTime.Now : (DateTime)datePickerDOB.SelectedDate;
            driver.Exp = (datePickerEXP.SelectedDate == null) ? DateTime.Now : (DateTime)datePickerEXP.SelectedDate;
            driver.Iss = (datePickerISS.SelectedDate == null) ? DateTime.Now : (DateTime)datePickerISS.SelectedDate;
            driver.Eyes = (comboBoxEyes.SelectedIndex > -1) ? (COLOREYES)comboBoxEyes.SelectedItem : COLOREYES.blue;
            driver.Height = (int)sliderHGT.Value;

            if (sliderHGT.Value == 144) driver.Height = 0;


            if (radioButtonMale.IsChecked == true) driver.Gender = GENDER.male;
            else if (radioButtonFemale.IsChecked == true) driver.Gender = GENDER.female;
            else if (radioButtonVariant.IsChecked == true) driver.Gender = GENDER.variant;

            driver.UriImage = new("/images.Homer_Simpson.jpg");

            if (checkBoxDonor.IsChecked == true) driver.Donor = true;
            else driver.Donor = false;



            MessageBox.Show(driver.ToString());
        }

        private void newDriver()
        {
            driver.Name = "Homer Simpson";
            driver.Class1 = 'A';
            driver.Address = "Springfield";
            driver.Number = "0123456789";
            driver.Height = 172;
            driver.Gender = GENDER.male;
            driver.Eyes = COLOREYES.blue;
            driver.Dob = new DateTime(1968, 1, 1);
            driver.Iss = new DateTime(2008, 10, 22);
            driver.Exp = new DateTime(2038, 10, 22);
            driver.Donor = true;
            driver.UriImage = "images/Homer_Simpson.jpg";
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {

            driver.Name = "Peter Griffin";
            driver.Class1 = 'B';
            driver.Address = "New Mexico";
            driver.Number = "123123123";
            driver.Height = 181;
            driver.Gender = GENDER.variant;
            driver.Eyes = COLOREYES.brown;
            driver.Dob = new DateTime(1969, 5, 1);
            driver.Iss = new DateTime(2008, 11, 22);
            driver.Exp = new DateTime(2038, 11, 22);
            driver.Donor= true;
            driver.UriImage = "images/Peter_Griffin.jpg";



        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxAddress.Text = "";
            textBoxClass.Text = "";
            textBoxName.Text = "";
            textBoxNumber.Text = "";
            sliderHGT.Value = 0;
            driver.Height = 0;
            datePickerDOB.SelectedDate = null;
            datePickerEXP.SelectedDate = null;
            datePickerISS.SelectedDate = null;
            checkBoxDonor.IsChecked = false;
            radioButtonMale.IsChecked = false;
            radioButtonFemale.IsChecked = false;
            radioButtonVariant.IsChecked = false;
            comboBoxEyes.Text = "";
            driver.UriImage = "images/cross-mark.png";
            image.Source = new BitmapImage(new Uri(driver.UriImage, UriKind.RelativeOrAbsolute));

        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы(jpg) | *.jpg | Все файлы | *.*";
            if (ofd.ShowDialog() == true)
            {
                driver.UriImage = ofd.FileName;
                image.Source = new BitmapImage(new Uri(driver.UriImage, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
