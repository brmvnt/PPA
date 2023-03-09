using System;
using System.Collections.Generic;
namespace age_of_war
{
    class Game
    {
        public readonly static int ArmyPrice = 100;
        public void Start() {

            var army1 = new Army("Мы победим");
            var army2 = new Army("Computer");

            int i = 1;
            while  (army1.army.Count() > 0 && army2.army.Count() > 0) {
                Step(i, army1, army2, 0);
                if (army2.army.Count > 0)
                    Step(i, army2, army1, 0);
                int max = Math.Max(army1.army.Count(), army2.army.Count());
                if (max > 3) max = 3;
                for (int j = 1; j < max; j++) //range //to do
                {
                    if (army1.army.Count() <= j)
                        continue;
                    if (army1.army[j] is ISpecialAbility)
                        DoAction((ISpecialAbility)army1.army[j], army1, army2, i, j);
                    if (army2.army.Count() <= j)
                        continue;
                    if (army2.army[j] is ISpecialAbility)
                        DoAction((ISpecialAbility)army2.army[j], army2, army1, i, j);
                }
                i++;
            } 
            Congrats(army1, army2);
        }
        static public void DoAction(ISpecialAbility unit, Army army1, Army army2, int i, int j)
        {
            switch (unit.Ability)
            {
                case (SAEnumeration.Arrow):
                    DoArrow((Arrow)unit, army1, army2, i, j);
                    break;
                case (SAEnumeration.Healer):
                    DoHealer((Healer)unit, army1, army2, i);
                    break;
            }
        }
        static public void DoArrow(Arrow arrow, Army army1, Army army2, int i, int j) {
            if (army2.army.Count() > 0)
            {
                if (army2.army[0].IsStillAlive())
                    army2.army[0].GetHit(arrow.power, ArmyPrice);
                Death(i, arrow, army2.army[0], army2, army1, j);
            }
        }
        static public void DoHealer(Healer healer, Army army1, Army army2, int i) {
            if (army1.army[0] is IHealable)
                if (army1.army[0].Hp < army1.army[0].ConstHp && army1.army[0].IsStillAlive())
                {
                    ((IHealable)army1.army[0]).GetHeal(healer.power);
                    //      Console.WriteLine($"{i} ход");
                    Console.WriteLine($"{army1.ToString()}: {healer.ToString()} вылечил {army1.army[0].ToString()} с хп {army1.army[0].Hp}");
                }
        }
        static public void Congrats(Army army1,Army army2)
        {
            if (army1.army.Count == 0 && army2.army.Count != 0)
                Console.WriteLine($"{army2.ToString()} won");
            if (army1.army.Count != 0 && army2.army.Count == 0)
                Console.WriteLine($"{army1.ToString()} won");
            if (army1.army.Count == 0 && army2.army.Count == 0)
                Console.WriteLine("nobody won");
        }
        public void Step(int i, Army army1, Army army2, int j) {
            var person1 = army1.army[0];
            var person2 = army2.army[0];
            person2.GetHit(person1.Attack, ArmyPrice);
            Death(i, person1, person2, army2, army1, j); //rename
        }
        public static void Death(int i, Unit person1, Unit person2, Army army2, Army army1, int j)
        { 
            Unit? soul = null;
            if (!person2.IsStillAlive()) // если не живой
            { 
                soul = army2.army[0]; // удаляем
                army2.army.RemoveAt(0);
            }
            PrintResult(i, army1, army2, soul, j);
        }
        public static void PrintResultAttack(int i, Army army1, Army army2, int j)
        {
            var atUnit = army1.army[j];
            Console.WriteLine($"{army1.ToString()}: {atUnit.ToString()} аттаковал с силой {atUnit.Attack}");
        } 
        public static void PrintResultDefence(Army army2, Unit? soul)
        {
           if (soul != null)
                Console.WriteLine($"{army2.ToString()}: {soul.ToString()} с защитой {soul.Defence} был убит");
           else
                Console.WriteLine($"{army2.ToString()}: {army2.army[0].ToString()} с защитой {army2.army[0].Defence} остался жив");
        }
        public static void PrintResult(int i, Army army1, Army army2, Unit? soul, int  j)
        {
            Console.WriteLine($"{i} ход");
            PrintResultAttack(i, army1, army2, j);
            PrintResultDefence(army2, soul);
        }
    }
    class Program
    {
        public static int Main() {

            var game = new Game();
            game.Start();

            //List<Unit> Army = BuyArmy.BuyArmyMain();
            //int n = Army.Count;
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(Army[i]);
            //    Console.WriteLine(Army[i].Hp);
            //}
            return 0;
        }
    }
}