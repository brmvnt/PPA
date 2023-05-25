using System;
namespace age_of_war
{
    public class Station
    {
        public bool undo;
        public Army army1; 
        public Army army2;
        public Station (Army army1, Army army2)
        {
            undo = false;
            this.army1 = new Army(army1.name, 2);
            this.army1 = army1;
            this.army2 = new Army(army2.name, 2);
            this.army2 = army2;
        }
        public void UpdateStation(Army army1, Army army2)
        {
            this.army1 = new Army(army1.name, 2);
            this.army1 = army1;
            this.army2 = new Army(army2.name, 2);
            this.army2 = army2;
        }
        public Station ForUndo(Army army1, Army army2)
        {
            undo = true;
            var station2 = new Station(army1, army2);
            army1 = new Army(this.army1.name, 2);
            army1 = this.army1;
            army2 = new Army(this.army2.name, 2);
            army2 = this.army2;
            return station2;
        }
        public Station ForRedo(Army army1, Army army2)
        {
            undo = false;
            var station2 = new Station(army1, army2);
            army1 = new Army(this.army1.name, 2);
            army1 = this.army1;
            army2 = new Army(this.army2.name, 2);
            army2 = this.army2;
            return station2;
        }
    }
}

