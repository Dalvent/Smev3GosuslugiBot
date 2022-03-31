using System.Linq;
using Smev3GosuslugiBot.State;

namespace Smev3GosuslugiBot.CoR
{
    public static class CoRFactory
    {
        public static ElementInCoR CreateWithUnknownAtEnd(IMessageReceiver messageReceiver, ElementInCoR[] elementInCoRs)
        {
            if(elementInCoRs.Length == 0)
                return new UnkownCommandCoR(messageReceiver);

            ElementInCoR root = elementInCoRs.First();

            ElementInCoR last = root;
            for (int i = 1; i < elementInCoRs.Length; i++)
            {
                last.SetNext(elementInCoRs[i]);
                last = elementInCoRs[i];
            }

            last.SetNext(new UnkownCommandCoR(messageReceiver));

            return root;
        }
    }
}