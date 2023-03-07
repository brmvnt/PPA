using System;
namespace age_of_war
{
    public abstract class Unit
    {
        protected int hp;
        protected int constHp;
        protected int attack;
        protected int defence;
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public int ConstHp
        {
            get { return constHp; }
            set { constHp = value; }
        }
        public void GetHit(int oppAtt, int ArmyPrice) {
            var minus = (int)Math.Round((decimal)((ArmyPrice - defence)*oppAtt/100));
            hp -= minus;
        }
        public bool IsStillAlive() {
            bool t = true;
            if (hp <= 0) t = false;
            return t;
        }

        internal IHealable GetHeal(int power)
        {
            throw new NotImplementedException();
        }
    }
}

