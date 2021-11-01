using System;
using LR_9.Domain;
using LR_9.Domain.Factory;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serializer
{
    public class Serializer:ISerializer
    {
        public IEnumerable<Factory> DeSerializeByLINQ(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);
            
            foreach (XElement phoneElement in xdoc.Element("Factories").Elements("Factory"))
            {
                XAttribute factorySpecialization = phoneElement.Attribute("Specialization");
                XAttribute factoryWorkers = phoneElement.Attribute("Workers");
                XAttribute factoryBudget = phoneElement.Attribute("Budget");
                XElement factoryDetails = phoneElement.Element("DetailsInWarehouse");
                XElement factoryProducts = phoneElement.Element("ProductsInWarehouse");

                Factory factory = new Factory(factorySpecialization.Value, Convert.ToInt32(factoryWorkers.Value), 
                    Convert.ToInt32(factoryBudget.Value));
                factory.DetailWarehouse.InWarehouse = Convert.ToInt32(factoryDetails.Value);
                factory.ProductWarehouse.InWarehouse = Convert.ToInt32(factoryProducts.Value);
                
                yield return factory;
            }
        }

        public IEnumerable<Factory> DeSerializeXML(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Collection<Factory>));
            
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Collection<Factory> collection = (Collection<Factory>)formatter.Deserialize(fs);
                return collection;
            }
        }

        public IEnumerable<Factory> DeSerializeJSON(string fileName)
        {
            return null;
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
            if(File.Exists(fileName))
                File.Delete(fileName);
            
            XmlSerializer formatter = new XmlSerializer(typeof(Collection<Factory>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, factories);
            }
        }

        public async Task SerializeJSON(IEnumerable<Factory> factories, string fileName)
        {
            if(File.Exists(fileName))
                File.Delete(fileName);
            
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                foreach (var factoryEl in factories)
                {
                    await JsonSerializer.SerializeAsync<Factory>(fs, factoryEl);
                }
            }
        }
    }
}