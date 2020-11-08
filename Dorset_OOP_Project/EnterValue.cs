using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public static class EnterValue
    {
        //t1
        public static string AskingValue(string message, int numberOfPossibility)
        {
            bool validAnswer = false;
            string answer = "";
            while (!validAnswer)
            {
                Console.WriteLine(message);
                answer = Console.ReadLine();
                for (int indexPossibility = 1; indexPossibility <= numberOfPossibility; indexPossibility++)
                {
                    if (answer == Convert.ToString(indexPossibility))
                    {
                        validAnswer = true;
                    }
                }
                if (!validAnswer)
                {
                    Console.WriteLine("You type an invalid answer");
                }
            }
            return answer;
        }
    }
}
