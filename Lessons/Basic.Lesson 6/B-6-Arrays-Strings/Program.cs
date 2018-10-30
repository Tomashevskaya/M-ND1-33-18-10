using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Pyatnashki();
            Console.ReadLine();
        }

        public static void Pyatnashki()
        {
            var numbers = GetInitialValues();
            PrintValues(numbers);
            Play(numbers);

        }

        public static void PoemExample()
        {
            Console.WriteLine("Введите четверостишье");
            string[] poem = new string[4];

            for (int i = 0; i < 4; i++)
            {
                Console.Write(i+1 + ". ");
                poem[i] = Console.ReadLine();
            }

            for (int i = 0; i < poem.Length; i++)
            {
                var row = poem[i];

                var result = row
                    .Replace('о', 'а')
                    .Replace("л", "ль")
                    .Replace("ть", "т");

                Console.WriteLine(result);
            }
        }

        private static int[,] GetInitialValues()
        {
            int[,] arr = new int[4, 4];
            int number = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = number++;
                }
            }

            arr[3, 3] = 0;

            return arr;
        }

        private static void PrintValues(int[,] arr)
        {
            Console.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(String.Format("{0,4}", arr[i, j]));
                }

                Console.WriteLine();
            }
        }

        private static void Play(int[,] arr)
        {
            var zeroI = 3;
            var zeroJ = 3;
            
            while (true)
            {
                var movement = Console.ReadKey().KeyChar;
                var i = zeroI;
                var j = zeroJ;

                switch (movement)
                {
                    case 'a' :
                        j--;
                        break;
                    case 's':
                        i++;
                        break;
                    case 'd':
                        j++;
                        break;
                    case 'w':
                        i--;
                        break;
                    default:
                        break;
                }

                var swap = arr[i, j];
                arr[i, j] = arr[zeroI, zeroJ];
                arr[zeroI, zeroJ] = swap;

                zeroI = i;
                zeroJ = j;

                PrintValues(arr);
            }
        }
    }
}
