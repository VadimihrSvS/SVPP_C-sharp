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


namespace Cat
{
    
    /// <summary>
    /// Логика взаимодействия для UserControlNyanCat.xaml
    /// </summary>
    public partial class UserControlNyanCat : UserControl
    {
        NyanCat cat;

        public UserControlNyanCat(int speed)
        {
            InitializeComponent();
            cat = new NyanCat(speed);
            
            textBlockSpeed.DataContext = cat;
            Binding bindingSpeed = new Binding("Speed");
            bindingSpeed.Converter = new SpeedToString();
            textBlockSpeed.SetBinding(TextBlock.TextProperty, bindingSpeed);

            textBlockPosition.DataContext = cat;
            Binding bindingPosition = new Binding("Position");
            bindingPosition.Converter = new PositionToString();
            textBlockPosition.SetBinding(TextBlock.TextProperty, bindingPosition);

            this.DataContext = cat;
            this.SetBinding(Canvas.LeftProperty, new Binding("X"));          


            
        }

        

        public void UpdatePosition(int position)
        {
            cat.Position = position;
        }

        public void UpdateSpeed(int speed)
        {
            cat.Speed = speed;
        }

        public int GetSpeed()
        {
            return cat.Speed;
        }

        public float XCat
        {
            get
            {
                return cat.X;
            }

            set
            {
                 cat.X = value;
            }
        }

        public bool isFinished
        {
            get
            {
                return cat.IsFinished;
            }
            set
            {
                cat.IsFinished = value;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(textBlockPosition.Visibility == Visibility.Visible)
            {
                textBlockPosition.Visibility = Visibility.Hidden;
            } else
            {
                textBlockPosition.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (textBlockSpeed.Visibility == Visibility.Visible)
            {
                textBlockSpeed.Visibility = Visibility.Hidden;
            }
            else
            {
                textBlockSpeed.Visibility = Visibility.Visible;
            }
        }
    }
}
