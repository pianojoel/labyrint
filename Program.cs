using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Labyrint
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.UTF8;
            
            int size = 4;
            bool quit = false;
            int playerLocationX = 0;
            int playerLocationY = 0;
            int points = 0;
            var rnd = new Random();
            int foodLocationX = rnd.Next(1,size);
            int foodLocationY = rnd.Next(1,size);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                if(playerLocationX == foodLocationX && playerLocationY == foodLocationY)
                {
                    
                    points++;
                    do
                    {
                        foodLocationX = rnd.Next(0, size);
                        foodLocationY = rnd.Next(0, size);
                    }
                    while (foodLocationX == playerLocationX && foodLocationY == playerLocationY);

                }
                Console.Clear();
                Console.WriteLine("Points: " + points);
            for (int a = 0; a < size; a++)
            {

                    DrawHorizontalLine(a, size);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("\u2502");
                        for (int j = 0; j < size; j++)
                        {
                            if (i == 1 && a == playerLocationY && j == playerLocationX)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write(" O ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\u2502");
                                }
                            else if(i == 1 && a == foodLocationY && j == foodLocationX)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" * ");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("\u2502");
                            }
                            else { 
                            Console.Write("   \u2502");
                        }
                    }
                    Console.WriteLine();
                }
            }
                DrawHorizontalLine(size, size);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar == 'x')
            {
                size++;
            }
            if (key.KeyChar == 'z')
                {
                    size--;
                }
            if (key.KeyChar == 'w' && playerLocationY > 0)
                {
                    playerLocationY--;
                }
            if (key.KeyChar == 's' && playerLocationY < size -1)
                {
                    playerLocationY++;
                }
            if (key.KeyChar == 'a' && playerLocationX > 0)
                {
                    playerLocationX--;
                }
            if (key.KeyChar == 'd' && playerLocationX < size -1)
                {
                    playerLocationX++;
                }




                if ( key.KeyChar == 'q')
                {
                    quit = true;
                }
                
        }
            
        while (!quit);
            //Console.ReadKey();
        }

        static void DrawHorizontalLine(int row, int size)
        {
            
            
            //Draw Line
            for (int col = 0; col < size; col++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    if (col > 0 && col < size  && row == 0 && j == 0)
                    {
                        Console.Write("\u252c"); //Upper T
                    }
                    else if (row == 0 && col == 0 && j == 0)
                    {
                        Console.Write("\u250c");
                    }
                    else if(row > 0 && row < size && col == 0 && j == 0)
                    {
                        Console.Write("\u251c");
                    }
                    else if(row == size && col == 0 && j == 0)
                    {
                        Console.Write("\u2514");
                    }
                    else if (row == 0 && col == size - 1 && j == 3)
                    {
                        Console.Write("\u2500\u2510"); // Upper Right Corner
                    }
                    else if(row > 0 && row < size && col > 0 && col < size  && j == 0)
                    {
                        Console.Write("\u253c"); //Middle cross
                    }
                    else if(row > 0 && row < size && col == size -1 && j == 3)
                    {
                        Console.Write("\u2500\u2524"); //Right T
                    }
                    else if (row == size && col > 0 && col < size  && j == 0)
                    {
                        Console.Write("\u2534");
                    }
                    else if(row == size && col == size -1 && j == 3)
                    {
                        Console.Write("\u2500\u2518");
                    }
                    else { 

                    Console.Write("\u2500");
                }
                }


            }
            Console.WriteLine();
        }
    }
}
