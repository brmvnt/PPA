using System;
namespace age_of_war
{
    public class Healer: Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 30;
        public Healer()
        {
            constHp = 30;
            hp = constHp;
            attack = 5;
            defence = 10;
            Ability = SAEnumeration.Healer;
        }
        public string name = "Healer";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}

