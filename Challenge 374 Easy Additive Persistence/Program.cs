using System;

namespace Challenge_374_Easy_Additive_Persistence
{
    class Program
    {
        private static int Iterations = 0;

        /// <summary>
        /// Part 1: Call a recursive method to calculate the additive persistance of the 4 challenge numbers
        /// Part 2: Golf Code
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Long Code
            int[] InputArray = new int[4] { 9876, 13, 1234, 199 };
            //For each challenge number call the GetAdditiveIterations method passing it the challenge number
            //After the additive persistance has been calculated print the number of iterations required then reset the iterations for the next challenge number
            foreach (var item in InputArray)
            {
                GetAdditiveIterations(item);
                Console.WriteLine(Iterations);
                Iterations = 0;
            }
            #endregion


            Console.WriteLine();


            #region Golf Code
            foreach (var item in InputArray)
            {
                Iterations = 0;
                long n = item, Sum;
                //While the number is greater than 9. This is for after the numbers have been summed, if the number can still be further summed this will be true.
                while (n > 9)
                {
                    Sum = 0;
                    //While n > 9 keep looping. Sum each digit in the number then divide by 10 each time to get the next digit.
                    //Ex. 9876 mod 10 = 6. Set n = 987 by dividing by 10. This is done so the next digit can be found the next time.
                    //Sum += 6 the first time, 7 the second time, 8 the third time and 9 the forth time. Sum = 30, Return to the earlier while loop to sum 30.
                    while (n > 9)
                    { Sum += n % 10; n /= 10; }  
                    //This is added later because the while loop hits less then 9 but doesn't add the last value.
                    Sum += n;
                    //Set n equal to the sum so that the number can be broken down further if applicible
                    n = Sum;
                    Iterations++;
                }
                Console.WriteLine(Iterations);
            }
            #endregion
            Console.Read();
        }


        /// <summary>
        /// Recursive method that gets the sum of the number passed 
        /// </summary>
        /// <param name="n">Number passed</param>
        /// <returns>Number of iterations</returns>
        private static int GetAdditiveIterations(Int64 n)
        {
            //If number of iterations is less than 9 meaning the number cannot further be summed, return the number of times this method ran
            if (n <= 9)
                return Iterations;

            Iterations++;
            //Call the method that will break down the number to the sum of its digits.
            Int64 NumberSum = GetSum(n);
            //If it made it this far call itself again to see if the number is not unable to be furter summed
            return GetAdditiveIterations(NumberSum);

        }

        /// <summary>
        /// Get the sum of the passed number
        /// </summary>
        /// <param name="n">The Number to sum</param>
        /// <returns>The Sum</returns>
        private static long GetSum(long n)
        {
            //Ex n = 9876.
            long AddNumbers = 0;
            //While the passed number can still be summed.

            while (n > 9)
            {
                //Sum each digit. 9876%10 =  6
                AddNumbers += (n % 10);
                //Break the number down further so all of its digits can be summed. 9876/10 = 987
                n /= 10;
                //Sum after first run would be 6 and the new number would be 987.
            }
            //The last digit is not summed in the while loop above, this adds it to the sum and returns the sum of the passed number
            return AddNumbers + n;
        }
    }
}
