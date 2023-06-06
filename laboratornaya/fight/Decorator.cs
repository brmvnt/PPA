using System.Xml.Linq;

namespace age_of_war
{
    public abstract class UnitDecorator : HeavyInfantry
    {
        public UnitDecorator(string n, Unit unit, int baffAttack, int baffDefence)
        {
            Name = n;
            Attack = Attack + baffAttack;
            Defence = Defence + baffDefence;
        }

        public override void PrintResultAttack(int i, Army army1, Army army2, int j)
        {
            Console.WriteLine($"{i} ход: {army1.ToString()}: {army1.army[0].ToString()} атаковал с силой {army1.army[0].Attack}");
        }

        public override void PrintResultDefence(int i, Army army2)
        {
            if (hp <= 0)
                Console.WriteLine($"{i} ход: {army2.ToString()}: {ToString()} с защитой {Defence} был убит");
            else
                Console.WriteLine($"{i} ход: {army2.ToString()}: {ToString()} с защитой {Defence} остался жив");
        }
    }

    public class HeavyInfantryHelmet : UnitDecorator //  heavy infantry со шлемом
    {
        static int baff = 5; // +5 к атаке
        public HeavyInfantryHelmet(Unit unit) : base(unit.Name + " со шлемом", unit, baff, 0)
        {
        }
    }

    public class HeavyInfantryShield : UnitDecorator //  heavy infantry с щитом
    {
        static int baff = 5; // +5 к защите
        public HeavyInfantryShield(Unit unit) : base(unit.Name + " с щитом", unit, 0, baff)
        {
        }

    }

    public class HeavyInfantryHourse : UnitDecorator //  heavy infantry с лошадью
    {
        static int baffAtt = 5; // +5 к атаке
        static int baffDef = 5; // +5 к защите
        public HeavyInfantryHourse(Unit unit) : base(unit.Name + " на лошади", unit, baffAtt, baffDef)
        {
        }
    }
}