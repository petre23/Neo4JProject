using Neo4JController.Controllers;
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
            //_controller = new MainViewController(this);
            _service = new Neo4JService.Neo4JService(this);
        }

        public Button BtnShowDatabaseGenerator
        {
            get
            {
                return btnDatabaseGenerator;
            }
            set
            {
                btnDatabaseGenerator = value;
            }
        }

        public Button BtnStartAnalysis
        {
            get
            {
                return btnStartAnalysis;
            }
            set
            {
                btnStartAnalysis = value;
            }
        }

        public TextBox TxtInfoLog
        {
            get
            {
                return txtInfoLog;
            }
            set
            {
                txtInfoLog = value;
            }
        }

        public ProgressBar PgbNeo4JQuery
        {
            get
            {
                return pgbNeo4JQuery;
            }
            set
            {
                pgbNeo4JQuery = value;
            }
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
                        new ResultsGridView(_service.GetUsersAvarage(), _service.GetAllLocationsDataSource(),
                            _service.GetPositiveDataSource(), _service.GetNegativeDataSource()).Show();
                        _service.PrintRaport();
                        pgbNeo4JQuery.Visible = false;
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Error : ",ex.Message);
                    }
                }));
            });
            thread.Start();
        }


        public Label LblSearch
        {
            get
            {
                return lblSearch;
            }
            set
            {
                lblSearch = value;
            }
        }

        public TextBox TxtSearchBox
        {
            get
            {
                return txtSearchBox;
            }
            set
            {
                txtSearchBox = value;
            }
        }

        public ListBox LbNeo4JSearch
        {
            get
            {
                return lbNeo4JSearch;
            }
            set
            {
                lbNeo4JSearch = value;
            }
        }

        public ListBox LbSqlSearch
        {
            get
            {
                return lbSQLSearch;
            }
            set
            {
                lbSQLSearch = value;
            }
        }

        public Button BtnStartSearch
        {
            get
            {
                return btnStartSearch;
            }
            set
            {
                btnStartSearch = value;
            }
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


        public Button BtnClearText
        {
            get
            {
                return btnClear;
            }
            set
            {
                btnClear = value;
            }
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
            if (!string.IsNullOrEmpty(TxtSearchBox.Text))
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


        public Button BtnStartVersusForLocation
        {
            get
            {
                return btnStartVersusForLocation;
            }
            set
            {
                btnStartVersusForLocation = value;
            }
        }
    }
}
