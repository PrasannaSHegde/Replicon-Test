using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a number to find the Factorial");
                string inputVal = Console.ReadLine();        /**to read input string**/     
                int number=0;
                if (int.TryParse(inputVal, out number))
                {                    
                    if(number>=0)
                    {
                        number = Convert.ToInt16(inputVal);
                        long iterativeFactorial = GetFactorial(number);     /**iterative Function call**/
                        long recursiveFactorial = GetFactorialRecursion(number); /**recursive Function call**/
                        string printFormat = GetOperationsDetails(number);    /**display format function call**/
                        Console.WriteLine("Input=" + number);
                        Console.WriteLine("Factorial is: {0} so Output= {1}", printFormat, iterativeFactorial);
                        Console.WriteLine("Factorial is: {0} so Output= {1}", printFormat, recursiveFactorial);
                        Console.ReadKey();
                    }
                    else 
                    {
                        Console.WriteLine("Input Value should be greater than 0");
                        Console.ReadKey();
                    }                                        
                }
                else
                {
                    Console.WriteLine("Only Integer Values Accepted");
                    Console.ReadKey();
                }
            }
           catch(Exception ex)
            {
                Console.WriteLine("Error while finding factorial");
                Console.ReadKey();
            }                     
        }

        private static long GetFactorial(int num) /**To get the Factorial using Iterative Method**/
        {
                if (num == 0)
                {
                    return 1;
                }

                long fact = 1;

                for (int i = num; i > 1; i--)
                {
                    fact *= i;
                }

                return fact;                    
                              
        }

        private static long GetFactorialRecursion(int num) /**To get the Factorial using Recursive Method**/
         {
                if (num == 0)
                {
                    return 1;
                }
                else
                {
                    return num * GetFactorialRecursion(num - 1);
                }
             
          }

        private static string GetOperationsDetails(int num) /**To print the Operations in format like (3*2*1)**/
        {
            int inputEntered = num;             
            string printFormat = "(" + inputEntered;
                for(int i=inputEntered-1;i>0;i--)
                {
                    printFormat += "*" + i;
                }
            printFormat += ')';
            return printFormat;
        }

    }
}
