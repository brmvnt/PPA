using System;
namespace age_of_war {
    public class Cloner:Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 80; 
        public int range = 3;
        public Cloner()
        {
            constHp = 3;
            hp = constHp;
            attack = 2;
            defence = 1;
            Ability = SAEnumeration.Cloner;
            cost = attack + defence + hp + (power + range) * 2;
        }
        public new int Cost
        {
            get { return cost; }
            set { cost = attack + defence + hp + (power + range) * 2; }
        }
        public bool Probability() {
            var rand = new Random();
            int q = rand.Next(0, 100);
            return q <= power ? true: false;
        }
        public string name = "Witcher";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}