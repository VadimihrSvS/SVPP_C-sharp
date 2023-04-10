using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cat
{
    public class NyanCat: INotifyPropertyChanged
    {
        int speed;
        int hp;
        float x;
        float y;
        bool isFinished;
        

        public NyanCat()
        {
        }

        public int Speed
        {
            get => speed;
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public int Hp
        {
            get =>  hp;
            set
            {
                hp = value;
                OnPropertyChanged("Hp");
            }
        }

        public float Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public bool IsFinished
        {
            get => isFinished;
            set
            {
                isFinished = value;
                OnPropertyChanged("IsFifished");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
