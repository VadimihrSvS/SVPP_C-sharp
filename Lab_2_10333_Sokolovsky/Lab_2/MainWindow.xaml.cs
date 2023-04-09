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

namespace Lab_2
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

            foreach(COLOREYES color in Enum.GetValues(typeof(COLOREYES)))
            {
                comboBoxEyes.Items.Add(color);
            }
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
            driver.Height = (int) sliderHGT.Value;

            if(sliderHGT.Value == 144) driver.Height = 0;
            

            if (radioButtonMale.IsChecked == true) driver.Gender = GENDER.male;
            else if(radioButtonFemale.IsChecked == true) driver.Gender = GENDER.female;
            else if(radioButtonVariant.IsChecked == true) driver.Gender = GENDER.variant;

            driver.UriImage = new ("/images.Homer_Simpson.jpg");

            if (checkBoxDonor.IsChecked == true) driver.Donor = true;
            else driver.Donor = false;

            

            MessageBox.Show(driver.ToString());
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            driver.Name = "Homer Simpson";
            driver.Class1 = 'A';
            driver.Address = "Springfield";
            driver.Number = "0123456789";
            driver.Height = 172;
            driver.Gender = GENDER.male;
            driver.Eyes = COLOREYES.brown;
            driver.Dob = new DateTime(1968, 1, 1);
            driver.Iss = new DateTime(2008, 10, 22);
            driver.Exp = new DateTime(2038, 10, 22);
            driver.Donor = true;
            driver.UriImage = "images/Homer_Simpson.jpg";
            textBoxName.Text = driver.Name;
            textBoxNumber.Text = driver.Number;
            textBoxAddress.Text = driver.Address;
            textBoxClass.Text = driver.Class1.ToString();
            sliderHGT.Value = driver.Height;
            datePickerDOB.SelectedDate = driver.Dob;
            datePickerEXP.SelectedDate = driver.Exp;
            datePickerISS.SelectedDate = driver.Iss;
            comboBoxEyes.SelectedItem = driver.Eyes;
            checkBoxDonor.IsChecked = driver.Donor;
            if (driver.Gender == GENDER.male) radioButtonMale.IsChecked = true;
            if (driver.Gender == GENDER.female) radioButtonFemale.IsChecked = true;
            if (driver.Gender == GENDER.variant) radioButtonVariant.IsChecked = true;
            image.Source = new BitmapImage(new Uri(driver.UriImage, UriKind.RelativeOrAbsolute));


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
            if(ofd.ShowDialog() == true)
            {
                driver.UriImage = ofd.FileName;
                image.Source = new BitmapImage(new Uri(driver.UriImage));
            }
        }
    }
}
