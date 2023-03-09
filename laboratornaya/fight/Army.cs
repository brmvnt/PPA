using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace age_of_war
{
    public class Army
    {
        public List<Unit> army;
        public string name;
        public Army(string name)
        { 
            
            this.name = name;
            if (name == "Computer")
            {
                var hf = new HIFactory();
                var hi = hf.Create();
                var kf = new KFactory();
                var k = kf.Create();
                army = new List<Unit>() { hi, k }; 
            }
            else
                army = BuyArmy.BuyArmyMain();
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
