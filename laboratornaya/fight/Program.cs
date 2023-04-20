using System;
using System.Collections.Generic;
namespace age_of_war
{
    class Game
    {
        public readonly int ArmyPrice = 100;
        public void Start()
        {
            var army1 = new Army("Мы победим");
            var army2 = new Army("Computer");
            var action = new Action();
            int i = 1;
            while (army1.army.Count() > 0 && army2.army.Count() > 0)
            {
                action.Step(i, army1, army2, 0, ArmyPrice);
                if (army2.army.Count > 0)
                    action.Step(i, army2, army1, 0, ArmyPrice);
                action.DoAction(army1, army2, i);
                i++;
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
