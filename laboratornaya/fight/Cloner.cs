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

        public override void PrintResultAttack(int i, Army army1, Army army2, int j)
        {
            Console.WriteLine($"{i} ход: {army1.ToString()}: {ToString()} атаковал с силой {Attack}");
        }

        public override void PrintResultDefence(int i, Army army2)
        {
            if (hp <= 0)
                Console.WriteLine($"{i} ход: {army2.ToString()}: {ToString()} с защитой {Defence} был убит");
            else
                Console.WriteLine($"{i} ход: {army2.ToString()}: {ToString()} с защитой {Defence} остался жив");
        }
        public void Action(ISpecialAbility cloner1, Army army1, Army army2, int i, int j, int hplace)
        {
            Cloner cloner = (Cloner)cloner1;
            if (/*(i == j)|| */  (hplace == 0)) return;
            if (army1.army[hplace - 1].IsIClonable()) //hp == -1
            {
                Proxy? clone = null;
                if (cloner.Probability() == true)
                {
                   var unit = army1.army[hplace - 1].Clone();
                   clone = new Proxy((Unit)unit);
                }// добавляем в армию перед i
                if (clone != null)
                {
                    Console.WriteLine($"{i} ход: {army1.ToString()}: Клонирование {army1.army[hplace - 1].ToString()}");
                    army1.army.Insert(hplace - 1, clone);
                }
            }
        }
    }
}
