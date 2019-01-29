using System;
using System.Collections.Generic;

namespace DIS_A1
{
    class Program
    {
        public static void Main()
        {
            int a = 15, b = 25;
            printPrimeNumbers(a, b);

            int n1 = 5;
            Console.WriteLine("\nThe sum of the series is: " + roundUp(getSeriesResult(n1), 2));


            long n2 = 450;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("\nBinary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 111100000;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("\nDecimal conversion of the binary number " + n3 + " is: " + r3);


            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            Console.ReadKey();

            // write your self-reflection here as a comment
            /* Learning from the assignment
             * -> Getting familiar with the Visual Studio IDE      
             * -> Revising the data structures, syntax and its usage
             * -> Using predefined methods for the ease of programming like decimal.Round(decimal, places)
             * -> Categorizing logic into independent stand-alone generic methods which have a dedicated functionality
             * -> Using recursive methods
             * -> Handling the corner cases for efficient error free programming
            */

        }

        /* This method will print all the prime numbers within a given range */
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                int count = 0;
                List<int> primeList = new List<int>();
                for (int i = x; i <= y; i++)
                {
                    // If the number is prime, increment the count and add it the prime numbers list.
                    if (isPrime(i))
                    {
                        count++;
                        primeList.Add(i);
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("\nThere are no prime numbers between " + x + " and " + y + ".");
                }
                else
                {
                    Console.WriteLine("\nPrime numbers between " + x + " and " + y + " are: " + String.Join(", ", primeList));
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        /* This method will check if the given number is prime or not */
        public static Boolean isPrime(int n)
        {
            // Corner case 
            if (n <= 1)
                return false;

            // Check from 2 to n-1 
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        /* This method will compute the result of the series upto n elements. */
        public static double getSeriesResult(int n)
        {
            try
            {
                // corner case for 0 elements
                if (n == 0)
                {
                    return 0;
                }
                double result = 0;
                for (int i = 1; i <= n; i++)
                {
                    // every even element is negative and odd number is positive
                    if (i % 2 == 0)
                    {
                        result = result - (computeFactorial(i) / (double)(i + 1));
                    }
                    else
                    {
                        result = result + (computeFactorial(i) / (double)(i + 1));
                    }
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        /* This method will compute the factorial of a given number
         * n! = n * (n-1) * ... 2 * 1 */
        public static int computeFactorial(int n)
        {
            // corner case for n = 0 as 0! = 1.
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (n * computeFactorial(n - 1));
            }
        }

        /* This method will round up the decimal upto the desired places. */
        public static decimal roundUp(double input, int places)
        {
            decimal d = (decimal)input;
            return decimal.Round(d, places);
        }

        /* This method will covert a number from decimal (base 10) to binary (base 2)*/
        public static long decimalToBinary(long quotient)
        {
            try
            {
                // Divide the number by 2.
                // Get the integer quotient for the next iteration.
                // Get the remainder for the binary digit.
                // Repeat the steps until the quotient is equal to 0

                string binaryResult = string.Empty;
                long remainder = 0;
                while (quotient > 0)
                {
                    remainder = quotient % 2;
                    quotient = quotient / 2;
                    binaryResult = remainder.ToString() + binaryResult;
                }
                // converting string to long
                return Convert.ToInt64(binaryResult);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        /* This method will convert a number from binary (base 2) to decimal (base 10) */
        public static long binaryToDecimal(long n)
        {
            try
            {
                // 1) Start from the rightmost bit to the left.
                // 2) Multiply each bit by 2^i where i starts from 0 and increases by 1 on iteration.
                // 3) Add all the computations for the result.

                long remainder, baseValue = 1, decimalResult = 0;
                while (n > 0)
                {
                    // %10 will give the rightmost bit of the number
                    remainder = n % 10;
                    // Multiply the rightmost bit with the base value and add it to the result
                    decimalResult = decimalResult + (remainder * baseValue);
                    // Dividing the number from 10 will remove the rightmost bit which is already used
                    n = n / 10;
                    baseValue = baseValue * 2;
                }
                return decimalResult;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        /* This method will print a triangle of cone shape having n rows */
        public static void printTriangle(int n)
        {
            try
            {
                Console.WriteLine("\nTriangle of " + n + " rows:");
                // outer loop to handle number of rows. n in this case
                for (int i = 0; i < n; i++)
                {

                    // inner loop to handle number spaces 
                    // values changing acc. to requirement 
                    for (int j = n - i; j > 1; j--)
                    {
                        // printing spaces 
                        Console.Write(" ");
                    }

                    //  inner loop to handle number of columns 
                    //  values changing acc. to outer loop 
                    for (int j = 0; j <= i; j++)
                    {
                        // printing stars 
                        Console.Write("* ");
                    }

                    // ending line after each row 
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        /* This method will compute the frequency of all the elements in the given 1-D array */
        public static void computeFrequency(int[] a)
        {
            try
            {
                Console.WriteLine("\nArray: {" + string.Join(",", a) + "}");
                Console.WriteLine("Number Frequency");
                for (int i = 0; i < a.Length; i++)
                {
                    // look to the left in the array if the number was used before
                    int found = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (a[i] == a[j])
                        {
                            found++;
                        }
                    }

                    // continue if it's the first occurance
                    if (found == 0)
                    {
                        // there is always going to be one occurance
                        int count = 1;

                        // look to the right in the array for other occurances
                        for (int j = i + 1; j < a.Length; j++)
                        {
                            if (a[i] == a[j]) count++;
                        }
                        Console.WriteLine(a[i] + "      " + count);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
    }
}
