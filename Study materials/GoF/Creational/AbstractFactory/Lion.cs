using System;

namespace GoF.Creational.AbstractFactory
{
    class Lion : Carnivore

    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }
}