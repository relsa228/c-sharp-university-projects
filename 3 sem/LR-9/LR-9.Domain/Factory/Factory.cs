using System;

namespace LR_9.Domain.Factory
{
    public class Factory
    {
        public Warehouse DetailWarehouse = new Warehouse("Валерий Альбертович Шпак");
        public Warehouse ProductWarehouse = new Warehouse("Богомолов Александр Александрович");
        public int Workers;
        public readonly string Specialization;
        public int Budget;
        
        public Factory(string specialization, int workers, int budget)
        {
            Specialization = specialization;
            Workers = workers;
            Budget = budget;
        }
        public void ProduceProducts(int count)
        {
            if (this.DetailWarehouse.RemoveFromWarehouse(10*count) && this.ProductWarehouse.AddToWarehouse(count))
                Console.WriteLine("Произведено " + count + " продуктов по специализации.");
            else
                Console.WriteLine("Ошибка при производстве.");
        }

        public void BuyDetails(int count)
        {
            if (Budget < count * 100 && DetailWarehouse.AddToWarehouse(count))
                Console.WriteLine("Ошибка при покупке.");
            else
            {
                Budget -= count * 100;
                Console.WriteLine("Куплено " + count + " деталей.");
            }
        }

        public void SaleProducts(int count)
        {
            if (ProductWarehouse.RemoveFromWarehouse(count))
            {
                Budget += 10000 * count;
                Console.WriteLine("Продано " + count + " деталей.\nПолучено " + 10000 * count + " долларов.");
            }
            else
                Console.WriteLine("На складе не хватает изделий.");
        }
    }
}