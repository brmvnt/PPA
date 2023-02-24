using System;
namespace age_of_war
{
    public class Unit
    {
        protected int hp;
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
        public void GetHit(int oppAtt) {
            if (oppAtt > Defence)
            {
                hp -= oppAtt;
            }
        }
        public bool IsStillAlive() {
            bool t = true;
            if (hp <= 0) t = false;
            return t;
        }
    }
}

