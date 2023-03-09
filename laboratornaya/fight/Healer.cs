using System;
namespace age_of_war
{
    public class Healer: Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 5;
        public int range = 3;
        public Healer()
        {
            constHp = 3;
            hp = constHp;
            attack = 2;
            defence = 1;
            Ability = SAEnumeration.Healer;
            cost = attack + defence + hp + (power + range) * 2;
        }

        public new int Cost
        {
            get { return cost; }
            set { cost = attack + defence + hp + (power + range) * 2; }
        }

        public string name = "Healer";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}

