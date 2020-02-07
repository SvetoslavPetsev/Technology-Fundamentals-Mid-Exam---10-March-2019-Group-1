using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main()
        {
            int daysVacantion = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int peopleNumber = int.Parse(Console.ReadLine());
            double priceFuelPerKilometer = double.Parse(Console.ReadLine());
            double foodForOnePersonPerDay = double.Parse(Console.ReadLine());
            double priceRoomForOneNight = double.Parse(Console.ReadLine());
            
            double allcosts = 0;

            double costForFood = foodForOnePersonPerDay * peopleNumber * daysVacantion;
            double costSleep = priceRoomForOneNight * peopleNumber * daysVacantion;

            if (peopleNumber > 10)
            {
                costSleep *= 0.75;
            }

            allcosts += costForFood + costSleep;

            budget -= allcosts;

            for (int i = 1; i <= daysVacantion; i++)
            {

                double travelKilometer = double.Parse(Console.ReadLine());
                double costTraveling = priceFuelPerKilometer * travelKilometer;
               
                double addCost = 0;
                double recivedMoney = 0;

                allcosts += costTraveling;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    addCost = allcosts * 0.4;
                }

                if (i % 7 == 0)
                {
                    recivedMoney = allcosts / peopleNumber;
                }

                double expensesThisDay = (costTraveling + addCost) - recivedMoney;
                budget -= expensesThisDay;
                allcosts += addCost - recivedMoney;

                if (budget <= 0)
                {
                    break;
                }

            }

            if (budget < 0)
            {
                double diff = Math.Abs(budget);
                Console.WriteLine($"Not enough money to continue the trip. You need {diff:F2}$ more.");
            }
            else
            {
                Console.WriteLine($"You have reached the destination. You have {budget:F2}$ budget left.");
            }

        }
    }
}
