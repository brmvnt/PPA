﻿using System;
namespace age_of_war
{
    public class HeavyInfantry:Unit, IHealable
    {
        public HeavyInfantry()
        {
            attack = 11;
            defence = 20;
            constHp = 30;
            hp = constHp;
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
    }
}