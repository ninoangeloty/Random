using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new RandomObjectGenerator();
            var content = string.Format("Random #: {0}\nRandom Text: {1}\nRandom Guid: {2}", 
                generator.Generate<double>(), generator.Generate<string>(), generator.Generate<Guid>());

            content += "\nProp[0]: " +  ModelExtensions.GetPropertyName<DumbModel>(_ => _.ID);
            content += "\nProp[1]: " + ModelExtensions.GetPropertyName<DumbModel>(_ => _.Name);

            AutoMapperTest();

            Console.WriteLine(content);
            Console.ReadKey();
        }

        static void AutoMapperTest()
        {
            var one = new DumbModel() { ID = 1, Name = "One" };
            var two = new DumbModel();
            one.Map(two);

            var listOne = new List<DumbModel> { one };
            var listTwo = new List<DumbModel>();
            listOne.Map(listTwo);

            // map to different type will do nothing
            var dumbOne = new DumbModel() { ID = 1, Name = "One" };
            var dumbTwo = new SuperDumbModel();
            dumbOne.Map(dumbTwo);
        }
    }

    public class DumbModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class DumbModelTwo
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class SuperDumbModel
    {
        public int ID { get; set; }
    }
}
