using System;
using System.Runtime.InteropServices;

namespace age_of_war
{
    public class BuyArmy
    {
        public static int CurrentMoney = 100;

        public static List<Proxy> BuyArmyMain()
        {
            List<Proxy> Army = new List<Proxy>();
            var lf = new LIFactory();
            var hf = new HIFactory();
            var kf = new KFactory();
            var af = new ArrowFactory();
            var healerf = new HealerFactory();
            var clonerf = new ClonerFactory();

            var LItest = new LightInfantry();
            var HItest = new HeavyInfantry();
            var Ktest = new Knight();
            var Atest = new Arrow();
            var Htest = new Healer();
            var CLtest = new Cloner();

            while (true)
            {
                BuyArmyMenu(LItest, HItest, Ktest, Atest, Htest, CLtest);
                var unitChoice = 10;
                while (unitChoice > 6)
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
                            var pr1 = new Proxy(lf.Create());
                            Army.Add(pr1);
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
                            var pr2 = new Proxy(hf.Create());
                            Army.Add(pr2);
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
                            var pr3 = new Proxy(kf.Create());
                            Army.Add(pr3);
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
                            var pr4 = new Proxy(af.Create());
                            Army.Add(pr4);
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
                            var pr5 = new Proxy(healerf.Create());
                            Army.Add(pr5);
                            CurrentMoney -= Htest.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно денег!");
                            break;
                        }
                    case 6:
                        if (isEnoughMoney(CLtest, CurrentMoney) == true)
                        {
                            var pr6 = new Proxy(clonerf.Create());
                            Army.Add(pr6);
                            CurrentMoney -= CLtest.Cost;
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

        private static void BuyArmyMenu(LightInfantry LItest, HeavyInfantry HItest, Knight Ktest, Arrow Atest, Healer Htest, Cloner CLtest)
        {
            Console.WriteLine("BUY UNITS");
            Console.WriteLine("Button|     Name      | Cost |Attack| Defence |  HP  |   Special Ability Power   |   Special Ability Range  |");
            Console.WriteLine($"(1)   | {LItest.name} |  {LItest.Cost}  |  {LItest.Attack}   |    {LItest.Defence}    |  {LItest.Hp}   |             0             |             0            |");
            Console.WriteLine($"(2)   | {HItest.name} |  {HItest.Cost}  |  {HItest.Attack}   |    {HItest.Defence}    |  {HItest.Hp}   |             0             |             0            |");
            Console.WriteLine($"(3)   | {Ktest.name}        |  {Ktest.Cost}  |  {Ktest.Attack}  |    {Ktest.Defence}   |  {Ktest.Hp}  |             0             |             0            |");
            Console.WriteLine($"(4)   | {Atest.name}         |  {Atest.Cost}  |  {Atest.Attack}   |    {Atest.Defence}    |  {Atest.Hp}  |             {Atest.power}             |             {Atest.range}            |");
            Console.WriteLine($"(5)   | {Htest.name}        |  {Htest.Cost}  |  {Htest.Attack}   |    {Htest.Defence}    |  {Htest.Hp}   |             {Htest.power}             |             {Htest.range}            |");
            Console.WriteLine($"(6)   | {CLtest.name}        |  {CLtest.Cost}  |  {CLtest.Attack}   |    {CLtest.Defence}    |  {CLtest.Hp}   |             {CLtest.power}             |             {CLtest.range}            |");
            Console.WriteLine("(0) Done!");
            Console.WriteLine($"\nCurrent money — {CurrentMoney}");
        }

        static bool isEnoughMoney(Unit unit, int CurrentMoney)
        {
            if (CurrentMoney >= unit.Cost)
            {
                return true;
            }
            return false;
        }

    }
}
