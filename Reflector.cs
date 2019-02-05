using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Reflector : Translator
    {
        private string reflector;

        // constructor
        public Reflector()
        {
            reflector = B;
        }

        // return the corresponding char for an inout
        public char GetReflector(char input)
        {
            int index = LetterToIndex(input);
            return reflector[index - 1];
        }
       
    }
}
