using System;
using System.Collections.Generic;

namespace AdapterPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MallardDuck duck = new MallardDuck();
            
            WildTurkey turkey = new WildTurkey();
            Duck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The Turkey says...");
            turkey.gobble();
            turkey.fly();

            Console.WriteLine("\nThe Duck says...");
            TestDuck(duck);

            Console.WriteLine("\nThe TurkeyAdapter says...");
            TestDuck(turkeyAdapter);

        }

        static void TestDuck(Duck duck)
        {
            duck.quack();
            duck.fly();
        }
    }
}