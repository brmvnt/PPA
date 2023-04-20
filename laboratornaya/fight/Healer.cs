using System;
using System.Text;

namespace age_of_war
{
    public class Healer : Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 5;
        public int range { get; }
        public Healer()
        {
            constHp = 3;
            hp = constHp;
            attack = 2;
            range = 3;
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
        public void Action(ISpecialAbility healer1, Army army1, Army army2, int i, int j)
        {
            Healer healer = (Healer)healer1;
            Console.WriteLine("im here1");
            if (army1.army[0] is IHealable)
            {
                Console.WriteLine("im here2");
                if (army1.army[0].Hp < army1.army[0].ConstHp && army1.army[0].IsStillAlive())
                {
                    Console.WriteLine("im here3");
                    ((IHealable)army1.army[0]).GetHeal(healer.power);
                    Console.WriteLine($"{army1.ToString()}: {healer.ToString()} вылечил {army1.army[0].ToString()} с хп {army1.army[0].Hp}");
                }
            }
        }
    }
}
