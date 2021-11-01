using LR_9.Domain;
using LR_9.Domain.Factory;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace Serializer
{
    public class Serializer:ISerializer
    {
        public IEnumerable<Factory> DeSerializeByLINQ(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Factory> DeSerializeXML(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Factory> DeSerializeJSON(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void SerializeByLINQ(IEnumerable<Factory> factories, string fileName)
        {
            XDocument factoriesXml = new XDocument();
            XElement factoriesRoot = new XElement("Factories");
            foreach (var factoryEl in factories)
            {
                XElement factory = new XElement("Factory");
                XAttribute factorySpecialization = new XAttribute("Specialization", factoryEl.Specialization);
                XAttribute factoryWorkers = new XAttribute("Workers", factoryEl.Workers);
                XAttribute factoryBudget = new XAttribute("Budget", factoryEl.Budget);
                XElement factoryDetails = new XElement("DetailsInWarehouse", factoryEl.DetailWarehouse.InWarehouse);
                XElement factoryProducts = new XElement("ProductsInWarehouse", factoryEl.ProductWarehouse.InWarehouse);
                factory.Add(factorySpecialization);
                factory.Add(factoryWorkers);
                factory.Add(factoryBudget);
                factory.Add(factoryDetails);
                factory.Add(factoryProducts);
                factoriesRoot.Add(factory);
             
            }
            factoriesXml.Add(factoriesRoot);
            
            if(File.Exists(fileName))
                File.Delete(fileName);
            
            factoriesXml.Save(fileName);
        }

        public void SerializeXML(IEnumerable<Factory> factories, string fileName)
        {
            throw new System.NotImplementedException();
        }

        public void SerializeJSON(IEnumerable<Factory> factories, string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}