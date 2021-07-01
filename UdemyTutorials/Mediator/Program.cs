using System.Text;
using static System.Console;

namespace Mediator
{

    class Program
    {
        public static void PrintValues(params Participant[] participants)
        {
            var sb = new StringBuilder("Participants:\n");
            foreach (var p in participants)
            {
                sb.AppendLine($"{p.Name} Value: {p.Value}");
            }
            sb.AppendLine();

            Write(sb.ToString());
        }

        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var participant1 = new Participant(mediator, "John");
            var participant2 = new Participant(mediator, "Jane");
            PrintValues(participant1, participant2);

            participant1.Say(3);
            PrintValues(participant1, participant2);

            participant2.Say(2);
            PrintValues(participant1, participant2);

            ReadKey();
        }
    }
}
