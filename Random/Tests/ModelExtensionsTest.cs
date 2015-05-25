using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk.Tests
{
    [TestClass]
    public class ModelExtensionsTest
    {
        [TestMethod]
        public void GetPropertyName()
        {
            var idProperty = ModelExtensions.GetPropertyName<DumbModel>(_ => _.ID);
            var nameProperty = ModelExtensions.GetPropertyName<DumbModelTwo>(_ => _.Name);

            Assert.AreEqual("ID", idProperty, ModelExtensions.GetPropertyName<DumbModel>(_ => _.ID));
            Assert.AreEqual("Name", nameProperty, ModelExtensions.GetPropertyName<DumbModelTwo>(_ => _.Name));
        }
    }
}
