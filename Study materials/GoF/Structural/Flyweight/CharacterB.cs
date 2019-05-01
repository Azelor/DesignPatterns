using System;

namespace GoF.Structural.Flyweight
{
    class CharacterB : Character
    {
        public CharacterB()
        {
            symbol = 'B';
            height = 100;
            width = 140;
            ascent = 72;
            descent = 0;
        }

        public override void Display()
        {
            Console.WriteLine(symbol);
        }
    }
}