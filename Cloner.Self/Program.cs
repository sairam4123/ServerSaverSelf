using Cloner.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloner.Self
{
    public class Program
    {
        //User token: ctrl+shift+i -> Network -> Go to a channel you havent opened yet in discord -> look for the request messages?limit=50 -> go to request headers -> authorization: ...

        public static void Main(string[] args)
        {
            new Program().RunAsync().GetAwaiter().GetResult();
        }

        public async Task RunAsync()
        {
            using (var client = new HttpClient())
            {

                Console.WriteLine("Token: ");
                var token = Console.ReadLine();
                Console.WriteLine("Guild ID: ");
                var gId = ulong.Parse(Console.ReadLine());

                Console.WriteLine("Saving...");
                try
                {
                    SaveMethods1.Log += LogEvent;
                    var save = await SaveMethods1.FromToken(false, token, gId, client);

                    var saveStr = save.ToCompressedString();
                    var filePath = Path.Combine(AppContext.BaseDirectory, $"{save.Guild.Name.Filter()}-{save.GetSaveTime().ToString("HH-mm-ss dd-MM-yy")}.clone");
                    File.WriteAllText(filePath, saveStr);
                    Console.WriteLine($"Save Complete, saved to {filePath}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.ReadKey();
            }
        }

        private void LogEvent(object sender, string e)
        {
            Console.WriteLine(e);
        }
    }
}
