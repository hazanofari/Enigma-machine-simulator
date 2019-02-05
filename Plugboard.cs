using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Plugboard : Translator
    {
        //default plugboard
        private string PlugBoard = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // new plugboard
        private char[] arr;

        // constructor
        public Plugboard()
        {
            arr = PlugBoard.ToCharArray();

        }

        // function tat sets the plugboard
        public void setPlugboard(char[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                arr[LetterToIndex(ar[i]) - 1] = ar[++i];
                arr[LetterToIndex(ar[i]) - 1] = ar[i - 1];
                i += 1;
            }
            
        }

        // return plugboard resault for a char
        public char getPlug(char c)
        {
            return arr[LetterToIndex(c) - 1];
        }

        // return the plugboard
        public string getPlugBoard()
        {
            
            return new string(arr);
        }
    }
}