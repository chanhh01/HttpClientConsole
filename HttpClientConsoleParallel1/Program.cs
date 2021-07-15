using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Net;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config", Watch = true)]
namespace HttpClientConsoleParallel1
{
    class Program
    {
        private static List<int> time = new List<int>();
        private static readonly ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                //local machine = https://localhost:44381/api/
                //storeAPI.exe VM = http://localhost:5000/api/
                //IIS VM = http://localhost:8081/api/
                client.BaseAddress = new Uri("https://localhost:44381/api/");

                //HTTP GET
                System.Net.ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12;

                await fireLoop(client);

            }
        }

        public static async Task ConsumeAPI(HttpClient client) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //HTTP GET
            var responseTask = client.GetAsync("Store");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    var readTask = result.Content.ReadAsAsync<Store[]>();
                    readTask.Wait();

                    var stores = readTask.Result;

                    stopwatch.Stop();
                    log.Info(stopwatch.ElapsedMilliseconds + "ms");
                    int i = (int)stopwatch.ElapsedMilliseconds;
                    time.Add(i);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public static async Task fireLoop(HttpClient client)
        {
            time.Clear();
            Console.WriteLine("Enter the amount of loop.");
            string loopselection = Console.ReadLine();
            int j = int.Parse(loopselection);
            List<int> ret = new List<int>(j);
            ret.AddRange(Enumerable.Repeat(default(int), j));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            log.Info(DateTime.Now);
            Parallel.ForEach(ret, x =>
            {
                ConsumeAPI(client);
            });
            while (true)
            {
                if(time.Count() == j)
                {
                    stopwatch.Stop();
                    break;
                }
            }
            log.Info("==============================END================================");
            log.Info("The number of attempts: " + time.Count());
            log.Info("The minimum time taken: " + time.Min());
            log.Info("The average time taken: " + time.Average());
            log.Info("The maximum time taken: " + time.Max());
            log.Info("Time Elapsed: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("");
            Console.WriteLine("Continue to loop? '1' for yes, '0' to close");
            string loopcontinue = Console.ReadLine();
            if (loopcontinue == "1")
            {
                await fireLoop(client);
            }
            else if (loopcontinue == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
