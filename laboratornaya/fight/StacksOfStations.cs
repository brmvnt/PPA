using System;
namespace age_of_war
{
    public class StacksOfStations
    {
        public Stack<Station> stForUndo;
        public Stack<Station> stForRedo;
        public StacksOfStations()
        {
            stForUndo = new Stack<Station>();
            stForRedo = new Stack<Station>();
        }
        //public void UpdateStation(ArrayOfArmies ar1, ArrayOfArmies ar2)
        //{
        //    //Prototype
        //    //this.army1 = new Army(army1.name, 2);
        //    this.army1 = army1.DeepCopy() as Army;
        //    //this.army2 = new Army(army2.name, 2);
        //    this.army2 = army2.DeepCopy() as Army;
        //}
        //public Station ForUndo(ArrayOfArmies ar1, ArrayOfArmies ar2)
        //{
        //    //undo = true;
        //    var station2 = new Station(ar1, ar2);
        //    //army1 = new Army(this.army1.name, 2);
        //    army1 = this.army1.DeepCopy() as Army;
        //    //army2 = new Army(this.army2.name, 2);
        //    army2 = this.army2.DeepCopy() as Army;
        //    return station2;
        //}
        //public Station ForRedo(ArrayOfArmies ar1, ArrayOfArmies ar2)
        //{
        //    undo = false;
        //    var station2 = new Station(army1, army2);
        //    //army1 = new Army(this.army1.name, 2);
        //    army1 = this.army1.DeepCopy() as Army;
        //    //army2 = new Army(this.army2.name, 2);
        //    army2 = this.army2.DeepCopy() as Army;
        //    return station2;
        //}
    }
}

