using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Lesson_4._1
{
    class Program
    {
        static void Main(string[] args)
        {

            NumberAkinatorExample();



            Console.ReadLine();
        }

        private static void IfComparisonExample()
        {

        }

        private static void NumberAkinatorExample()
        {
            Console.WriteLine("Загодайте число от 1 до 3.");
            
            //int greaterThen = 1;
            //int lessThen = 5;
            int checkPoint = 3;


            Console.WriteLine($"Это число равно {checkPoint}? 1 - да. 0 - нет.");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine($"Ура! Я выйграл");
            }
            else
            {
                // > 3
                Console.WriteLine($"Это число больше {checkPoint}? 1 - да. 0 - нет.");
                if (Console.ReadLine() == "1")
                {
                    checkPoint++;
                    Console.WriteLine($"Это число {checkPoint}? 1 - да. 0 - нет.");
                    if (Console.ReadLine() == "1")
                    {
                        Console.WriteLine($"Ура! Я выйграл");
                    }
                    else
                    {
                        Console.WriteLine($"Это число {checkPoint++}");
                    }
                }
                //< 3
                else
                {
                    checkPoint--;
                    Console.WriteLine($"Это число {checkPoint}? 1 - да. 0 - нет.");
                    if (Console.ReadLine() == "1")
                    {
                        Console.WriteLine($"Ура! Я выйграл");
                    } 
                    else
                    {
                        Console.WriteLine($"Это число {checkPoint--}");
                    }
                }
            }                
        }

        private static void OddOrEvenExample()
        {
            for (int i = 10; i >= 0; i--)
            {
                if (i % 2 == 0) { Console.WriteLine(i + " is even number"); }
                else { Console.WriteLine(i + " is odd number"); }
            }
        }

        private static void CountLetterAExample()
        {
            int aQuantity = 0;
            Console.WriteLine("Enter some word");
            string str = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    aQuantity++;
                }
            }
            Console.WriteLine("Quantity of a letter a in received word is: {0}.", aQuantity);
        }

        private static void SwitchComparisonExample()
        {
            int y = 2;
            int x = 6;


            switch (y - x)
            {
                case int r when r > 0:
                    Console.WriteLine("y > x");
                    break;

                case int r when r < 0:
                    Console.WriteLine("y < x");
                    break;

                case int r when r == 0:
                    Console.WriteLine("y == x");
                    break;

                default:
                    break;
            }
        }       

        private static void ASWDMovementExample()
        {
            Console.WriteLine(" Enter the symbol");

            string sym = Console.ReadLine();
            char symbol = Convert.ToChar(sym);

            switch (symbol)
            {
                case 'w':
                    Console.WriteLine("\nMove figure up");
                    break;
                case 'a':
                    Console.WriteLine("\nMove figure left");
                    break;
                case 's':
                    Console.WriteLine("\nMove figure down");
                    break;
                case 'd':
                    Console.WriteLine("\nMove figure right");
                    break;
                default:
                    Console.WriteLine("\nIncorrect symbol");
                    break;
            }
        }

        private static void CalcSwitchExample()
        {

            Console.WriteLine("Enter value x:");
            string valx = Console.ReadLine();
            double x = Convert.ToDouble(valx);

            Console.WriteLine("\nEnter value y:");
            string valy = Console.ReadLine();
            double y = Convert.ToDouble(valy);

            Console.WriteLine("\nChoose the operator:");
            string oper = Console.ReadLine();
            char operat = Convert.ToChar(oper);

            double result = 0;

            switch (operat)
            {
                case '+':
                    result = x + y;
                    break;
                case '-':
                    result = x - y;
                    break;
                case '/':
                    result = x / y;
                    break;
                case '*':
                    result = x * y;
                    break;              

            }

            Console.WriteLine($"Answer={ result }");
        }
    }
}
