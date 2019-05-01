using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoF.Behavioral.Mediator;

namespace Tests.Behavioral {
    [TestClass] public class MediatorTests
    {
        private Chatroom chatroom;
        readonly Participant george = new Beatle("George");
        readonly Participant paul = new Beatle("Paul");
        readonly Participant ringo = new Beatle("Ringo");
        readonly Participant john = new Beatle("John");
        readonly Participant yoko = new NonBeatle("Yoko");

        [TestInitialize]
        public void Initialize()
        {
            chatroom = new Chatroom();
            chatroom.Register(george);
            chatroom.Register(paul);
            chatroom.Register(ringo);
            chatroom.Register(john);
            chatroom.Register(yoko);
        }

        [TestMethod]
        public void SendMessageToBeatlesTest() {
            yoko.Send("John", "Hi John!");

            Assert.AreEqual(chatroom.messagesToBeatles[0], "Yoko to John: Hi John!");
        }

        [TestMethod]
        public void SendMessageToNonBeatlesTest()
        {
            john.Send("Yoko", "My sweet love");

            Assert.AreEqual(chatroom.messagesToNonBeatles[0], "John to Yoko: My sweet love");
        }

        [TestMethod]
        public void SendMessagesToBeatlesAndNonBeatlesTest()
        {
            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");

            Assert.AreEqual(chatroom.allMessages.Count, 5);
            Assert.AreEqual(chatroom.messagesToBeatles.Count, 4);
            Assert.AreEqual(chatroom.messagesToNonBeatles.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void SendMessageToUnregisteredUserTest()
        {
            john.Send("Nobody", "Are you there?");
        }
    }
}