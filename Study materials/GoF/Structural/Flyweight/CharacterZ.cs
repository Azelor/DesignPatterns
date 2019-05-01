using System;

namespace GoF.Structural.Flyweight
{
    class CharacterZ : Character
    {
        public CharacterZ()
        {
            symbol = 'Z';
            height = 100;
            width = 100;
            ascent = 68;
            descent = 0;
        }

        public override void Display()
        {
            Console.WriteLine(symbol);
        }
    }
}