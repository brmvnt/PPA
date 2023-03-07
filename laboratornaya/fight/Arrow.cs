using System;
namespace age_of_war
{
    public class Arrow : Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 10;
        public Arrow()
        {
            constHp = 30;
            hp = constHp;
            attack = 5;
            defence = 10;
            Ability = SAEnumeration.Arrow;
        }
        public string name = "Arrow";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}