namespace GoF.Behavioral.Mediator
{
    public class NonBeatle : Participant {
        public NonBeatle(string name) : base(name) { }

        public override void Receive(string from, string message) {
            base.Receive(from, message);
            Chatroom.messagesToNonBeatles.Add(from + " to " + Name + ": " + message);
        }
    }
}