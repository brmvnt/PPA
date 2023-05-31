using System;
using System.Collections.Generic;
namespace age_of_war
{
    class Game
    {
        public readonly int ArmyPrice = 100;
        public void Start()
        {
            int i = 1;
            var army1 = new Army("Мы победим", i);
            var army2 = new Army("Computer", i);
            var action = new Action();
            //var menuForcommand = new MenuForCommand();
            //var invoker = new Invoker();
            //var station = new Station(army1, army2);
            //IStrategy strategy = new MainStrategy();
            while (army1.army.Count() > 0 && army2.army.Count() > 0)
            {
                Console.WriteLine("Choose the strategy: 1,  2, 3");
                var temp = Console.ReadLine();
                int choice = Convert.ToInt32(temp);
                // устанавливаем стратегию
                //strategy.Algorithm();
                //station.UpdateStation(army1, army2);
                //if (i != 1 || station.undo == true)
                //{                
                //    int c;
                //    if (!station.undo)
                //    {
                //        c = menuForcommand.ShowMenu1();
                //        ;
                //    }
                //    else
                //    {
                //        c = menuForcommand.ShowMenu2();
                //        //break;
                //    }
                //    if (c != 0)
                //    {
                //        i = invoker.SetUndoRedo(c, station, army1, army2, i);
                //        if (c == 1) continue;
                //    }
                //}
                action.Step(i, army1, army2, 0, ArmyPrice);
                if (army2.army.Count > 0)
                    action.Step(i, army2, army1, 0, ArmyPrice);
                action.DoAction(army1, army2, i);
                i++;
               // station.undo = false;
            }
            Congrats(army1, army2);
        }
        static public void Congrats(Army army1, Army army2)
        {
            if (army1.army.Count == 0 && army2.army.Count != 0)
                Console.WriteLine($"{army2.ToString()} won");
            if (army1.army.Count != 0 && army2.army.Count == 0)
                Console.WriteLine($"{army1.ToString()} won");
            if (army1.army.Count == 0 && army2.army.Count == 0)
                Console.WriteLine("nobody won");
        }
    }
    class Program
    {
        public static int Main()
        {
            var game = new Game();
            game.Start();
            return 0;
        }
    }
}
