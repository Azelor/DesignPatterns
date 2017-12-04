using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Adapter
{
    public class DuckTestDrive
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
    
    

    public interface Duck
    {
        void quack();
        void fly();
    }

    public class MallardDuck : Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }

        public void fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public interface Turkey
    {
        void gobble();
        void fly();
    }

    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble!");
        }

        public void fly()
        {
            Console.WriteLine("I'm flying a short distance!");
        }
    }
    
    // Here comes the adapter!
    // First you need to implement the interface of the type you're adapting to.
    // This is the interface your client expects to see.
    public class TurkeyAdapter : Duck
    {
        private Turkey turkey;

        // Next, we need to get a reference to the object that we are adapting.
        // Here we do that through the constructor
        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }
        
        // Now we need to implement all the methods in the interface.
        // The quack() translation between classes is easy: just call the gobble() method.
        public void quack()
        {
            turkey.gobble();
        }
        
        // Even though both interfaces have a fly() method, Turkeys fly in short spurts - 
        // they can't do long-distance flying like ducks. To map between a Duck's fly() method
        // and a Turkey's, we need to call the Turkey's fly method five times to make up for it.
        public void fly()
        {
            for (int i = 0; i < 5; i++)
            {
                turkey.fly();
            }
        }
    }
}