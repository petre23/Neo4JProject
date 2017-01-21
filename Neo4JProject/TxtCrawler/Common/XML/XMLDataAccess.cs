using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TxtCrawler.Common.XML;

namespace TxtCrawler.Common.XML
{
    public class XMLDataAccess
    {
        private string _fileLocation;
        public XMLDataAccess() 
        {
            _fileLocation = XMLConstants.XMLSettingsFilePath;
        }

        public static readonly XMLDataAccess Instance = new XMLDataAccess();

        public string GetElementFromFile(string elementTag)
        {
            try
            {
                var doc = XDocument.Load(_fileLocation);
                var returnValue = doc.Root.Element(elementTag);
                if (!string.IsNullOrEmpty(returnValue.Value))
                    return returnValue.Value;
                else
                    return string.Empty;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public DataSet GetDatasetFromXMLFile() 
        {
            try
            {
                XmlReader xmlFile = XmlReader.Create(_fileLocation, new XmlReaderSettings());
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFile);
                xmlFile.Close();
                return dataSet;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void SetNewValueForTag(string tag, string value)
        {
            try
            {
                var doc = XDocument.Load(_fileLocation);
                var currentElement = doc.Root.Element(tag);
                if (currentElement != null)
                    currentElement.Value = value;

                doc.Save(_fileLocation);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
