using System;
namespace age_of_war
{
  
    public class Knight:Unit
    {
        public Knight()
        {
            constHp = 20;
            hp = constHp;
            attack = 10;
            defence = 10;
            cost = attack + defence + hp;
        }
        public string name = "Knight";
        public override string ToString()
        {
            return $"{name}";
        } 
    }
}