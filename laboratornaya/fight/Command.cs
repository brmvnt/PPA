using System;
using static System.Collections.Specialized.BitVector32;

namespace age_of_war
{
    public interface ICommand
    {
        public int Redo(Station station, Army army1, Army army2, int i);
        public int Undo(Station station, Army army1, Army army2, int i);
    }
    public class Command : ICommand
    {
        public int Redo(Station station, Army army1, Army army2, int i)
        {
            var station2 = station.ForRedo(army1, army2);
            station = station2;
            return i + 1;
        }
        public int Undo(Station station, Army army1, Army army2, int i)
        {
            var station2 = station.ForUndo(army1, army2);
            station = station2;
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
        public int SetUndoRedo(int choice, Station station, Army army1, Army army2, int i) {
            if (choice == 1) return PressUndo(station, army1, army2, i);
            if (choice == 2) return PressRedo(station, army1, army2, i);
            else return 0;
        }
        static public int PressRedo(Station station, Army army1, Army army2, int i)
        {
            return command.Redo(station, army1, army2, i);
        }
        static public int PressUndo(Station station, Army army1, Army army2, int i)
        {
            return command.Undo(station, army1, army2, i);
        }
    }
}

