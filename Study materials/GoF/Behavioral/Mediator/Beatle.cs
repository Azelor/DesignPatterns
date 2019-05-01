namespace GoF.Behavioral.Mediator
{
    public class Beatle : Participant {

        public Beatle(string name) : base(name) { }

        public override void Receive(string from, string message) {
            base.Receive(from, message);
            Chatroom.messagesToBeatles.Add(from + " to " + Name + ": " + message);
        }
    }
}