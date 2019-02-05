using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Enigma
{
    class Translator : Substitutor
    {
        // translate letter to an int
        public int LetterToIndex(char c)
        {
            return c - 64;
        }

        // translate an int to a letter
        public char IndexToLetter(int i)
        {
            return (char)(i + 65);
        }

        //Auxiliary function to revers function
        public char Reverse(string Rotor, char c)
        {

            for (int i = 0; i < 26; i++)
            {
                if (Rotor[i] == c)
                    return (char)(i + 65);
            }
            return '#';
        }

        // reverse function that return the revers for a rotor
        public string revers(string rotor)
        {
            char[] rvs = new char[26];

            for (int i = 0; i < 26; i++)
            {
                int index = LetterToIndex(rotor[i]) - 1;
                char a = Reverse(rotor, rotor[i]);
                rvs[index] = a;
            }
            string S = new string(rvs);
            return S;
        }
    }
}
