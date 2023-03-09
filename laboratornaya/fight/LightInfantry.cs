using System;
namespace age_of_war
{
    public class LightInfantry:Unit, IHealable
    {

        public string name = "LightInfantry";

        public LightInfantry()
        {
            attack = 5;
            defence = 5;
            constHp = 5;
            hp = constHp;
            cost = attack + defence + hp;
        }

        public void GetHeal(int HealerPower) {
            if (hp < ConstHp && hp > 0)
            {
                if (hp + HealerPower >= ConstHp)
                    hp = ConstHp;
                else
                    hp += HealerPower; 
            } 
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}