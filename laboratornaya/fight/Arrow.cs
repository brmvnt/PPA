using System;
namespace age_of_war
{
    public class Arrow : Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 5;
        public int range = 3;
        public Arrow()
        {
            constHp = 10;
            hp = constHp;
            attack = 5;
            defence = 5;
            Ability = SAEnumeration.Arrow;
            cost = attack + defence + hp + (power + range) * 2;
        }

        public new int Cost
        {
            get { return cost; }
            set { cost = attack + defence + hp + (power + range)*2; }
        }

        public string name = "Arrow";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}