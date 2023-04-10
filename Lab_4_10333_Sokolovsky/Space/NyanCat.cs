using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Cat
{
    public class NyanCat: INotifyPropertyChanged
    {
        int speed;
        int position;
        float x;
        bool isFinished;


        public NyanCat(int speed)
        {
            this.speed = speed;
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

        public int Position
        {
            get =>  position;
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public float X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged("X");
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
