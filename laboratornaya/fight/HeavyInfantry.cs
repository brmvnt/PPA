using System;
namespace age_of_war
{
    public class HeavyInfantry:Unit, IHealable
    {
        public HeavyInfantry()
        {
            attack = 7;
            defence = 7;
            constHp = 8;
            hp = constHp;
            cost = attack + defence + hp;
        }
        public void GetHeal(int HealerPower)
        {
            if (hp < ConstHp && hp > 0)
            {
                if (hp + HealerPower >= ConstHp)
                    hp = ConstHp;
                else
                    hp += HealerPower;
            }
        }
        public string name = "HeavyInfantry";
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
    }
}