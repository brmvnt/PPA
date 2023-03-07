using System;
using System.Collections.Generic;
namespace age_of_war
{
    class Game
    {
        public readonly static int ArmyPrice = 100;
        public void Start() {
            var lf = new LIFactory();
            var li = lf.Create();
            var hf = new HIFactory();
            var hi = hf.Create();
            var kf = new KFactory();
            var k = kf.Create();
            var af = new ArrowFactory();
            var ar = af.Create();
            var healerf = new HealerFactory();
            var hea = healerf.Create();
            var army1 = new List<Unit>() { li, hea, hea };  //сделать армию отдельным классом
            var army2 = new List<Unit>() { li, li, li };
            int i = 1;
            while  (army1.Count > 0 && army2.Count > 0) {
                Step(i, army1, army2, 0);
                if (army2.Count > 0)
                    Step(i, army2, army1, 0);
                int max = Math.Max(army1.Count(), army2.Count());
                if (max > 3) max = 3;
                for (int j = 1; j < max; j++) //range //to do
                {
                    if (army1.Count() <= j)
                        continue;
                    if (army1[j] is ISpecialAbility)
                        DoAction((ISpecialAbility)army1[j], army1, army2, i, j);
                    if (army2.Count() <= j)
                        continue;
                    if (army2[j] is ISpecialAbility)
                        DoAction((ISpecialAbility)army2[j], army2, army1, i, j);
                }
                i++;
            } 
            Congrats(army1, army2);
        }
        static public void DoAction(ISpecialAbility unit, List<Unit> army1, List<Unit> army2, int i, int j)
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
        static public void DoArrow(Arrow arrow, List<Unit> army1, List<Unit> army2, int i, int j) {
            if (army2.Count() > 0)
            {
                if (army2[0].IsStillAlive())
                    army2[0].GetHit(arrow.power, ArmyPrice);
                Death(i, arrow, army2[0], army2, army1, j);
            }
        }
        static public void DoHealer(Healer healer, List<Unit> army1, List<Unit> army2, int i) {
            if (army1[0] is IHealable)
                if (army1[0].Hp < army1[0].ConstHp && army1[0].IsStillAlive())
                {
                    ((IHealable)army1[0]).GetHeal(healer.power);
                    //      Console.WriteLine($"{i} ход");
                    Console.WriteLine($"{healer.ToString()} вылечил {army1[0].ToString()} с хп {army1[0].Hp}");
                }
        }
        static public void Congrats(List<Unit> army1, List<Unit> army2)
        {
            if (army1.Count == 0 && army2.Count != 0)
                Console.WriteLine("army2 won");
            if (army1.Count != 0 && army2.Count == 0)
                Console.WriteLine("army1 won");
            if (army1.Count == 0 && army2.Count == 0)
                Console.WriteLine("nobody won");
        }
        public void Step(int i, List<Unit> army1, List<Unit> army2, int j) {
            var person1 = army1[0];
            var person2 = army2[0];
            person2.GetHit(person1.Attack, ArmyPrice);
            Death(i, person1, person2,  army2, army1, j); //rename
        }
        public static void Death(int i, Unit person1, Unit person2, List<Unit> army2, List<Unit> army1, int j)
        { 
            Unit? soul = null;
            if (!person2.IsStillAlive()) // если не живой
            { 
                soul = army2[0]; // удаляем
                army2.RemoveAt(0);
            }
            PrintResult(i, army1, army2, soul, j);
        }
        public static void PrintResultAttack(List<Unit> army1, List<Unit> army2, int j)
        {
            var atUnit = army1[j];
            Console.WriteLine($"{atUnit.ToString()} аттаковал с силой {atUnit.Attack}");
        } 
        public static void PrintResultDefence(List<Unit> army2, Unit? soul)
        {
           if (soul != null)
                Console.WriteLine($"{soul.ToString()} с защитой {soul.Defence} был убит");
           else
                Console.WriteLine($"{army2[0].ToString()} с защитой {army2[0].Defence} остался жив");
        }
        public static void PrintResult(int i, List<Unit> army1, List<Unit> army2, Unit? soul, int  j)
        {
            Console.WriteLine($"{i} ход");
            PrintResultAttack(army1, army2, j);
            PrintResultDefence(army2, soul);
        }
    }
    class Program
    {
        public static int Main() {
            //var game = new Game();
            var test = new Class1();

            //game.Start();
            return 0;
        }
    }
}