using System;

namespace age_of_war
{
    public class BuyArmy
    {
        public static int CurrentMoney = 100;

        public static List<Unit> BuyArmyMain() 
        {
            List<Unit> Army = new List<Unit>();
            var lf = new LIFactory();
            var hf = new HIFactory();
            var kf = new KFactory();
            var af = new ArrowFactory();
            var healerf = new HealerFactory();

            var LItest = new LightInfantry();
            var HItest = new HeavyInfantry();
            var Ktest = new Knight();
            var Atest = new Arrow();
            var Htest = new Healer();

            while (true)
            {
                BuyArmyMenu(LItest, HItest, Ktest, Atest, Htest);
                var unitChoice = 10;
                while(unitChoice > 5)
                {
                    try
                    {
                        var temp = Console.ReadLine();
                        unitChoice = Convert.ToInt32(temp);
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("Введите число!");
                    }
                }

                switch (unitChoice)
                {
                    case 0:
                        if (Army.Count == 0)
                        {
                            Console.WriteLine("Вы не создали ни одного юнита\n");
                            break;
                        }
                        else
                        {
                            return Army;
                        }
                    case 1:
                        if (isEnoughMoney(LItest, CurrentMoney) == true)
                        {
                            Army.Add(lf.Create());
                            CurrentMoney -= LItest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                    case 2:
                        if (isEnoughMoney(HItest, CurrentMoney) == true)
                        {
                            Army.Add(hf.Create());
                            CurrentMoney -= HItest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                    case 3:
                        if (isEnoughMoney(Ktest, CurrentMoney) == true)
                        {
                            Army.Add(kf.Create());
                            CurrentMoney -= Ktest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                    case 4:
                        if (isEnoughMoney(Atest, CurrentMoney) == true)
                        {
                            Army.Add(af.Create());
                            CurrentMoney -= Atest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                    case 5:
                        if (isEnoughMoney(Htest, CurrentMoney) == true)
                        {
                            Army.Add(healerf.Create());
                            CurrentMoney -= Htest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                }
            }
        }

        private static void BuyArmyMenu(LightInfantry LItest, HeavyInfantry HItest, Knight Ktest, Arrow Atest, Healer Htest)
        {
            Console.WriteLine("BUY UNITS");
            Console.WriteLine("Button|     Name      | Cost |Attack| Defence |  HP  |   Special Ability Power   |   Special Ability Range  |");
            Console.WriteLine($"(1)   | {LItest.name} |  {LItest.Cost}  |  {LItest.Attack}   |    {LItest.Defence}    |  {LItest.Hp}   |             0             |             0            |");
            Console.WriteLine($"(2)   | {HItest.name} |  {HItest.Cost}  |  {HItest.Attack}   |    {HItest.Defence}    |  {HItest.Hp}   |             0             |             0            |");
            Console.WriteLine($"(3)   | {Ktest.name}        |  {Ktest.Cost}  |  {Ktest.Attack}  |    {Ktest.Defence}   |  {Ktest.Hp}  |             0             |             0            |");
            Console.WriteLine($"(4)   | {Atest.name}         |  {Atest.Cost}  |  {Atest.Attack}   |    {Atest.Defence}    |  {Atest.Hp}  |             {Atest.power}             |             {Atest.range}            |");
            Console.WriteLine($"(5)   | {Htest.name}        |  {Htest.Cost}  |  {Htest.Attack}   |    {Htest.Defence}    |  {Htest.Hp}   |             {Htest.power}             |             {Htest.range}            |");
            Console.WriteLine("(0) Done!");
            Console.WriteLine($"\nCurrent money — {CurrentMoney}");
        }

        static bool isEnoughMoney (Unit unit, int CurrentMoney)
        {
            if (CurrentMoney >= unit.Cost)
            {
                return true;
            }
            return false;
        }

    }
}
