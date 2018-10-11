using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sturcture();
            LettersExample();

            Console.ReadKey();
        }

        public static void Sturcture()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1;
            coord1.x = 15;
            coord1.y = 15;

        }

        public static void LettersExample()
        {
            var letterTemplate = new Letter(new char[4, 4]{
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' }
            });

            var o = new Letter(new char[4, 4]{
                { ' ', ' ', ' ', ' ' },
                { ' ', '/', '\\', ' ' },
                { '|', ' ', '|', ' ' },
                { ' ', '\\', '/', ' ' }
            });

            var l = new Letter(new char[4, 4]{
                { ' ', '_', '_', ' ' },
                { ' ','|', ' ', '|' },
                { ' ','|', ' ', '|' },
                { '/',' ', ' ', '|' }
            });

            var ya = new Letter(new char[4, 4]{
                { ' ', '_', '_', ' ' },
                { ' ','|', ' ', '|' },
                { ' ','|', '_', '|' },
                { ' ',' ', '/', '|' }
            });

            writeLetters(o, l, ya);            
        }

        public static void writeLetters(params Letter[] word)
        {
            for (int row = 0; row < 4; row++)
            {
                foreach (var letter in word)
                {
                    for (int column = 0; column < 4; column++)
                    {
                        Console.Write(letter.graphics[row, column]);
                    }

                    Console.Write("  ");
                }

                Console.WriteLine();
            }
        }
    }

    struct Letter
    {
        public char[,] graphics;


        public Letter(char[,] graphics)
        {
            this.graphics = graphics;
        }
    }


    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
