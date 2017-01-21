using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtCrawler.Common.XML;

namespace TxtCrawler.Common.Helper
{
    public class GridHelper
    {
        public bool SaveTagValue(string tag,string value)
        {
            try
            {
                XMLDataAccess.Instance.SetNewValueForTag(tag,value);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public void SaveGridData(DataTable dataSet)
        {
            foreach (DataRow row in dataSet.Rows)
            {
                foreach (var tag in XMLConstants.XMLTagsList)
                {
                    if (SaveTagValue(tag, row[tag].ToString()))
                        continue;
                    else
                        MessageBox.Show(string.Format("Could not save value for {0}", tag));
                }
            }
        }
    }
}
