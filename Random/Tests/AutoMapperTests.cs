using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk.Tests
{
    [TestClass]
    public class AutoMapperTests
    {
        [TestMethod]
        public void MapSame()
        {
            var generator = new RandomObjectGenerator();
            var modelOne = new DumbModel();
            var modelTwo = new DumbModel();

            modelOne.ID = generator.Generate<int>();
            modelOne.Name = generator.Generate<string>();

            modelOne.Map(modelTwo);

            Assert.AreEqual(modelOne.ID, modelTwo.ID, modelTwo.GetPropertyName(_ => _.ID));
            Assert.AreEqual(modelOne.Name, modelTwo.Name, modelTwo.GetPropertyName(_ => _.Name));
        }

        [TestMethod]
        public void MapDifferent()
        {
            var generator = new RandomObjectGenerator();
            var modelOne = new DumbModel();
            var modelTwo = new DumbModelTwo();

            modelOne.ID = generator.Generate<int>();
            modelOne.Name = generator.Generate<string>();

            modelOne.Map(modelTwo);

            Assert.AreEqual(modelOne.ID, modelTwo.ID, modelTwo.GetPropertyName(_ => _.ID));
            Assert.AreEqual(modelOne.Name, modelTwo.Name, modelTwo.GetPropertyName(_ => _.Name));
        }
    }
}
