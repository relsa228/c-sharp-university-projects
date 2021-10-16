using System;

namespace LR_9.Domain
{
    public class PartsWarehouse
    {
        internal int InWarehouse;
        private int MaxCapacity;
        private string HeadOfWarehouse;

        public PartsWarehouse(string headOfWarehouse)
        {
            InWarehouse = 0;
            MaxCapacity = 100;
            HeadOfWarehouse = headOfWarehouse;
        }

        public void AddToWarehouse(int count)
        {
            this.InWarehouse =+ count;
            if (this.InWarehouse > this.MaxCapacity)
            {
                Console.WriteLine("Склад заполнен.");
                this.InWarehouse = 100;
            }
            else
                Console.WriteLine("Добавлено " + count + " деталей.");
        }

        public bool RemoveFromWarehouse(int count)
        {
            int temp = this.InWarehouse; 
            this.InWarehouse =- count;
            if (this.InWarehouse < 0)
            {
                Console.WriteLine("На складе недостаточно деталей.\nВы взяли всего " + temp + ".");
                this.InWarehouse = 0;
                return false;
            }
            
            Console.WriteLine("Взято " + count + " деталей.");
            return true;
        }
    }
}