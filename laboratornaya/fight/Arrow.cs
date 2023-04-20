using System;
namespace age_of_war
{
    public class Arrow : Unit, ISpecialAbility
    {
        public SAEnumeration Ability { get; }
        public int power = 5;
        public int range { get; }
        public Arrow()
        {
            constHp = 10;
            hp = constHp;
            attack = 5;
            defence = 5;
            range = 3;
            Ability = SAEnumeration.Arrow;
            cost = attack + defence + hp + (power + range) * 2;
        }

        public new int Cost
        {
            get { return cost; }
            set { cost = attack + defence + hp + (power + range) * 2; }
        }

        public string name = "Arrow";
        public override string ToString()
        {
            return $"{name}";
        }
        public void Action(ISpecialAbility arrow1, Army army1, Army army2, int i, int j)
        {
            Arrow arrow = (Arrow)arrow1;
            Console.WriteLine("im here arrow");
            Action act = new Action();
            Game game = new Game();
            if (army2.army.Count() > 0)
            {
                if (army2.army[0].IsStillAlive())
                    army2.army[0].GetHit(arrow.power, game.ArmyPrice);
                act.Death(i, arrow, army2.army[0], army2, army1, j);
            }
        }
    }
}
