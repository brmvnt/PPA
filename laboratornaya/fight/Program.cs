using System;
using System.Collections.Generic;
namespace age_of_war
{
    class Game
    {
        public void Start() {
            var li = new LightInfantry();
            var hi = new HeavyInfantry();
            var k = new Knight();
            var first = new List<Unit>() { k, hi, k };
            var army1 = new Queue<Unit>(first);  //сделать армию отдельным классом
            var second = new List<Unit>() { li, hi, li };
            var army2 = new Queue<Unit>(second);
            int i = 1;
            while  (army1.Count > 0 && army2.Count > 0) {
                Step(i, army1, army2);
                if (army2.Count > 0)
                    Step(i, army2, army1);
                i++;
            }
            Congrats(army1, army2);
        }
        public void Congrats(Queue<Unit> army1, Queue<Unit> army2)
        {
            if (army1.Count == 0 && army2.Count != 0)
                Console.WriteLine("army2 won");
            if (army1.Count != 0 && army2.Count == 0)
                Console.WriteLine("army1 won");
            if (army1.Count == 0 && army2.Count == 0)
                Console.WriteLine("nobody won");
        }
        public void Step(int i, Queue<Unit> army1, Queue<Unit> army2) {
            var person1 = army1.Peek();
            var person2 = army2.Peek();
            person2.GetHit(person1.Attack);
            Death(i, person1, person2,  army2, army1); //rename
        }
        public void Death(int i, Unit person1, Unit person2,Queue<Unit> army2, Queue<Unit> army1)
        { 
            Unit soul = null;
            if (!person2.IsStillAlive()) // если не живой
            { 
                soul = army2.Dequeue(); // удаляем из очереди
            }
            PrintResult(i, army1, army2, soul);
        }
        public void PrintResultAttack(Queue<Unit> army1, Queue<Unit> army2)
        {
            var atUnit = army1.Peek();
            Console.WriteLine($"{atUnit.ToString()} аттаковал с силой {atUnit.Attack}");
        }
        public void PrintResultDefence(Queue<Unit> army2, Unit soul)
        {
           if (soul != null)
                Console.WriteLine($"{soul.ToString()} с защитой {soul.Defence} был убит");
           else
                Console.WriteLine($"{army2.Peek().ToString()} с защитой {army2.Peek().Defence} остался жив");
        }
        public void PrintResult(int i, Queue<Unit> army1, Queue<Unit> army2, Unit soul)
        {
            Console.WriteLine($"{i} ход");
            PrintResultAttack(army1, army2);
            PrintResultDefence(army2, soul);
        }
    }
    class Program
    {
        public static int Main() {
            var game = new Game();
            game.Start();
            return 0;
        }
    }
}