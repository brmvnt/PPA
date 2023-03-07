using System;
namespace age_of_war
{
    public class LightInfantry:Unit, IHealable
    {
        public LightInfantry()
        {
            attack = 5;
            defence = 10;
            constHp = 30;
            hp = constHp;
        }
        public string name = "LightInfantry";
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