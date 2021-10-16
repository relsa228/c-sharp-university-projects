using System;

namespace LR_9.Domain
{
    public class Factory
    {
        public PartsWarehouse PartsWarehouse = new PartsWarehouse("Валерий Альбертович Шпак");
        public int Workers { get; set; }
        public string Specialization { get; }
        
        public Factory(string specialization, int workers)
        {
            Specialization = specialization;
            Workers = workers;
        }

        public void ProduceProducts(int count)
        {
            if (this.PartsWarehouse.RemoveFromWarehouse(10*count))
                Console.WriteLine("Произведено " + count + " продуктов по специализации.");
            else
                Console.WriteLine("На складе недостаточно деталей.");
        }

        public void BuyDetails(int count)
        {
            
        }
    }
}