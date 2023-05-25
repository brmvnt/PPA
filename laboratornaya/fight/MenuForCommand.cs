using System;
namespace age_of_war
{
    public class MenuForCommand
    {
        public int ShowMenu1()
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Отменить действие");
            Console.WriteLine("0. Продолжить игру");
            int choice = ChooseChoice();
            return choice;
        }
        public int ShowMenu2()
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("2. Вернуть действие");
            Console.WriteLine("0. Продолжить игру");
            int choice = ChooseChoice();
            return choice;
        }
        public static int ChooseChoice() {
            int choice = -1;
            while (choice != 1 && choice != 0 && choice !=2)
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
