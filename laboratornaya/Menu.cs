using System;

namespace ConsoleApp1 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MakeTitle();
            string userMainChoice = MakeMainMenu();
            switch (userMainChoice)
            {
                case "S":
                    Console.Clear();
                    // открывается новое окно с покупкой юнитов, а затем игрой
                    break;
                case "E":
                    // Выход из игры
                    break;
                // case еще какое-то действие...
            }

            //while (true)
            //{
            //    DateTime ThDay = DateTime.Now;
            //    string ThData = ThDay.ToString();
            //    Console.WriteLine(ThData);
            //    Thread.Sleep(1000);
            //    Console.Clear();
            //}
        }

        private static string MakeMainMenu()
        {
            Console.WriteLine("\nCHOOSE YOUR ACTION");
            Console.WriteLine("(S)tart a new game");
            Console.WriteLine("(E)xit");
            string userMainChoice = "a";
            while (userMainChoice != "S" & userMainChoice != "E")
            {
                ClearCurrentConsoleLine();
                Console.Write("→ ");
                var temp = Console.ReadKey();
                userMainChoice = Convert.ToString(temp.KeyChar).ToUpper();
            }

            //Console.WriteLine ($"\n\nYOU CHOSE - {userMainChoice}\n");

            if (userMainChoice == "S")
            {
                string LoadingText = "Loading...";
                char[] LoadingTextArray = LoadingText.ToCharArray();
                for (int i = 0; i < LoadingTextArray.Length; i++)
                {
                    Console.Write(LoadingTextArray[i]);
                    Thread.Sleep(150);
                }
            }

            return userMainChoice;
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static void MakeTitle()
        {
            Console.WriteLine("                                                                          ");
            Console.WriteLine(" _____ _____ _   _  _____  _____ _      _____    ___  _________  ____   __\r");
            Console.WriteLine("/  __ \\  _  | \\ | |/  ___||  _  | |    |  ___|  / _ \\ | ___ \\  \\/  \\ \\ / /\r");
            Console.WriteLine("| /  \\/ | | |  \\| |\\ `--. | | | | |    | |__   / /_\\ \\| |_/ / .  . |\\ V / \r");
            Console.WriteLine("| |   | | | | . ` | `--. \\| | | | |    |  __|  |  _  ||    /| |\\/| | \\ /  \r");
            Console.WriteLine("| \\__/\\ \\_/ / |\\  |/\\__/ /\\ \\_/ / |____| |___  | | | || |\\ \\| |  | | | |  \r");
            Console.WriteLine(" \\____/\\___/\\_| \\_/\\____/  \\___/\\_____/\\____/  \\_| |_/\\_| \\_\\_|  |_/ \\_/  \r");
            Console.WriteLine("                                                                          ");
        }
    }
}