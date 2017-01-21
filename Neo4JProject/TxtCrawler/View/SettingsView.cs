using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtCrawler.Common.XML;
using TxtCrawler.Common.Helper;

namespace TxtCrawler.Common.View
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
            grdSettings.DataSource = XMLDataAccess.Instance.GetDatasetFromXMLFile().Tables[XMLConstants.SettingsTag];
        }

        private void grdSettings_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = grdSettings.DataSource as DataTable;
            new GridHelper().SaveGridData(data);
            btnSave.Enabled = false;
        }
    }
}
