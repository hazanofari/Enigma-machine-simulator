using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Rotor : Translator
    {
        private int Offset;
        private int RingSet;
        private char Notch;
        private string rotor;
        private string Revrotor;
        private string ROTOR;
        private string REVROTOR;

        //constructor
        public Rotor(int o, int r, char n, string Rotor)
        {
            Offset = o;
            RingSet = r;
            Notch = n;
            rotor = Rotor;
            ROTOR = Rotor;
            Revrotor = revers(Rotor);
            REVROTOR = Revrotor;
        }

        //function that doing the translation the returns the cipher text for forward permutation
        public char translate(char input)
        {
            int num = ((LetterToIndex(input) + Offset - RingSet) - 1) ;
            if (num < 0)
                do { num += 26; } while (num < 0);
            else
                num = num % 26;
            num = (LetterToIndex(rotor[num]) - Offset + RingSet) - 1; // -1 because the array start from 0
            if (num < 0)
                do { num += 26; } while (num < 0);
            else
                num = num % 26;
            return AB[num];
        }

        //function that doing the translation the returns the cipher text for reverse permutation
        public char translateRev(char input)
        {
            int num = ((LetterToIndex(input) + Offset - RingSet) - 1) ;
            if (num < 0)
                do { num += 26; } while (num < 0);
            else
                num = num % 26;
            num = (LetterToIndex(Revrotor[num]) - Offset + RingSet)- 1; // -1 because the array start from 0
            if (num < 0)
                do { num += 26; } while (num < 0);
            else
                num = num % 26;
            return AB[num];
        }

        // functon that return the offset
        public int getOffset()
        {
            return Offset;
        }

        // function that set the offset
        public void setOffset(int o)
        {
            Offset += o;
            Offset = Offset % 26;
        }

        // function that sets the rings settings
        public void setRing(int r)
        {
            RingSet = r;
        }

        // function that return the turnover notch
        public int getNotch()
        {
            return LetterToIndex(Notch);
        }
        
    }
}
