using System;
namespace age_of_war
{
    public class HeavyInfantry:Unit
    {  
        public HeavyInfantry()
        {
            hp = 30;
            attack = 11;
            defence = 20;
        }
        public string name = "HeavyInfantry";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}

