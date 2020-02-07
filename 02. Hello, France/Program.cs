using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Hello__France
{
    class Program
    {
        static void Main()
        {
            List<string> ListAndPriceItems = Console.ReadLine().Split("|").ToList();
            double budget = double.Parse(Console.ReadLine());
            double startBuget = budget;

            List<double> newPriceList = new List<double>();
            List<double> oldPriceList = new List<double>();

            for (int i = 0; i < ListAndPriceItems.Count; i++)
            {
                List<string> currProductAndPrice = ListAndPriceItems[i].Split("->").ToList();
                string currName = currProductAndPrice[0];
                double currPrice = double.Parse(currProductAndPrice[1]);

                if (currName == "Clothes" && currPrice > 50.00 || currName == "Shoes" && currPrice > 35.00 || currName == "Accessories" && currPrice > 20.50)
                {
                    continue;
                }

                if (currPrice <= budget)
                {
                    budget -= currPrice;
                    oldPriceList.Add(currPrice);
                    currPrice *= 1.4;
                    newPriceList.Add(currPrice);
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < newPriceList.Count; i++)
            {
                Console.Write($"{newPriceList[i]:F2}");

                if (i != newPriceList.Count - 1)
                {
                    Console.Write($" ");
                }
            }

            double profit = newPriceList.Sum() - oldPriceList.Sum();
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:F2}");

            if (profit + startBuget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
