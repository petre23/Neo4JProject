using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TxtCrawler.Common.XML;

namespace Neo4J.UnitTest
{
    [TestClass]
    public class XMLDataAccessShould
    {
        [TestMethod]
        public void ReturnTitleValue()
        {
            var data = XMLDataAccess.Instance.GetElementFromFile("Title");
            Assert.AreEqual(data, "//title");
        }

        [TestMethod]
        public void ReturnDescriptionId()
        {
            var data = XMLDataAccess.Instance.GetElementFromFile("DescriptionId");
            Assert.AreEqual(data, "detailscontent");
        }

        [TestMethod]
        public void ReturnDataSet()
        {
            var data = XMLDataAccess.Instance.GetDatasetFromXMLFile();
            Assert.IsNotNull(data);
        }
    }
}
