using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CS_august03
{
    class Program
    {
        static void Main(string[] args)
        {
            City Moscow = new City() { Name = "Moscow", Temperature = 30 };
            City Piter = new City() { Name = "Piter", Temperature = 15 };
            City Yarik = new City() { Name = "Yarik", Temperature = 20 };
            City Kazan = new City() { Name = "Kazan", Temperature = 25 };
            City Omsk = new City() { Name = "Omsk", Temperature = 5 };
            City Yalta = new City() { Name = "Yalta", Temperature = 22 };
            City Anapa = new City() { Name = "Anapa", Temperature = 40 };
            City Murmansk = new City() { Name = "Murmansk", Temperature = -7 };
            City Groznyi = new City() { Name = "Groznyi", Temperature = 27 };
            City NewYork = new City() { Name = "NewYork", Temperature = 13 };


            List<City> cities = new List<City> { Moscow, Piter, Yarik, Kazan, Omsk, Yalta, Anapa, Murmansk, Groznyi, NewYork };



            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<City>));
            try
            {
                /*using (Stream fStream =
                File.Create("test.xml"))
                {
                    xmlFormat.Serialize(fStream, cities);
                }
                Console.WriteLine("XmlSerialize OK!\n");*/
                //cities.Clear();


                using (Stream fStream = File.OpenRead("test.xml"))
                {
                    cities = (List<City>)xmlFormat.Deserialize(fStream);
                }

                cities.Sort((c1, c2) => c1.Temperature.CompareTo(c2.Temperature));
                /*cities.Add(new City() { Name = "Vologda", Temperature = 29 });     
                using (Stream fStream = File.OpenWrite("test.xml"))
                {
                    xmlFormat.Serialize(fStream, cities);
                }*/


                foreach (var p in cities)
                {
                    Console.WriteLine($"{p.Name} - {p.Temperature}");
                }


                /*XmlDocument doc = new XmlDocument();
                doc.Load("test.xml");
                XmlNode root = doc.DocumentElement;
                XmlNode city = doc.CreateElement("City");
                XmlNode name = doc.CreateElement("Name");
                XmlNode temp = doc.CreateElement("Temperature");
                XmlNode nameVal = doc.CreateTextNode("Sokol");
                XmlNode tempVal = doc.CreateTextNode("21");
                name.AppendChild(nameVal);
                temp.AppendChild(tempVal);
                city.AppendChild(name);
                city.AppendChild(temp);
                root.AppendChild(city);
                doc.Save("test.xml");*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }


    [Serializable]
    public class City
    {
        public string Name;
        public int Temperature;
    }
}
