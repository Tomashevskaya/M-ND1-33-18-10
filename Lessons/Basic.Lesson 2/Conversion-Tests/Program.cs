using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Olga";
            char sex = 'М';
            bool hasFree2Pages = false;
            decimal visaPrice = 60;
            int birthYear = 2000;


            //1. CHAR CONVERSION 

            //1.1 CHAR to STRING

            //string charToStringImplicit = sex;                        //IMPLICIT: NOT COMPILING
            //string chartToStringExplicit = (string)sex;               //EXPLICIT: NOT COMPILING
            string charToStringUsingConverter = Convert.ToString(sex);  //CONVERT: "M"

            //1.2 CHAR to BOOL
            //bool charToBoolImplicit = sex;                              //IMPLICIT: NOT COMPILING
            //bool charToBoolExplicit = (bool)sex;                        //EXPLICIT: NOT COMPILING
            //bool charToBoolUsingConverter = Convert.ToBoolean(sex);     //CONVERT: NOT COMPILING   InvalidCastException

            //1.3 CHAR to DECIMAL
            decimal charToDecimalImplicit = sex;                              //IMPLICIT:1052
            decimal charToDecimalExplicit = (decimal)sex;                     //EXPLICIT:1052
                                                                              //decimal charToDecimalUsingConverter = Convert.ToDecimal(sex);   //CONVERT: NOT COMPILING   InvalidCastException

            //1.4 CHAR to INT
            int charToIntImplicit = sex;                              //IMPLICIT: 1052
            int charToIntExplicit = (int)sex;                         //EXPLICIT: 1052
            int charToIntUsingConverter = Convert.ToInt32(sex);       //CONVERT: 1052

            //2. STRING CONVERSION

            //2.1 STRING to CHAR
            //Char stringToCharImplicit = name;                            //IMPLICIT: NOT COMPILING
            //Char stringToCharExplicit = (char)name;                      //EXPLICIT: NOT COMPILING
            //Char stringToCharUsingConverter = Convert.ToChar(name);      //CONVERT: NOT COMPILING

            //2.2 STRING to BOOL
            //bool stringToboolImplicit = name;                                 //IMPLICIT: NOT COMPILING
            //bool stringToboolExplicit = (bool)name;                           //EXPLICIT: NOT COMPILING
            //bool stringToBoolUsingConverter = Convert.ToBoolean(name);        //CONVERT: NOT COMPILING

            //2.3 STRING to DECIMAL
            //decimal stringToDecimalImplicit = name;                               //IMPLICIT: NOT COMPILING
            //decimal stringToDecimalExplicit = (decimal)name;                      //EXPLICIT: NOT COMPILING
            //decimal stringToDecimalUsingConverter = Convert.ToDecimal(name);      //CONVERT:  NOT COMPILING 'Входная строка имела неверный формат.'

            //2.4 STRING to INT
            //int stringToIntImplicit = name;                            //IMPLICIT: NOT COMPILING
            //int stringToIntExplicit = (int)name;                        //EXPLICIT: NOT COMPILING
            //int stringToIntUsingConverter = Convert.ToInt32(name);      //CONVERT: NOT COMPILING  'Входная строка имела неверный формат.'

            //3. BOOL CONVERSION

            //3.1 BOOL to CHAR
            //Char boolToCharImplicit = hasFree2Pages;                            //IMPLICIT: NOT COMPILING
            //Char boolToCharExplicit = (char)hasFree2Pages;                      //EXPLICIT: NOT COMPILING
            //Char boolToCharUsingConverter = Convert.ToChar(hasFree2Pages);      //CONVERT: NOT COMPILING InvalidCastException

            //3.2 BOOL to STRING
            //string boolToStringImplicit = hasFree2Pages;                                 //IMPLICIT: NOT COMPILING
            //string boolToStringExplicit = (string)hasFree2Pages;                         //EXPLICIT: NOT COMPILING
            string boolToStringUsingConverter = Convert.ToString(hasFree2Pages);           //CONVERT: False

            //3.3 BOOL to DECIMAL
            // decimal boolToDecimalImplicit = hasFree2Pages;                               //IMPLICIT: NOT COMPILING
            // decimal boolToDecimalExplicit = (decimal)hasFree2Pages;                      //EXPLICIT: NOT COMPILING
            decimal boolToDecimalUsingConverter = Convert.ToDecimal(hasFree2Pages);      //CONVERT:  0 	
            //Преобразует заданное логическое значение в эквивалентное десятичное число.

            //3.4 BOOL to INT
            // int boolToIntImplicit = hasFree2Pages;                            //IMPLICIT: NOT COMPILING
            // int boolToIntExplicit = (int)hasFree2Pages;                       //EXPLICIT: NOT COMPILING
            int boolToIntUsingConverter = Convert.ToInt32(hasFree2Pages);        //CONVERT: 0 
            //Преобразует заданное логическое значение в эквивалентное 32 - битовое целое число со знаком.

            //4. DECIMAL CONVERSION

            //4.1 DECIMAL to CHAR
            // Char decimalToCharImplicit = visaPrice;                            //IMPLICIT: NOT COMPILING
            Char decimalToCharExplicit = (char)visaPrice;                      //EXPLICIT: <  
            //Char decimalToCharUsingConverter = Convert.ToChar(visaPrice);      //CONVERT: NOT COMPILING   InvalidCastException

            //4.2 DECIMAL to BOOL
            //bool decimalToboolImplicit = visaPrice;                                 //IMPLICIT: NOT COMPILING
            //bool decimalToboolExplicit = (bool)visaPrice;                           //EXPLICIT: NOT COMPILING
            bool decimalToBoolUsingConverter = Convert.ToBoolean(visaPrice);        //CONVERT: true

            //4.3 DECIMAL to STRING
            //string decimalToDecimalImplicit = visaPrice;                               //IMPLICIT: NOT COMPILING
            //string decimalToDecimalExplicit = (string)visaPrice;                      //EXPLICIT: NOT COMPILING
            string decimalToDecimalUsingConverter = Convert.ToString(visaPrice);      //CONVERT: 60

            //4.4 DECIMAL to INT
            //int decimalToIntImplicit = visaPrice;                            //IMPLICIT: NOT COMPILING
            int decimalToIntExplicit = (int)visaPrice;                        //EXPLICIT: 60
            int decimalToIntUsingConverter = Convert.ToInt32(visaPrice);      //CONVERT: 60

            //5. INT CONVERSION         

            //5.1 INT to CHAR
            //Char intToCharImplicit = birthYear;                            //IMPLICIT: NOT COMPILING
            Char intToCharExplicit = (char)birthYear;                      //EXPLICIT: ?
            Char intToCharUsingConverter = Convert.ToChar(birthYear);      //CONVERT: ?

            //5.2 INT to BOOL
            //bool intToboolImplicit = birthYear;                                 //IMPLICIT: NOT COMPILING
            //bool intToboolExplicit = (bool)birthYear;                           //EXPLICIT: NOT COMPILING
            bool intToBoolUsingConverter = Convert.ToBoolean(birthYear);        //CONVERT: true

            //5.3 INT to DECIMAL
            decimal intToDecimalImplicit = birthYear;                               //IMPLICIT: 2000
            decimal intToDecimalExplicit = (decimal)birthYear;                      //EXPLICIT: 2000
            decimal intToDecimalUsingConverter = Convert.ToDecimal(birthYear);      //CONVERT:  2000

            //5.4 INT to STRING
            //string intToIntImplicit = birthYear;                            //IMPLICIT: NOT COMPILING
            //string intToIntExplicit = (int)birthYear;                        //EXPLICIT: NOT COMPILING
            string intToIntUsingConverter = Convert.ToString(birthYear);      //CONVERT: 2000

            //Console.WriteLine();
            //Console.ReadLine();

        }
    }
}
