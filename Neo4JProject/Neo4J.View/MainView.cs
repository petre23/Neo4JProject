using Neo4JController.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo4J.View
{
    public partial class MainView : Form, IMainView
    {
        private Neo4JService.Neo4JService _service;

        public MainView()
        {
            InitializeComponent();
            _service = new Neo4JService.Neo4JService(this);
        }

        private void btnDatabaseGenerator_Click(object sender, EventArgs e)
        {
            _service.OpenDatabaseGeneratorTool();
        }

        private void btnStartAnalysis_Click(object sender, EventArgs e)
        {
            pgbNeo4JQuery.Visible = true;
            var thread = new Thread(() =>
            {
                _service.ExecuteNeo4JActions();
                this.Invoke((Action)(() =>
                {
                    try
                    {
                        using(var resultGrid = new ResultsGridView(_service.GetUsersAvarage(), _service.GetAllLocationsDataSource(),
                            _service.GetPositiveDataSource(), _service.GetNegativeDataSource()))
                        {
                            resultGrid.Show();
                            _service.PrintRaport();
                            pgbNeo4JQuery.Visible = false;
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Error : ",ex.Message);
                    }
                }));
            });
            thread.Start();
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _service.StartVersusComparation();
                btnClear.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
        }

        public void InfoMessage(string message)
        {
            MessageBox.Show(message);
        }


        public void AddTextNeo4JListBoxThreadSafe(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    lbNeo4JSearch.Items.Add(text);
                    this.Refresh();
                }
                ));
            }
            else
            {
                lbNeo4JSearch.Items.Add(text);
                this.Refresh();
            }
        }

        public void AddTextSqlListBoxThreadSafe(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    lbSQLSearch.Items.Add(text);
                }
                ));
            }
            else
                lbSQLSearch.Items.Add(text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _service.ClearText();
        }

        public void AddTextToBox(string text)
        {
            if (txtInfoLog.InvokeRequired)
            {
                txtInfoLog.BeginInvoke((Action)(() => { txtInfoLog.Text += text + Environment.NewLine; }));
            }
            else
                txtInfoLog.Text += text + Environment.NewLine; 
        }

        public void AddToTextBox(string text)
        {
            if (this.txtInfoLog.InvokeRequired)
            {
                txtInfoLog.BeginInvoke((Action)(() =>
                {
                    txtInfoLog.Text += text + Environment.NewLine;
                    this.Refresh();
                }));
            }
            else
            {
                txtInfoLog.Text += text + Environment.NewLine;
                this.Refresh();
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchBox.Text))
                btnStartVersusForLocation.Enabled = true;
            else
                btnStartVersusForLocation.Enabled = false;
        }

        private void btnStartVersusForLocation_Click(object sender, EventArgs e)
        {
            try
            {
                _service.StartVersusSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
        }

        public bool IsSearchBoxEmpty()
        {
            var returnValue = false;
            if (string.IsNullOrEmpty(txtSearchBox.Text))
            {
                this.InfoMessage("Please insert text in search field !");
                this.btnClear.Enabled = false;
                returnValue = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
            return returnValue;
        }

        public string GetSearchText()
        {
            return txtSearchBox.Text;
        }

        public void ClearView() 
        {
            lbNeo4JSearch.Items.Clear();
            lbSQLSearch.Items.Clear();
            txtSearchBox.Clear();
            btnClear.Enabled = false;
        }
    }
}
