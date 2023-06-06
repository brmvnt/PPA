using System;
namespace age_of_war
{
    public class MenuForStrategy
    {
        public int ShowMenu1()
        {
            Console.WriteLine("Выберите стратегию");
            Console.WriteLine("1. Армия в один ряд");
            Console.WriteLine("2. Армия в три ряда");
            Console.WriteLine("3. Стенка на стенку");
            int choice = ChooseChoice();
            return choice;
        }
   
        public static int ChooseChoice()
        {
            int choice = -1;
            while (choice != 1 && choice != 2 && choice != 3)
            {
                try
                {
                    var temp = Console.ReadLine();
                    choice = Convert.ToInt32(temp);
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                }
            }
            return choice;
        }
    }
}

