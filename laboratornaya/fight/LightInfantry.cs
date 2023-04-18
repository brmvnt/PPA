using System;
namespace age_of_war
{
    public class LightInfantry : Unit, IHealable, IClonable
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

        //IClonable IClonable.Clone => throw new NotImplementedException();

        public IClonable Clone
        {
            get { return this.MemberwiseClone() as IClonable; }
        }

        public new void GetHeal(int HealerPower)
        {
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
