using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Return_Algorithm
{
    class Program
    {
        static Random rnd = new Random();
        static int[] returnableUnits = new int[10]{ 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
        static void Main(string[] args)
        {
            Console.WriteLine("[Enter 'exit' to leave.]");
            string input;
            int paymentAmount = rnd.Next(1, 200);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Pay the amount {paymentAmount}");
                Console.Write("Payment: ");
                input = Console.ReadLine();
                int intInput;
                if (int.TryParse(input, out intInput))
                {
                    if (intInput < paymentAmount)
                    {
                        Console.WriteLine("  !!Entered sum must be bigger than the amount to pay!!");
                    }
                    else//learnin to code 
                    {
                        int[] amounts = GetReturnsRecursive(intInput, paymentAmount);

                        // Add formated resuts into list of strings
                        List<string> l = new List<string>();
                        int sum = 0;
                        for (int i = 0; i < amounts.Length; i++)
                        {
                            if (amounts[i] == 0)
                                continue;
                            sum += amounts[i] * returnableUnits[i];
                            l.Add($"{amounts[i]}x: {returnableUnits[i]}");
                        }
                        // Concatonate results
                        string s = string.Join(" | ", l);
                        Console.WriteLine($"You get back: " + sum);
                        Console.WriteLine(s);

                        //Create new amount to pay
                        paymentAmount = rnd.Next(1, 200);
                    }
                }
                else if( input.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  !!Enter an integer value!!");
                }
            }
        }
        //received money must be bigger than target
        private static int[] GetReturnsRecursive(int receivedMoney, int target)
        {
            int[] memory = new int[returnableUnits.Length];
            int index = returnableUnits.Length-1;
            return _GetReturnsRecursive(receivedMoney, target, memory, index);
        }
        private static int[] _GetReturnsRecursive(int receivedMoney, int target, int[] memory, int index)
        {
            int subtraction = receivedMoney - target;

            if (subtraction == 0)// if we dont give him anything more, leave with the memory of what we give him
                return memory; // LEAVE LOOP

            if (subtraction - returnableUnits[index] >= 0)
            {

                memory[index] += 1; //banknote/coin value is being given to the user
                receivedMoney -= returnableUnits[index];

            }
            else
            {
                index = index - 1;// use smaller banknote/coin
            }

            return _GetReturnsRecursive(receivedMoney, target, memory, index);

        }
        //received money must be bigger than target
        private static int[] GetReturns(int receivedMoney, int target)
        {// WITHOUT RECURSION
            int moneyToGive = receivedMoney - target;
            //return = target - received money
            int[] sums = new int[returnableUnits.Length];
            int backwardsIndex = returnableUnits.Length - 1;

            while (moneyToGive != 0)
            {
                int currentBanknote = returnableUnits[backwardsIndex];
                if (moneyToGive - currentBanknote >= 0)
                {
                    moneyToGive -= currentBanknote;
                    sums[backwardsIndex] += 1;
                }
                else
                {
                    backwardsIndex--;
                }
            }
            return sums;
        }
    }
}
