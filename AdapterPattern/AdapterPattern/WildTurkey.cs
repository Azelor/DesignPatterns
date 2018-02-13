using System;

namespace AdapterPattern
{
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
}