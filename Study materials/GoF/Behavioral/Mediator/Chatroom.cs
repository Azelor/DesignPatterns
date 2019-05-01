using System.Collections.Generic;

namespace GoF.Behavioral.Mediator
{
    public class Chatroom : AbstractChatroom {

        public readonly List<string> allMessages = new List<string>();
        public readonly List<string> messagesToBeatles = new List<string>();
        public readonly List<string> messagesToNonBeatles = new List<string>();
        private readonly Dictionary<string, Participant> participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant) {
            if (!participants.ContainsValue(participant)) {
                participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message) {
            var participant = participants[to];
            participant?.Receive(from, message);
        }
    }
}