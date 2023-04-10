using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{

    enum GENDER { male, female, variant };
    enum COLOREYES { brown, green, blue, gray };


    public class Driver
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

        public string Number { get => number; set => number = value; }
        public char Class1 { get => class1; set => class1 = value; }
        public string Name { get => name; set => name = value; }
        public double Height { get => height; set => height = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public DateTime Iss { get => iss; set => iss = value; }
        public DateTime Exp { get => exp; set => exp = value; }
        public bool Donor { get => donor; set => donor = value; }
        public string UriImage { get => uriImage; set => uriImage = value; }
        internal GENDER Gender { get => gender; set => gender = value; }
        internal COLOREYES Eyes { get => eyes; set => eyes = value; }

        public override string? ToString()
        {
            return $"№{Number} Class {Class1} from {Iss.ToShortDateString()} to {Exp.ToShortDateString()}. {Name}, {Gender} Date of birth ({Dob.ToShortDateString()}). Address {Address}. Height {Height}. Eyes {Eyes}. " +
                $"{(Donor ? "Donor": "Not Donor")}";
        }
    }
}
