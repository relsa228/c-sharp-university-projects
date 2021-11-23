using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SinIntegrate;
using WorkerLib;


namespace LR_11
{
    class Program
    {
        static async Task Main(string[] args) 
        {
            //Первое задание
            object first = "высокий приоритет";
            object second = "низкий приоритет";
            
            Integrate integrate = new Integrate();
            integrate.Finish += integrate.Result;
            
            Thread threadFirst = new Thread(integrate.Integration);
            threadFirst.Priority = ThreadPriority.Highest;
            
            Thread threadSecond = new Thread(integrate.Integration);
            threadSecond.Priority = ThreadPriority.Lowest;
            
            threadFirst.Start(first);
            threadSecond.Start(second);

            Console.ReadKey();
            
            //Второе задание
            using (MemoryStream stream = new MemoryStream())
            {
                StreamService service = new StreamService();
                Func<Worker, bool> retFunc = Filter;
                
                Task writeToStream = service.WriteToStream(stream);
                Task copyFromStream = service.CopyFromStream(stream, "Test.txt");
                
                Console.WriteLine($"Статус задачи WriteToStream: {writeToStream.Status}");
                writeToStream.Start();
                Console.WriteLine($"Статус задачи WriteToStream: {writeToStream.Status}");
                writeToStream.Wait();
                Console.WriteLine($"Статус задачи WriteToStream: {writeToStream.Status}");
                
                Console.WriteLine("=============================================");

                Console.WriteLine($"Статус задачи CopyFromStream: {copyFromStream.Status}");
                copyFromStream.Start();
                Console.WriteLine($"Статус задачи CopyFromStream: {copyFromStream.Status}");
                copyFromStream.Wait();
                Console.WriteLine($"Статус задачи CopyFromStream: {copyFromStream.Status}");
                
                Console.WriteLine("---------------------------------------------");
                
                Task<int> stat =  Task.Run(()=>service.GetStatisticsAsync("Test.txt", retFunc));

                Console.WriteLine($"\nКоличество объектов, удовлетворяющих условию: {stat.Result}");
            }
        }

        public static bool Filter(Worker worker)
        {
            if (worker.Age > 35)
                return true;
            return false;
        }
    }
}