﻿using System;
namespace age_of_war
{
  
    public class Knight:Unit
    {
        public Knight()
        {
            hp = 40;
            attack = 30;
            defence = 25;
        }
        public string name = "Knight";
        public override string ToString()
        {
            return $"{name}";
        } 
    }
}

