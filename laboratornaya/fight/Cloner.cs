using System;
using System.Text;

namespace age_of_war
{
    public class Cloner : Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 40;
        public int range { get; }
        public Cloner()
        {
            constHp = 3;
            hp = constHp;
            attack = 2;
            defence = 1;
            range = 3;
            Ability = SAEnumeration.Cloner;
            cost = attack + defence + hp + power/2 + range * 2;
        }
        public new int Cost
        {
            get { return cost; }
            set { cost = attack + defence + hp + power/2 + range * 2; }
        }
        public bool Probability()
        {
            var rand = new Random();
            int q = rand.Next(0, 100);
            return q <= power ? true : false;
        }
        public string name = "Cloner";
        public override string ToString()
        {
            return $"{name}";
        }
        public void Action(ISpecialAbility cloner1, Army army1, Army army2, int i, int j)
        {
            Cloner cloner = (Cloner)cloner1;
            int hplace = army1.army.IndexOf(cloner);
            if (/*(i == j)|| */  (hplace == 0)) return;
            if (army1.army[hplace - 1] is IClonable)
            {
                Console.WriteLine("1im here1");
                IClonable? clone = null;
                if (cloner.Probability() == true)
                {
                    Console.WriteLine("1im here2");
                    clone = ((IClonable)army1.army[hplace - 1]).Clone;
                }// добавляем в армию перед i
                if (clone != null)
                {
                    Console.WriteLine("1im here3");
                    Console.WriteLine($"Клонирование {army1.army[hplace - 1].ToString()}");
                    army1.army.Insert(hplace - 1, (Unit)clone);
                }
            }
        }
    }
}
