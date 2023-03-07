using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruc_MP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declarations
            int num = 1; // if 8 goes through the detector we should get that 8 is not a prime number
            // 136
            // 16
            string outputMessage = "";
            int srtX = 0;
            bool isPrime = false;
            int pCount = 0;
            int[] primeStorage = new int[10];
            bool isNum = false;

            //// geting the use input using just parse
            //while(true)
            //{
            //    Console.Write("Please enter a number where I will start looking for prime numbers : ");
            //    try
            //    {
            //        num = int.Parse(Console.ReadLine());
            //        if (num > 0)
            //            break;
            //    }
            //    catch(Exception e) 
            //    {
            //    }
            //}

            // getting user input using tryParse
            do
            {
                Console.Write("Please enter a number where I will start looking for prime numbers : ");
                isNum = int.TryParse(Console.ReadLine(), out num);
                if (isNum && num <= 0)
                    isNum = false;
            } while (!isNum);

            // searching part
            while(pCount < primeStorage.Length)
            {
                if (num >= 0 && num < 2)
                {
                    isPrime = false;
                    outputMessage = num + " is not a prime number";
                }
                else if (num == 2)
                {
                    isPrime = true;
                    outputMessage = num + " is a prime number";
                }
                else
                {
                    // thing that detects if a number is prime or not
                    // For a number to be prime, the number has to be only multiplied by 1 and itself.
                    // To search if a number is prime you may check, assuming that the number is x,
                    // if the number is divisible from 2 to the square root of x.
                    // Note: 0 and 1 are not prime numbers, 2 is.
                    //srtX = (int)Math.Sqrt(num); // this operates at the same principle as Math.Floor
                    srtX = (int)Math.Ceiling(Math.Sqrt(num));

                    outputMessage = num + " is a prime number";
                    isPrime = true;

                    for (int x = 2; x <= srtX; x++)
                    {
                        if (num % x == 0)
                        {
                            outputMessage = num + " is not a prime number";
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    primeStorage[pCount] = num;
                    pCount++;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(outputMessage);
                num++;
            }

            Console.WriteLine();
            // displaying the content of Prime Storage
            foreach (int p in primeStorage)
                Console.WriteLine(p);

            Console.WriteLine();
            // displaying the content of prime storage in descending order
            for (int x = primeStorage.Length - 1; x >= 0; x--)
                Console.WriteLine(primeStorage[x]);

            Console.ReadKey();
        }
    }
}
