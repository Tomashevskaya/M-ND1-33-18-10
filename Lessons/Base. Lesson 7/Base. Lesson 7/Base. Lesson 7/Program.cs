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
            //Sturcture();
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
            var letterTemplate = new Letter(' ', new char[4, 4]{
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' },
                { ' ', ' ', ' ', ' ' }
            });

            var o = new Letter('о', new char[4, 4]{
                { ' ', ' ', ' ', ' ' },
                { ' ', '/', '\\', ' ' },
                { '|', ' ', '|', ' ' },
                { ' ', '\\', '/', ' ' }
            });

            var l = new Letter('л', new char[4, 4]{
                { ' ', '_', '_', ' ' },
                { ' ','|', ' ', '|' },
                { ' ','|', ' ', '|' },
                { '/',' ', ' ', '|' }
            });

            var ya = new Letter('я', new char[4, 4]{
                { ' ', '_', '_', ' ' },
                { ' ','|', ' ', '|' },
                { ' ','|', '_', '|' },
                { ' ',' ', '/', '|' }
            });

            Letter[] alphebet = new Letter[]
            {
                o, l, ya
            };

            var word = Console.ReadLine();
            var pseudoLetters = new List<Letter>();

            for (int i = 0; i < word.Length; i++)
            {
                var letter = word[i];
                for (int j = 0; j < alphebet.Length; j++)
                {
                    if (alphebet[j].letterName == letter)
                    {
                        pseudoLetters.Add(alphebet[j]);
                    }
                }
            }

            writeLetters(pseudoLetters.ToArray());            
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
        public char letterName;

        public Letter(char letterName, char[,] graphics)
        {
            this.graphics = graphics;
            this.letterName = letterName;
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
