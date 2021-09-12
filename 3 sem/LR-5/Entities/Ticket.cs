using System;

namespace LR_4.Entities
{
    public class Ticket : IComparable
    {
        public string StartPoint { get; set; }
        public string FinishPoint { get; set; }
        public float Price { get; set; }
        public string BortNum { get; set; }
        public string Date { get; set; }

        public Ticket()
        {
            StartPoint = "";
            FinishPoint = "";
            Price = 0;
            BortNum = "";
            Date = "";
        }

        public bool FindSuitable(string startPoint, string finishPoint)
        {
            if (this.StartPoint == startPoint && this.FinishPoint == finishPoint)
                return true;
            return false;
        }

        public void TicketInfo()
        {
            Console.WriteLine("\nНомер рейса: " + this.BortNum + "\nТочка отправления: " + this.StartPoint +
                              "\nТочка прибытия: " + this.FinishPoint + "\nДата вылета: " + this.Date
                              + "\nЦена билета: " + this.Price);
        }

        public int CompareTo(object obj)
        {
            Ticket temp = obj as Ticket;
            if (temp.StartPoint == this.StartPoint && temp.FinishPoint == this.FinishPoint &&
                temp.Date == this.Date && temp.BortNum == this.BortNum && temp.Price == this.Price)
                return 0;
            return 1;
        }
    }
}