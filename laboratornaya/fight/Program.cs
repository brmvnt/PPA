using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace age_of_war
{
    class Game
    {
        int i = 1;
        public readonly int ArmyPrice = 100;
        MenuForCommand menuForcommand;
        Invoker invoker;
        StacksOfStations stations;
        public Game() {
            menuForcommand = new MenuForCommand();
            invoker = new Invoker();
            stations = new StacksOfStations();
        }
        public void Start()
        {
            bool undo = false;
            bool cont = false;
            var army1 = new Army("Мы победим", i);
            var army2 = new Army("Computer", i);
            ArrayOfArmies ar1 = new ArrayOfArmies(army1.name, army1.army.Count());
            ArrayOfArmies ar2 = new ArrayOfArmies(army2.name, army2.army.Count());
            ar1.array[0] = army1;
            ar2.array[0] = army2;
            var station = new Station(ar1, ar2, i);
            stations.stForUndo.Push(station);
            while (ar1.CountUnits() > 0 && ar2.CountUnits() > 0)
            {
                if (stations.stForRedo.Count != 0) undo = true;
                GeneralStep(ar1, ar2);
                if (!cont)
                    cont = CheckCommand(ar1, ar2, station, undo);
                #region
                //{
                //    if (i != 1 || undo == true)
                //    {
                //        int c;
                //        if (!undo)
                //        {
                //            c = menuForcommand.ShowMenu1();
                //            ;
                //        }
                //        else
                //        {
                //            c = menuForcommand.ShowMenu2();
                //        }
                //        if (c == 3)
                //        {
                //            cont = true;
                //        }
                //        else
                //        {
                //            if (c != 0)
                //            {
                //                i = invoker.SetUndoRedo(stations, c, ar1, ar2, i);
                //                if (c == 1) continue;
                //            }
                //            else
                //            {
                //                station = new Station(ar1, ar2, i);
                //                stations.stForUndo.Push(station);
                //            } }}
                #endregion
                undo = false;
            }
            Congrats(ar1, ar2);
        }
        public bool CheckCommand(ArrayOfArmies ar1, ArrayOfArmies ar2, Station station, bool undo) {
            bool cont = false;
            if (i != 1 || undo == true)
            {
                int c;
                if (!undo) c = menuForcommand.ShowMenu1();
                else c = menuForcommand.ShowMenu2();
                if (c == 3) cont = true;
                else
                {
                    if (c != 0)
                    {
                        i = invoker.SetUndoRedo(stations, c, ar1, ar2, i);
                       // if (c == 1) continue;
                    }
                    else
                    {
                        station = new Station(ar1, ar2, i);
                        stations.stForUndo.Push(station);
                    }
                }
            }
            return cont;
        }
        public void GeneralStep(ArrayOfArmies ar1, ArrayOfArmies ar2)
        {
            var action = new Action();
            var menuForStrategy = new MenuForStrategy();
            int str = menuForStrategy.ShowMenu1();
                if (str == 1)
                    action.Strategy = new MainStrategy();
                if (str == 2)
                    action.Strategy = new ThreeInRowStrategy();
                if (str == 3)
                    action.Strategy = new SquadStrategy();
                action.Strategy.Algorithm(ar1, ar2, action, i); // 
            i++;
        }

        static public void Congrats(ArrayOfArmies ar1, ArrayOfArmies ar2)
        {
            if (ar1.CountUnits() == 0 && ar2.CountUnits() != 0)
                Console.WriteLine($"{ar2.name} won");
            if (ar1.CountUnits() != 0 && ar2.CountUnits() == 0)
                Console.WriteLine($"{ar1.name} won");
            if (ar1.CountUnits() == 0 && ar2.CountUnits() == 0)
                Console.WriteLine("nobody won");
        }
    }
    class Program
    {
        public static int Main()
        {
            var game = new Game();
            game.Start();
            return 0;
        }
    }
}