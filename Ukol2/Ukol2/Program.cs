using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukol2
{
    /// <summary>
    /// Třída pro správu a generování hesla.
    /// </summary>
    internal class heslo
    {
        public string hesloText { get; set; }

        public heslo()
        {
            hesloText = "";
        }

        /// <summary>
        /// Vygeneruje náhodné heslo složené ze 4 unikátních speciálních znaků.
        /// </summary>
        public void GenerujHeslo()
        {
            hesloText = "";
            Random rnd = new Random();
            string[] specialniZnaky = { "@", "#", "&", "~", "*" };

            for (int i = 0; i < 4; i++)
            {
                int cislo = rnd.Next(0, 5);
                // Zajištění, aby se znaky v hesle neopakovaly
                if(hesloText.Any(s => s.ToString() == specialniZnaky[cislo]))
                {
                    i--;
                    continue;
                }
                hesloText += specialniZnaky[cislo];
            }

            // Pro testovací účely vypíše vygenerované heslo (v reálné hře by mělo být skryté)
            // Console.WriteLine("Vygenerované heslo: " + hesloText); 
        }

        /// <summary>
        /// Vrátí index znaku v hesle, nebo -1 pokud se tam nenachází.
        /// </summary>
        public int PoziceZnaku(string znak)
        {
            for (int i = 0; i < hesloText.Length; i++)
            {
                if (hesloText[i].ToString() == znak)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            heslo _Heslo = new heslo();
            string typnuteHeslo = "";

            _Heslo.GenerujHeslo();
            Console.WriteLine("Hádejte heslo složené ze 4 speciálních znaků (@, #, &, ~, *) v libovolném pořadí.");
            Console.WriteLine("Barvy: Zelená = správný znak na správném místě, Žlutá = správný znak na špatném místě, Červená = znak v hesle není.");

            while (true)
            {
                // Kontrola výhry
                if(_Heslo.hesloText == typnuteHeslo)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nGratuluji! Uhodl jsi heslo.");
                    break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Zadejte tip (4 znaky): ");
                typnuteHeslo = Console.ReadLine();

                // Základní kontrola délky vstupu
                if (string.IsNullOrEmpty(typnuteHeslo) || typnuteHeslo.Length < 4) continue;

                for(int i = 0; i < 4; i++)
                {
                    int pos = _Heslo.PoziceZnaku(typnuteHeslo[i].ToString());

                    if (pos == -1)
                    {
                        // Znak v hesle vůbec není
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(typnuteHeslo[i]);
                    }
                    else if (pos == i)
                    {
                        // Znak je na správné pozici
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(typnuteHeslo[i]);
                    }
                    else
                    {
                        // Znak v hesle je, ale jinde
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(typnuteHeslo[i]);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

