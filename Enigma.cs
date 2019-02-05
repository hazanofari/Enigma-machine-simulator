using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Enigma : Substitutor
    {
        private Rotor Rotor1;
        private Rotor Rotor2;
        private Rotor Rotor3;
        private Plugboard Plugboard;
        private Reflector Reflector;

        // cinstructor
        public Enigma(Rotor R1, Rotor R2, Rotor R3, Plugboard P, Reflector Ref)
        {
            Rotor1 = R1;
            Rotor2 = R2;
            Rotor3 = R3;
            Plugboard = P;
            Reflector = Ref;
        }
       
        // function that returns the reflector
        public Reflector getReflector()
        {
            return Reflector;
        }
       
        // function that executing the translation of a character
        public char RunEnigma(char input)
        {
            Didnotch(Rotor1);
            

            input = Plugboard.getPlug(input);

            input = Rotor1.translate(input);

            input = Rotor2.translate(input);

            input = Rotor3.translate(input);

            input = Reflector.GetReflector(input);

            input = Rotor3.translateRev(input);

            input = Rotor2.translateRev(input);

            input = Rotor1.translateRev(input);

            input = Plugboard.getPlug(input);


            return input;

        }
       
        // function that checkes the turnover notch of the rotors
        void Didnotch(Rotor r)
        {
            if (Rotor1.getOffset() == Rotor1.getNotch() - 1 || Rotor2.getOffset() == Rotor2.getNotch() - 1)
            {
                if (Rotor2.getOffset() == Rotor2.getNotch() - 1)
                {
                    Rotor3.setOffset(1);
                }
                Rotor2.setOffset(1);
            }
            Rotor1.setOffset(1);
        }


    }
}