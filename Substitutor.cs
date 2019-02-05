//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Enigma
//{
//    abstract class Substitutor
//    {

//       // public string PlugBoard = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


//        public string AB = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


//        ////Rorors
//        //public string I = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
//        //public string II = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
//        //public string III = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
//        //public string IV = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
//        //public string V = "VZBRGITYUPSDNHLXAWMJQOFECK";

//        ////Reflector
//        public string B = "YRUHQSLDPXNGOKMIEBFZCWVJAT";

//        //Turnover notch
//        public int TN1 = 17;   //Q → R
//        public int TN2 = 5;    //E → F
//        public int TN3 = 22;   //V → W
//        public int TN4 = 10;   //J → K
//        public int TN5 = 26;   //Z → A

//        ////OFFSET
//        //public int Offset1;
//        //public int Offset2;
//        //public int Offset3;

//        ////Ring SETTING
//        //public int Ring1;
//        //public int Ring2;
//        //public int Ring3;


//        // public abstract int LetterToIndex(char c);
//        //public abstract char IndexToLetter(int i);
//        // public abstract char Reverse(string Rotor, char c);
//        //public abstract string revers(string rotor);




//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    abstract class Substitutor
    {
        
        public string AB = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        ////Reflector
        public string B = "YRUHQSLDPXNGOKMIEBFZCWVJAT";

        

    }
}
