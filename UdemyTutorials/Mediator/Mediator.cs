using System.Collections.Generic;

namespace Mediator
{
    public class Mediator
    {
        private readonly List<Participant> participants = new List<Participant>();

        public void Join(Participant participant)
        {
            participants.Add(participant);
        }

        public void Send(Participant source, int value)
        {
            foreach (var p in participants)
            {
                if (p != source)
                {
                    p.Value += value;
                }
            }
        }
    }
}
