using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Enigma
{
    class Program
    {
        // main function
        static void Main(string[] args)
        {
            // ROTORS
            string[] rotorArray = { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "VZBRGITYUPSDNHLXAWMJQOFECK" };
            rotorArray[0] = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
            rotorArray[1] = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            rotorArray[2] = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
            rotorArray[3] = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
            rotorArray[4] = "VZBRGITYUPSDNHLXAWMJQOFECK";

            char[] notches = { 'Q', 'E', 'V', 'J', 'Z' };


            // reflector
            Reflector r = new Reflector();

            // plugboRD
            Plugboard p = new Plugboard();
            do
            {
                try
                {
                    // INPUT FROM USER
                    string input;
                    do
                    {
                        int ring1 = 0, ring2 = 0, ring3 = 0, of1 = 0, of2 = 0, of3 = 0, r1 = 0, r2 = 0, r3 = 0;

                        Console.WriteLine("**********************************");
                        Console.WriteLine("please, choose your action:");
                        Console.WriteLine("[1] Dycrypt OR Encrypt");
                        Console.WriteLine("[2] Quit.");
                        Console.WriteLine("**********************************");


                        input = Console.ReadLine();

                        if (input == "1")
                        {
                            //-------------------------------------------------------------------------------
                            // get plugboard from user
                            //-------------------------------------------------------------------------------
                            int flag = 0;
                            char[] ar;
                            do
                            {
                                Console.WriteLine("Please enter plugboard: (format of: AB CD EF) ");
                                ar = Console.ReadLine().ToUpper().ToCharArray();
                                if (checkplugboard(ar) != false)
                                {
                                    flag = 1;
                                    p.setPlugboard(ar);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("wrong input.");
                                }

                            } while (flag == 0);

                            //-------------------------------------------------------------------------------
                            //get rotors
                            //-------------------------------------------------------------------------------
                            flag = 0;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Please enter rotors: (format of 1-2-3 OR 5-4-3)");
                                    string rotors = Console.ReadLine();
                                    r1 = rotors[0] - 49;
                                    r2 = rotors[2] - 49;
                                    r3 = rotors[4] - 49;
                                    flag = 1;
                                }
                                catch (System.IndexOutOfRangeException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                                catch (System.IO.IOException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                            } while (flag == 0);
                            //-------------------------------------------------------------------------------
                            //get offset
                            //-------------------------------------------------------------------------------
                            flag = 0;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Please enter offset: (format of 01-20-13 OR 02-13-25)");
                                    string offsets = Console.ReadLine();
                                    of1 = (offsets[0] - 48) * 10 + (offsets[1] - 48) - 1;
                                    of2 = (offsets[3] - 48) * 10 + (offsets[4] - 48) - 1;
                                    of3 = (offsets[6] - 48) * 10 + (offsets[7] - 48) - 1;
                                    flag = 1;
                                }
                                catch (System.IndexOutOfRangeException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                                catch (System.IO.IOException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                            } while (flag == 0);


                            //-------------------------------------------------------------------------------
                            //get ring setting
                            //-------------------------------------------------------------------------------
                            flag = 0;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Please enter ring settings: (format of 01-20-13 OR 02-13-25)");
                                    string ringsettings = Console.ReadLine();
                                    ring1 = (ringsettings[0] - 48) * 10 + (ringsettings[1] - 48) - 1;
                                    ring2 = (ringsettings[3] - 48) * 10 + (ringsettings[4] - 48) - 1;
                                    ring3 = (ringsettings[6] - 48) * 10 + (ringsettings[7] - 48) - 1;
                                    flag = 1;
                                }
                                catch (System.IndexOutOfRangeException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                                catch (System.IO.IOException) { Console.WriteLine(); Console.WriteLine("wrong input."); }
                            } while (flag == 0);

                            //-------------------------------------------------------------------------------
                            //get notch
                            //-------------------------------------------------------------------------------


                            Rotor ro1 = new Rotor(of1, ring1, notches[r1], rotorArray[r1]);
                            Rotor ro2 = new Rotor(of2, ring2, notches[r2], rotorArray[r2]);
                            Rotor ro3 = new Rotor(of3, ring3, notches[r3], rotorArray[r3]);

                            Enigma e = new Enigma(ro3, ro2, ro1, p, r);
                            Console.WriteLine("Please enter the message:");
                            string str = Console.ReadLine().ToUpper();

                            Console.WriteLine("************* OUTPUT *************");

                            for (int i = 0; i < str.Length; i++)
                            {
                                if (str[i] == ' ')
                                {
                                    continue;
                                }
                                else
                                    Console.Write(e.RunEnigma(str[i]));

                            }
                            Console.WriteLine();
                            Console.WriteLine("**********************************");
                            Console.WriteLine("PRESS ENTER TO CONTINEU.");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("**********************************");
                            Console.WriteLine("**********************************");
                            Console.WriteLine("Last runnig enigma settings are:");
                            Console.WriteLine("Rotors: " + (r1 + 1) + "-" + (r2 + 1) + "-" + (r3 + 1) + ".");
                            Console.WriteLine("Plugboard: " + new string(ar));
                            Console.WriteLine("Offset: " + (ro1.getOffset() + 1) + "-" + (ro2.getOffset() + 1) + "-" + (ro3.getOffset() + 1) + ".");
                            Console.WriteLine("Ring settings: " + (ring1 + 1) + "-" + (ring2 + 1) + "-" + (ring3 + 1) + ".");
                            Console.WriteLine("**********************************");
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("see ya.");
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("wrong input..");
                        }
                    } while (input != "0");

                    //  performance();
                }
                catch (System.IO.IOException)
                {
                    Console.Clear();
                    Console.WriteLine("wrong input.");
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("wrong input.");
                }
            } while (true);


            // performance();

        }

        // testing function
        static public bool checkplugboard(char[] arr)
        {
            // more then 10 pairs
            if (arr.Length > 29)
                return false;
            // check if we got anly letters
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] < 65 || arr[i] > 91) && arr[i] != ' ')
                    return false;
                if (i % 3 == 2 && arr[i] != ' ')
                    return false;
            }
            return true;
        }

        // function to run performance tests
        static public void performance()
        {
            // ROTORS
            string[] rotorArray = { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "VZBRGITYUPSDNHLXAWMJQOFECK" };
            rotorArray[0] = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
            rotorArray[1] = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            rotorArray[2] = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
            rotorArray[3] = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
            rotorArray[4] = "VZBRGITYUPSDNHLXAWMJQOFECK";

            char[] notches = { 'Q', 'E', 'V', 'J', 'Z' };


            // reflector
            Reflector r = new Reflector();

            // plugboRD
            Plugboard p = new Plugboard();
            string plug = "ZU HL CQ WM OA PY EB TR DN VI";

            char[] ar = plug.ToCharArray();


            //-------------------------------------------------------------------------------
            //get rotors
            //-------------------------------------------------------------------------------
            int n = 0;
            while (n < 1000)
            {
                Random rnd = new Random();
                int r1, r2, r3;
                int of1, of2, of3;
                int ri1, ri2, ri3;
                do
                {
                    r1 = rnd.Next(5);
                    r2 = rnd.Next(5);
                    r3 = rnd.Next(5);
                } while (r1 == r2 || r2 == r3 || r1 == r3);

                //-------------------------------------------------------------------------------
                //get offset
                //-------------------------------------------------------------------------------

                do
                {
                    of1 = rnd.Next(26);
                    of2 = rnd.Next(26);
                    of3 = rnd.Next(26);
                } while (of1 == of2 || of2 == of3 || of1 == of3);


                //-------------------------------------------------------------------------------
                //get ring setting
                //-------------------------------------------------------------------------------
                do
                {
                    ri1 = rnd.Next(26);
                    ri2 = rnd.Next(26);
                    ri3 = rnd.Next(26);
                } while (ri1 == ri2 || ri2 == ri3 || ri1 == ri3);


                //-------------------------------------------------------------------------------
                //get notch
                //-------------------------------------------------------------------------------


                Rotor ro1 = new Rotor(of1, ri1, notches[r1], rotorArray[r1]);
                Rotor ro2 = new Rotor(of2, ri2, notches[r2], rotorArray[r2]);
                Rotor ro3 = new Rotor(of3, ri3, notches[r3], rotorArray[r3]);

                Enigma e = new Enigma(ro3, ro2, ro1, p, r);
                string str = "UMDPQCUAQNLVVSPIARKCTTRJQKCFPTOKRGOZXALDRLPUHAUZSOSZFSUGWFNFDZCUGVEXUULQYXOTCYRPSYGGZHQMAGPZDKCKGOJMMYYDDH";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        continue;
                    }
                    else
                        //Console.Write(e.RunEnigma(str[i]));
                       e.RunEnigma(str[i]);

                }
                Console.WriteLine();
                n++;
            }
        }


    }
}