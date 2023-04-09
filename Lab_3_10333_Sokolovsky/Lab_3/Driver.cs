using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Lab_3
{

    public enum GENDER { male, female, variant };
    public enum COLOREYES { brown, green, blue, gray };


    public class Driver : INotifyPropertyChanged, IDataErrorInfo
    {


        string number;
        char class1;
        string name;
        double height;
        string address;
        DateTime dob;
        DateTime iss;
        DateTime exp;
        bool donor;
        string uriImage;
        GENDER gender;
        COLOREYES eyes;

        public Driver()
        {
        }
        string numPattern = @"[0-9a-zA-Z]"; 
        public string this[string columnName]
        {

            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Class1":
                        if (Class1 < 'A' || Class1 > 'E')                       
                            error = "Not valid Category";
                            break;
                    case "Exp":
                        if (Exp < DateTime.Now)
                            error = "Is expired";
                        break;
                    case "Number":
                        if(!Regex.IsMatch(Number, numPattern, RegexOptions.IgnoreCase)){
                            error = "Number is not valid(Extra symbols)";
                        }
                        break;
                    case "Dob":
                        if(Dob <= new DateTime(1900, 1, 1) || Dob > DateTime.Now.AddYears(-16))
                        {
                            error = "Date of birth is not valid";
                        }
                        break;
                    case "Iss": 
                        if(Iss > DateTime.Now || Iss < DateTime.Now.AddYears(-16))
                        {
                            error = "Date of extradition is not valid";
                        }
                        break;
                }
                return error;
            }
        }



        public string Number {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public char Class1 {
            get => class1;
            set
            {
                class1 = value;
                OnPropertyChanged("Class1");
            }
        }
        public string Name {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Height {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Address 
        {   get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public DateTime Dob {
            get => dob;
            set
            {
                dob = value;
                OnPropertyChanged("Dob");

            }
        }
        public DateTime Iss
        {
            get => iss;
            set
            {
                iss = value;
                OnPropertyChanged("Iss");

            }
        }
        public DateTime Exp
        {
            get => exp;
            set
            {
                exp = value;
                OnPropertyChanged("Exp");

            }
        }
        public bool Donor {
            get => donor;
            set
            {
                donor = value;
                OnPropertyChanged("Donor");
            }
        }
        public string UriImage
        { 
            get => uriImage;
            set
            {
                uriImage = value;
                OnPropertyChanged("UriImage");
            }
        }
        public GENDER Gender 
        { get => gender;
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
            }
        public COLOREYES Eyes 
        { get => eyes;
            set
            {
                eyes = value;
                OnPropertyChanged("Eyes");
            }

            }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler? PropertyChanged;





        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public override string? ToString()
        {
            return $"№{Number} Class {Class1} from {Iss.ToShortDateString()} to {Exp.ToShortDateString()}. {Name}, {Gender} Date of birth ({Dob.ToShortDateString()}). Address {Address}. Height {Height}. Eyes {Eyes}. " +
                $"{(Donor ? "Donor": "Not Donor")} URI: {UriImage}";
        }
    }
}
