���using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimReader simReader = new SimReader();
                Console.Clear();
                char input = (char)0;
                while (input != '0')
                {
                    Console.WriteLine("CZYTNIK KART CZIPOWYCH - {0}", simReader.GetReaderName());
                    Console.WriteLine("\t1 - Wyslij komend�� APDU");
                    Console.WriteLine("\t2 - Wy��wietl ksi����k�� telefoniczn��");
                    Console.WriteLine("\t3 - Wy��wietl SMS\n");
                    Console.WriteLine("\t0 - Wyj��cie");
                    input = Console.ReadLine()[0];
                    switch (input)
                    {
                        case '1':
                            Console.WriteLine("Podaj komende APDU: ");
                            string command = Console.ReadLine();
                            simReader.SendApduCommand(command);
                            break;
                        case '2':
                            simReader.ReadPhoneBook();
                            break;
                        case '3':
                            simReader.ReadSMS();
                            break;
                        case '0':
                            return;
                        default:
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
