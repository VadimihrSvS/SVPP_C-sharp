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

        public UserControlNyanCat()
        {
            InitializeComponent();
            cat = new NyanCat();
            
            textBlockHp.DataContext = cat;
            Binding bindingHp = new Binding("Hp");
            textBlockHp.SetBinding(TextBlock.TextProperty, bindingHp);

            textBlockSpeed.DataContext = cat;
            Binding bindingSpeed = new Binding("Speed");
            textBlockSpeed.SetBinding(TextBlock.TextProperty, bindingSpeed);

            this.DataContext = cat;
            this.SetBinding(Canvas.LeftProperty, new Binding("Y"));          
            
        }

        



        public void UpdateHp(int hp)
        {
            cat.Hp = hp;
        }

        public int GetHp()
        {
            return cat.Hp;
        }

        public int GetSpeed()
        {
            return cat.Speed;
        }

        public float YCat
        {
            get
            {
                return cat.Y;
            }

            set
            {
                 cat.Y = value;
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
        
    }
}
