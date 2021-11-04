using System;
using System.Collections.ObjectModel;
using LR_9.Domain.Factory;

namespace LR_9
{
    class Program
    {
        static void Main(string[] args)
        {
           Collection<Factory> collection = new Collection<Factory>();
            collection.Add(new Factory("Прорезиненные палки для швабр", 228, 1000));
            collection.Add(new Factory("Водка Коленвал", 1337, 30));
            collection.Add(new Factory("Бюсты Ленина", 1488, 6000000));
            collection.Add(new Factory("Пыняходы", 168, 2000));
            collection.Add(new Factory("Кипы", 666, 666));
            collection.Add(new Factory("Дагестанские кирпичи", 140000000, -28));

            Serializer.Serializer serializer = new Serializer.Serializer();
            serializer.SerializeByLINQ(collection, "FactoriesLINQ.xml");
            serializer.SerializeXML(collection, "FactoriesXML.xml");
            serializer.SerializeJSON(collection, "FactoriesJson.json");
            
            Collection<Factory> outCollectionLinq = new Collection<Factory>();
            Console.WriteLine("\nВывод из файла LINQ:");
            foreach (var factory in serializer.DeSerializeByLINQ("FactoriesLINQ.xml"))
                outCollectionLinq.Add(factory);
            foreach (Factory factory in outCollectionLinq)
                factory.Info();
            
            Collection<Factory> outCollectionXml = new Collection<Factory>();
            Console.WriteLine("\nВывод из файла XML:");
            foreach (var factory in serializer.DeSerializeXML("FactoriesXML.xml"))
                outCollectionXml.Add(factory);
            foreach (Factory factory in outCollectionXml)
                factory.Info();

            Collection<Factory> outCollectionJson = new Collection<Factory>();
            Console.WriteLine("\nВывод из файла JSON:");
            foreach (var factory in serializer.DeSerializeJSON("FactoriesJson.json"))
                outCollectionJson.Add(factory);
            foreach (Factory factory in outCollectionJson)
                factory.Info();
        }
    }
}