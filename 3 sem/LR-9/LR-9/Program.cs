using System.Collections.ObjectModel;
using LR_9.Domain.Factory;

namespace LR_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory1 = new Factory("Прорезиненные палки для швабр", 228, 1000);
            Factory factory2 = new Factory("Водка Коленвал", 1337, 30);
            Factory factory3 = new Factory("Бюсты Ленина", 1488, 6000000);
            Factory factory4 = new Factory("Пыняходы", 168, 2000);
            Factory factory5 = new Factory("Кипы", 666, 666);
            Factory factory6 = new Factory("Дагестанские кирпичи", 140000000, -28);

            Collection<Factory> collection = new Collection<Factory>();
            collection.Add(factory1);
            collection.Add(factory2);
            collection.Add(factory3);
            collection.Add(factory4);
            collection.Add(factory5);
            collection.Add(factory6);

            Serializer.Serializer serializer = new Serializer.Serializer();
            
            serializer.SerializeByLINQ(collection, "FactoriesLINQ.xml");
            serializer.SerializeXML(collection, "FactoriesXML.xml");
            serializer.SerializeJSON(collection, "FactoriesJson.json");

            Collection<Factory> outCollection = new Collection<Factory>();
            foreach (var factory in serializer.DeSerializeByLINQ("FactoriesLINQ.xml"))
                outCollection.Add(factory);
            
            foreach (Factory employee in outCollection)
                employee.Info();
        }
    }
}