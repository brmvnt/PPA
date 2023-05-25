using System;
using System.Text;

namespace age_of_war
{
    public class Action
    {
        public void Step(int i, Army army1, Army army2, int j, int ArmyPrice)
        {
            army1.army[0].PrintResultAttack(i, army1, army2, j);
            army2.army[0].GetHit(army1.army[0].Attack, ArmyPrice, i, army2);
            Death(i, army2.army[0], army2, army1, j); //rename
        }
        public void Death(int i, Proxy person2, Army army2, Army army1, int j)
        {
            if (!person2.IsStillAlive()) // если не живой
            { 
                army2.army.RemoveAt(0);
            }
        }
        public void DoAction(Army army1, Army army2, int j)
        {
            int max = Math.Max(army1.army.Count, army2.army.Count); 
            for (int i = 1; i < max; i++) {
                if (army1.army.Count > 0 && i < army1.army.Count)
                    if (army1.army[i].CheckSA())
                    {
                        var special = army1.army[i];
                        if (i <= special.Range() && i < army1.army.Count()) 
                        { 
                            special.Action(special, army1, army2, j, i);
                        }
                    }
                if (army2.army.Count > 0 && i < army2.army.Count)
                    if (army2.army[i].CheckSA())
                    {
                        var special = army2.army[i];
                        if (i <= special.Range() && i < army1.army.Count())
                        {
                            special.Action(special, army1, army2, j, i);
                        }
                    }
            }
        }
    }
}

