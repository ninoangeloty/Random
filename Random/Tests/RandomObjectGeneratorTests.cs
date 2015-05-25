using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk.Tests
{
    [TestClass]
    public class RandomObjectGeneratorTests
    {
        [TestMethod]
        public void GenerateNumber()
        {
            var generator = new RandomObjectGenerator();
            var intValue = generator.Generate<int>();
            var longValue = generator.Generate<long>();
            var doubleValue = generator.Generate<double>();
            var decimalValue = generator.Generate<decimal>();
            var floatValue = generator.Generate<float>();

            Assert.IsInstanceOfType(intValue, typeof(int));
            Assert.IsInstanceOfType(longValue, typeof(long));
            Assert.IsInstanceOfType(doubleValue, typeof(double));
            Assert.IsInstanceOfType(decimalValue, typeof(decimal));
            Assert.IsInstanceOfType(floatValue, typeof(float));
        }

        [TestMethod]
        public void GenerateGuid()
        {
            var generator = new RandomObjectGenerator();
            var guidValue = generator.Generate<Guid>();

            Assert.IsInstanceOfType(guidValue, typeof(Guid));
        }

        [TestMethod]
        public void GenerateString()
        {
            var generator = new RandomObjectGenerator();
            var stringValue = generator.Generate<string>();

            Assert.IsInstanceOfType(stringValue, typeof(string));
        }

        [TestMethod]
        public void GenerateOutOfScopeType()
        {
            var generator = new RandomObjectGenerator();
            var obj = generator.Generate<DumbModel>();

            Assert.IsTrue(obj == default(DumbModel));
        }
    }
}
