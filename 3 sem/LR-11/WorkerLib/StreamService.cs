using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorkerLib
{
    public class StreamService
    {
        public Task WriteToStream(Stream stream)
        {
            Task writeTask = new Task(() =>
            {
                List<Worker> list = new List<Worker>();
                Random rand = new();
                for (int i = 0; i < 100; i++)
                    list.Add(new Worker(i, rand.Next(20, 65), "Жмышенко Валерий Альбертович"));

                using (FileStream fs = new FileStream("Temp.json", FileMode.OpenOrCreate))
                {
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    JsonSerializer.SerializeAsync<List<Worker>>(fs, list.ToList(), options).Wait();
                }

                using (FileStream file = new FileStream("Temp.json", FileMode.Open, FileAccess.Read))
                    file.CopyTo(stream);

                File.Delete("Temp.json");
            });
            return writeTask;
        }

        public Task CopyFromStream(MemoryStream stream, string fileName)
        {
            Task copyTask = new Task(() =>
            {
                using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    stream.WriteTo(file);
                }
            });
            
            return copyTask;
        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<Worker, bool> filter)
        {
            Task<int> statTask = Task.Run(() =>
            {
                int result = 0;
                List<Worker> workers;

                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    var options = new JsonSerializerOptions { IncludeFields = true };
                    workers = JsonSerializer.DeserializeAsync<List<Worker>>(fs, options).Result;
                }

                if (workers != null)
                    foreach (var worker in workers)
                    {
                        if (filter(worker))
                        {
                            Console.WriteLine(worker.Info());
                            result++;
                        }
                    }

                return result;
            });
            return await statTask;
        }
    }
}