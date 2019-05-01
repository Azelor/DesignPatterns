using System;

namespace GoF.Structural.Flyweight
{
    class CharacterA : Character
    {
        public CharacterA()
        {
            symbol = 'A';
            height = 100;
            width = 120;
            ascent = 70;
            descent = 0;
        }

        public override void Display()
        {
            Console.WriteLine(symbol);
        }
    }
}