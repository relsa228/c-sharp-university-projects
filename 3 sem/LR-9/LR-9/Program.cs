using LR_9.Domain;

namespace LR_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory("Прорезиненные палки для швабр", 228);
            string suka = factory.Specialization;
        }
    }
}