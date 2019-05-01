using System.Collections.Generic;

namespace GoF.Structural.Flyweight
{
    class CharacterFactory
    {
        private readonly Dictionary<char, Character> characters =
            new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            Character character = null;
            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else

            {
                switch (key)
                {
                    case 'A': character = new CharacterA(); break;
                    case 'B': character = new CharacterB(); break;
                    // ...
                    case 'Z': character = new CharacterZ(); break;
                }
                characters.Add(key, character);
            }
            return character;
        }
    }
}