using Telegram.Bot;

namespace Smev3GosuslugiBot
{
    internal class Program
    {
        private static ITelegramBotClient _bot;

        public static void Main(string[] args)
        {
            var token = GetToken();
            Console.WriteLine(token);
            Console.ReadKey();

            Console.ReadKey();
            Console.WriteLine(token);
            //_bot = new TelegramBotClient(token);
        }
        
        public static string GetToken()
        {
            return File.ReadAllText("token.txt");
        }
    }
}