using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMOperation.StartOperation();
            Console.ReadLine();
        }
        public static class ATMOperation
        {
            public static void StartOperation()
            {
                try
                {
                    string wantstocontinue;
                    do
                    {
                        Console.WriteLine("Please enter the valid Amount");
                        string inputAmount = Console.ReadLine();
                        if (!string.IsNullOrEmpty(inputAmount))  /**to check the input value is null or not**/
                        {
                            int amountEntered;
                            Int32.TryParse(inputAmount, out amountEntered);
                            CheckInputAmount(amountEntered); /**To check the entered value is multiple of 5**/
                        }
                        else
                        {
                            Console.WriteLine("Please Enter a Valid Amount");
                        }
                        Console.WriteLine("Do you want to continue?(if yes type Yes/yes)");
                        wantstocontinue = Console.ReadLine();
                    } while (!string.IsNullOrEmpty(wantstocontinue) && (wantstocontinue.Equals("Yes") || wantstocontinue.Equals("yes")));

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured While fetching details");

                }
            }
            /*function to check entered amount*/
        private static void CheckInputAmount(int inAmount)
        {
            try
            {
                if (inAmount % 5 != 0)
                {
                    Console.WriteLine("Please Enter a Valid Amount(example:Multiple of 500/100/50/10/5)");
                    return;
                }
                int numOf500 = 0;
                int numOf100 = 0;
                int numOf50 = 0;
                int numOf10 = 0;
                int numOf5 = 0;

                int remfrom500 = 0;
                int remfrom100 = 0;
                int remfrom50 = 0;
                int remfrom10 = 0;

                /*code to cehck 500Rs note details*/
                if (inAmount >= 500)
                {
                    numOf500 = inAmount / 500;/*no. of notes*/
                    remfrom500 = inAmount % 500;/*Remainder*/

                    if (remfrom500 >= 100)
                    {
                        numOf100 = remfrom500 / 100;
                        remfrom100 = remfrom500 % 100;
                        if (remfrom100 >= 50)
                        {
                            numOf50 = remfrom100 / 50;
                            remfrom50 = remfrom100 % 50;
                        }
                        if (remfrom50 >= 10)
                        {
                            numOf10 = remfrom50 / 10;
                            remfrom10 = remfrom50 % 10;
                        }
                        if (remfrom10 >= 5)
                        {
                            numOf5 = remfrom10 / 5;
                        }
                    }
                }
                else if (inAmount >= 100)
                {
                    GetnoteDetailsFor100(inAmount, out numOf100, out numOf50, out numOf10, out numOf5); /*if amount in between 100-499*/
                }
                else if (inAmount >= 50)
                {
                    GetnoteDetailsFor50(inAmount, out numOf50, out numOf10, out numOf5);/*if amount in between 50-99*/
                }
                else if (inAmount >= 10)
                {
                    GetnoteDetailsFor10(inAmount, out numOf10, out numOf5);/*if amount in between 10-49*/
                }
                Console.WriteLine(string.Format("Input Amount: {0}", inAmount)); /*Display note details*/
                Console.WriteLine(string.Format("500 * {0}", numOf500));
                Console.WriteLine(string.Format("100 * {0} ", numOf100));
                Console.WriteLine(string.Format("50 * {0}", numOf50));
                Console.WriteLine(string.Format("10 * {0}", numOf10));
                Console.WriteLine(string.Format("5 * {0}", numOf5));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while Getting not count Details");
            }
        }
            /*function to get 100Rs note details*/
        private static void GetnoteDetailsFor100(int remfrom100, out int noof100, out int noof50, out int noof10, out int noof5)
        {
            int numof5Th = 0;
            int numof50Th = 0;
            int numof100Th = 0;
            int numof10Th = 0;
            int remof100 = 0;
            int remof50 = 0;
            int remof10 = 0;
            try
            {
                if (remfrom100 >= 100)
                {
                    numof100Th = remfrom100 / 100;
                    remof100 = remfrom100 % 100;
                    if (remof100 >= 50)
                    {
                        numof50Th = remof100 / 50;
                        remof50 = remof100 % 50;
                    }

                    if (remof50 >= 10)
                    {
                        numof10Th = remof50 / 10;
                        remof10 = remof50 / 10;
                    }
                    if (remof10 >= 5)
                    {
                        numof5Th = remof10 / 5;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error While fetchinf 100Rs note Details");
            }                
            noof100 = numof100Th;
            noof50 = numof50Th;
            noof10 = numof10Th;
            noof5 = numof5Th;

        }
        /*function to get 50Rs note details*/
        private static void GetnoteDetailsFor50(int remfrom50, out int noof50, out int noof10, out int noof5)
        {
            int numof5Th = 0;
            int numof50Th = 0;
            int numof10Th = 0;
            int remof10 = 0;

            try 
            {
                if (remfrom50 >= 50)
                {
                    numof50Th = remfrom50 / 50;
                    int remof50 = remfrom50 % 50;

                    if (remof50 >= 10)
                    {
                        numof10Th = remof50 / 10;
                        remof10 = remof50 % 10;
                    }
                    if (remof10 >= 5)
                    {
                        numof5Th = remof10 / 5;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error While fetchinf 50Rs note Details");
            }
            noof5 = numof5Th;
            noof10 = numof10Th;
            noof50 = numof50Th;
        }
        /*function to get 10Rs note details*/
        private static void GetnoteDetailsFor10(int remfrom10, out int noof10, out int noof5)
        {
            int numof5Th = 0;
            int numof10Th = 0;
            try
            {
                if (remfrom10 >= 10)
                {
                    numof10Th = remfrom10 / 10;
                    int remof10 = remfrom10 % 10;

                    if (remof10 >= 5)
                    {
                        numof5Th = remof10 / 5;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while fetching 10Rs note Details");
            }
            noof10 = numof10Th;
            noof5 = numof5Th;                 
            }            
        }
    }
 }


