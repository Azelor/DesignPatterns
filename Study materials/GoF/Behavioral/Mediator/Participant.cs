namespace GoF.Behavioral.Mediator
{
    public class Participant {
        public Participant(string name) { Name = name; }

        public string Name { get; }
        public Chatroom Chatroom { set; get; }

        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        public virtual void Receive(string from, string message) {
            Chatroom.allMessages.Add(from + " to " + Name + ": " + message);
        }
    }
}