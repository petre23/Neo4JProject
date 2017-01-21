using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtCrawler.Common.XML;
using TxtCrawler.Common.View;
using TxtCrawler.Controller;
using TxtCrawler.Model;
using TxtCrawler.Common.Controller.SQL;

namespace TxtCrawler.Common
{
    public partial class MainView : Form
    {
        private Locatie _locatie = new Locatie();
        private NodesProcessor _executionHandler = new NodesProcessor();
        private SqlProcessor _sqlHandler = new SqlProcessor();

        public MainView()
        {
            InitializeComponent();
        }

        private void btnStartDatabaseGenerator_Click(object sender, EventArgs e)
        {
            var th = new Thread(() =>
            {
                try
                {
                    string path = @"C:\Users\Petre\Desktop\turistinfo.roData\turistinfo-ro";
                    var dirList = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
                    this.Invoke((Action)(() =>
                    {
                        pgbMain.Maximum = dirList.Count;
                        btnStartDatabaseGenerator.Enabled = false;
                        btnSettings.Enabled = false;
                    }));

                    StartGeneratingNodes(dirList);
                    AddTextToListBox("Starting...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : ", ex.Message);
                }
            });
            th.Start();
        }

        private void StartGeneratingNodes(List<string> files)
        {

            var locatieAnteriara = new List<string>();
            foreach (var file in files)
            {
                this.Invoke((Action)(() => { pgbMain.Increment(1); }));
                AddTextToListBox(string.Format("Crawling file {0}", file));
                if (file.Contains("poze") || file.Contains("Hartă acces") || file.Contains("tarife cazare") || file.Contains("camere"))
                    continue;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.OptionFixNestedTags = true;
                try
                {
                    doc.Load(file);
                }
                catch
                {
                    continue;
                }
                if (doc.DocumentNode != null)
                {
                    var nodeTitle = doc.DocumentNode.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.TitleTag));

                    if (nodeTitle != null)
                    {
                        var nodeDescription = doc.GetElementbyId(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.DescriptionIdTag));
                        locatieAnteriara.Add(_locatie.UniqueKey);
                        _locatie.Nume = nodeTitle.InnerText;
                        var tempLocatie = _locatie.Nume.Split(',', '-');
                        _locatie.Nume = tempLocatie.FirstOrDefault();

                        _locatie.Description = nodeDescription != null ? nodeDescription.InnerText : string.Empty;
                        if (!locatieAnteriara.Contains(_locatie.UniqueKey))
                        {
                            _executionHandler.AddLocationNode(_locatie);
                            _sqlHandler.InsertLocation(_locatie);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(_locatie.Description))
                            {
                                _executionHandler.UpdateLocation(_locatie);
                                _sqlHandler.InsertLocation(_locatie);
                            }
                        }
                        AddTextToListBox(string.Format("Current location {0}", _locatie.Nume));
                    }
                    else
                        continue;

                    var nodeReviewSummary = doc.DocumentNode.SelectNodes(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.ReviewSummaryTag));
                    if (nodeReviewSummary != null)
                    {
                        AddTextToListBox(string.Format("Extracting User Comments for location {0}", _locatie));
                        _executionHandler.ExtractComments(_locatie,nodeReviewSummary);
                    }

                    var nodCamere = doc.DocumentNode.SelectNodes(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.RoomsBaseTag));
                    if (nodCamere != null)
                    {
                        AddTextToListBox("Extracting Location Rooms Info ");
                        _executionHandler.ExtractRooms(_locatie,nodCamere);
                    }
                }
            }
            this.Invoke((Action)(() =>
            {
                lblDone.Visible = true;
            }));
        }

        private void AddTextToListBox(string textToAdd)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    lbNodesLog.Items.Add(textToAdd);
                    this.Refresh();
                }));
            }
            else
            {
                lbNodesLog.Items.Add(textToAdd);
                this.Refresh();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
           var settingsView =  new SettingsView();
           settingsView.Show();
        }
    }
}
