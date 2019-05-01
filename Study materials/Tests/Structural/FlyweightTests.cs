using GoF.Structural.Flyweight;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Structural
{
    [TestClass]
    public class FlyweightTests
    {
        private string document;
        public char[] Chars { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            document = "AAZZBBZB";
            Chars = document.ToCharArray();
        }

        [TestMethod]
        public void GetCharacterReturnsCorrectClassTest()
        {
            char charA = 'A';
            CharacterFactory factory = new CharacterFactory();
            
            Character character = factory.GetCharacter(charA);

            Assert.IsInstanceOfType(character, typeof(CharacterA));
        }

        [TestMethod]
        public void GetCharacterReturnsExistingCharacterObject()
        {
            char firstA = 'A';
            char secondA = 'A';
            CharacterFactory factory = new CharacterFactory();

            Character firstResult = factory.GetCharacter(firstA);
            Character secondResult = factory.GetCharacter(secondA);

            Assert.AreSame(firstResult, secondResult);
        }
    }
}