using System;
using System.Text;

namespace age_of_war
{
    public class Action
    {
        public void Step(int i, Army army1, Army army2, int j, int ArmyPrice)
        {
            var person1 = army1.army[0];
            var person2 = army2.army[0];
            person2.GetHit(person1.Attack, ArmyPrice);
            Death(i, person1, person2, army2, army1, j); //rename
        }

        public void Death(int i, Unit person1, Unit person2, Army army2, Army army1, int j)
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
        public static void PrintResult(int i, Army army1, Army army2, Unit? soul, int j)
        {
            Console.WriteLine($"{i} ход");
            PrintResultAttack(i, army1, army2, j);
            PrintResultDefence(army2, soul);
        }
        public void DoAction(Army army1, Army army2, int j)
        {
            int max = Math.Max(army1.army.Count, army2.army.Count);
            for (int i = 1; i < max; i++) {
                if (army1.army.Count > 0 && i < army1.army.Count)
                    if (army1.army[i] is ISpecialAbility)
                    {
                        var special = (ISpecialAbility)army1.army[i];
                        if (i <= special.range && i < army1.army.Count())
                        { 
                            special.Action(special, army1, army2, j, i);
                        }
                    }
                if (army2.army.Count > 0 && i < army2.army.Count)
                    if (army2.army[i] is ISpecialAbility)
                    {
                        var special = (ISpecialAbility)army2.army[i];
                        if (i <= special.range && i < army1.army.Count())
                        {
                            special.Action(special, army1, army2, j, i);
                        }
                    }
            }
        }
    }
}

