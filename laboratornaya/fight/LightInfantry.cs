using System;
namespace age_of_war
{
    public class LightInfantry:Unit
    { 
        public LightInfantry()
        {
            hp = 30;
            attack = 5;
            defence = 10;
        }
        public string name = "LightInfantry";
        public override string ToString()
        {
            return $"{name}";
        }
    }
}

