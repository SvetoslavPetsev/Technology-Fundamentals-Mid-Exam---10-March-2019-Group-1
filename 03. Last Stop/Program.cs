using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                List<string> command = input.Split().ToList();

                if (command[0] == "Change")
                {
                    string paintingNumber = command[1];
                    string changedNumber = command[2];
                    Change(numbers, paintingNumber, changedNumber);
                }

                else if (command[0] == "Hide")
                {
                    string paintingNumber = command[1];
                    Hide(numbers, paintingNumber);
                }

                else if (command[0] == "Switch")
                {
                    string paintingNumber1 = command[1];
                    string paintingNumber2 = command[2];
                    Switch(numbers, paintingNumber1, paintingNumber2);
                }

                else if (command[0] == "Insert")
                {
                    Insert(numbers, command);
                }

                else if (command[0] == "Reverse")
                {
                    numbers.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Insert(List<string> numbers, List<string> command)
        {
            int indexToInsert = int.Parse(command[1]) + 1;
            string paintN = command[2];

            if (indexToInsert >= 0 && indexToInsert < numbers.Count)
            {
                numbers.Insert(indexToInsert, paintN);
            }
        }

        private static void Switch(List<string> numbers, string paintingNumber1, string paintingNumber2)
        {
            int counter = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                string curr1 = numbers[i];

                for (int j = counter; j < numbers.Count; j++)
                {
                    string curr2 = numbers[j];

                    if (curr1 == paintingNumber1 && curr2 == paintingNumber2)
                    {
                        numbers.Insert(i, paintingNumber2);
                        numbers.RemoveAt(i + 1);
                        numbers.Insert(j, paintingNumber1);
                        numbers.RemoveAt(j + 1);
                        counter = j + 1;
                        break;

                    }
                    else if (curr2 == paintingNumber1 && curr1 == paintingNumber2)
                    {
                        numbers.Insert(i, paintingNumber1);
                        numbers.RemoveAt(i + 1);
                        numbers.Insert(j, paintingNumber2);
                        numbers.RemoveAt(j + 1);
                        counter = j + 1;
                        break;
                    }

                }
            }
        }

        private static void Change(List<string> numbers, string paintingNumber, string changedNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                string currNumber = numbers[i];

                if (currNumber == paintingNumber)
                {
                    int index = i;
                    numbers.RemoveAt(index);
                    numbers.Insert(index, changedNumber);
                    break;
                }
            }
        }

        private static void Hide(List<string> numbers, string a)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                string currNumber = numbers[i];

                if (currNumber == a)
                {
                    numbers.Remove(currNumber);
                }
            }
        }
    }
}
