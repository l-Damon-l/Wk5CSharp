using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        public static async Task Main(string[] args) {
            Console.WriteLine("Welcome to my birthday party");
            await HaveAPartyAsync();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static async Task HaveAPartyAsync() {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            var pizzaTask = OrderPizzaAsync();
            PlayPartyGames();
            OpenPresents();
            await pizzaTask;
            var cake = await cakeTask;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        private static async Task<Cake> BakeCakeAsync() {
            Console.WriteLine("Cake is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static async Task OrderPizzaAsync() {
            Console.WriteLine("Pizza has been ordered");
            await Task.Delay(TimeSpan.FromSeconds(4));
            Console.WriteLine("Pizza delivered");
            Console.WriteLine("Eating the pizza...");
        }

        private static void PlayPartyGames() {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void OpenPresents() {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString() {
            return "Here's a cake";
        }
    }
}

