using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ukol3
{
    internal class Program
    {
        /// <summary>
        /// Kontroluje, zda hráč vyhrál vytvořením řady 3 symbolů v libovolném směru.
        /// </summary>
        static bool Vyhra(Dictionary<Point, char> piskvorky, char hrac, Point lastMove)
        {
            int rada = 0;
            int j = 0;

            // Kontrola vodorovně (řádek)
            rada = 1;
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X + j, lastMove.Y)) && piskvorky[new Point(lastMove.X + j, lastMove.Y)] == hrac) rada++;
                else break;
            }
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X - j, lastMove.Y)) && piskvorky[new Point(lastMove.X - j, lastMove.Y)] == hrac) rada++;
                else break;
            }
            if(rada>=3) { return true; }

            // Kontrola svisle (sloupec)
            rada = 1;
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X, lastMove.Y + j)) && piskvorky[new Point(lastMove.X, lastMove.Y + j)] == hrac) rada++;
                else break;
            }
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X, lastMove.Y - j)) && piskvorky[new Point(lastMove.X, lastMove.Y - j)] == hrac) rada++;
                else break;
            }
            if (rada >= 3) { return true; }

            // Kontrola hlavní diagonály (\)
            rada = 1;
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X + j, lastMove.Y + j)) && piskvorky[new Point(lastMove.X + j, lastMove.Y + j)] == hrac) rada++;
                else break;
            }
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X - j, lastMove.Y - j)) && piskvorky[new Point(lastMove.X - j, lastMove.Y - j)] == hrac) rada++;
                else break;
            }
            if (rada >= 3) { return true; }

            // Kontrola vedlejší diagonály (/)
            rada = 1;
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X + j, lastMove.Y - j)) && piskvorky[new Point(lastMove.X + j, lastMove.Y - j)] == hrac) rada++;
                else break;
            }
            j = 0;
            while (true)
            {
                j++;
                if (piskvorky.ContainsKey(new Point(lastMove.X - j, lastMove.Y + j)) && piskvorky[new Point(lastMove.X - j, lastMove.Y + j)] == hrac) rada++;
                else break;
            }
            if (rada >= 3) return true;

            return false;
        }

        /// <summary>
        /// Vykreslí herní pole o velikosti 21x21 na základě aktuálního posunu (X, Y).
        /// </summary>
        static void PrintBoard(Dictionary<Point, char> piskvorky, int xI, int yI, char hrac)
        {
            for (int y = yI; y < 21 + yI; y++)
            {
                for (int x = xI; x < 21 + xI; x++)
                {
                    Point p = new Point(x, y);
                    if (piskvorky.ContainsKey(p))
                    {
                        Console.ForegroundColor = (piskvorky[p] == 'X') ? ConsoleColor.Blue : ConsoleColor.Yellow;
                        Console.Write(piskvorky[p] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            
            // Indikátor aktuálního hráče uprostřed pod polem
            Console.SetCursorPosition(20, 22);
            Console.Write("Hráč na tahu: ");
            Console.ForegroundColor = (hrac == 'X') ? ConsoleColor.Blue : ConsoleColor.Yellow;
            Console.WriteLine(hrac);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            Dictionary<Point, char> piskvorky = new Dictionary<Point, char>();
            bool vyhra = false;
            int x = 0; // Aktuální souřadnice pohledu
            int y = 0;
            ConsoleKeyInfo key;

            int hracNaTahu = 0;
            char[] hraciSymboli = {'X','O'};

            Console.WriteLine("Piškvorky v konzoli! Ovládání: Šipky (posun pole), ENTER (položit symbol).");
            Console.WriteLine("Cíl: Vytvořit řadu 3 symbolů.");
            Console.ReadKey();

            while (!vyhra)
            {
                while (true)
                {
                    Console.Clear();
                    PrintBoard(piskvorky, x, y, hraciSymboli[hracNaTahu]);
                    key = Console.ReadKey(true);

                    // Pohyb po nekonečném poli
                    if (key.Key == ConsoleKey.UpArrow) y--;
                    else if (key.Key == ConsoleKey.DownArrow) y++;
                    else if (key.Key == ConsoleKey.LeftArrow) x--;
                    else if (key.Key == ConsoleKey.RightArrow) x++; 
                    
                    // Umístění symbolu na pozici (x+10, y+10) - střed aktuálního pohledu
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Point souradnice = new Point(x + 10, y + 10);
                        if (!piskvorky.ContainsKey(souradnice))
                        {
                            piskvorky.Add(souradnice, hraciSymboli[hracNaTahu]);
                            vyhra = Vyhra(piskvorky, hraciSymboli[hracNaTahu], souradnice);
                            
                            if (vyhra)
                            {
                                Console.Clear();
                                PrintBoard(piskvorky, x, y, hraciSymboli[hracNaTahu]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nHráč {hraciSymboli[hracNaTahu]} vyhrál!");
                                Console.ReadKey();
                            }
                            break; // Končí tah aktuálního hráče
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 24);
                            Console.WriteLine("Pole je již obsazené! Stiskni libovolnou klávesu...");
                            Console.ReadKey(true);
                        }
                    }
                }
                hracNaTahu = (hracNaTahu + 1) % 2;
            }
        }
    }
}

