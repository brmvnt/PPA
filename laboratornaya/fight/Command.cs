﻿using System;
using static System.Collections.Specialized.BitVector32;

namespace age_of_war
{
    public interface ICommand
    {
        public int Redo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i);
        public int Undo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i);
    }
    public class Command : ICommand
    {
        public int Redo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i)
        {
            var station1 = new Station(ar1, ar2, i);
            var station = stations.stForRedo.Pop();
            stations.stForUndo.Push(station1);
            for (int j = 0; j < ar1.armyNumber; j++)
            {
                ar1.array[j] = station.ar1.array[j].DeepCopy() as Army;
            }
            for (int j = 0; j < ar2.armyNumber; j++)
            {
                ar2.array[j] = station.ar2.array[j].DeepCopy() as Army;
            }
            //ar1 = station.ar1;
            //ar2 = station.ar2;
            //var station2 = station.ForRedo(ar1, ar2);
            //station = station2;
            return i + 1;
        }
        public int Undo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i)
        {
            var station1 = new Station(ar1, ar2, i);
            stations.stForRedo.Push(station1);
            var station = stations.stForUndo.Pop();
            for (int j = 0; j < ar1.armyNumber; j++)
            {
                ar1.array[j] = station.ar1.array[j].DeepCopy() as Army;
            }
            for (int j = 0; j < ar2.armyNumber; j++)
            {
                ar2.array[j] = station.ar2.array[j].DeepCopy() as Army;
            }
            //ar1 = station.ar1;
            //ar2 = station.ar2;
            //var station2 = station.ForUndo(ar1, ar2);
            //station = station2;
            return i - 1;
        }
    }
    class Invoker
    {
        static ICommand ?command;

        public Invoker()
        {
            command = new Command();
        }
        public int SetUndoRedo(StacksOfStations stations, int choice, ArrayOfArmies ar1, ArrayOfArmies ar2, int i)
        {
            if (choice == 1) return PressUndo(stations, ar1, ar2, i);
            if (choice == 2) return PressRedo(stations, ar1, ar2, i);
            else return 0;
        }
        static public int PressRedo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i)
        {
            return command.Redo(stations, ar1, ar2, i);
        }
        static public int PressUndo(StacksOfStations stations, ArrayOfArmies ar1, ArrayOfArmies ar2, int i)
        {
            return command.Undo(stations, ar1, ar2, i);
        }
    }
}

