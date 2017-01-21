using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtCrawler.Model;

namespace Neo4J.View
{
    public partial class ResultsGridView : Form
    {

        private BindingList<Neo4JModel.BO.Locatie> _allLocations;
        private BindingList<Neo4JModel.BO.Locatie> _allPositiveLocations;
        private BindingList<Neo4JModel.BO.Locatie> _allNegativeLocations;
        private float _userAvarage;

        public ResultsGridView(float userAvarage,BindingList<Neo4JModel.BO.Locatie> allLocations, BindingList<Neo4JModel.BO.Locatie> allPositiveLocations, BindingList<Neo4JModel.BO.Locatie> allNegativeLocations)
        {
            InitializeComponent();
            _allLocations = allLocations;
            _allPositiveLocations = allPositiveLocations;
            _allNegativeLocations = allNegativeLocations;
            _userAvarage = userAvarage;
            SetupView();
        }

        private void SetupView() 
        {
            grdLocations.DataSource = _allLocations;
            grdLocationsPositive.DataSource = _allPositiveLocations;
            grdLocationsNegative.DataSource = _allNegativeLocations;
            lblAllLocationsGrid.Text = string.Format("{0}({1})", lblAllLocationsGrid.Text, _allLocations.Count);
            lblLocationsWithPositiveComments.Text = string.Format("{0}({1})", lblLocationsWithPositiveComments.Text, _allPositiveLocations.Count);
            lblLocationsWithNegativeCommets.Text = string.Format("{0}({1})", lblLocationsWithNegativeCommets.Text, _allNegativeLocations.Count);
            lblUserAvarage.Text = _userAvarage.ToString();

            SetupColumns();
        }

        private void RemoveUniqueKeyColumn() 
        {
            grdLocations.Columns["UniqueKey"].Visible = false;
            grdLocationsPositive.Columns["UniqueKey"].Visible = false;
            grdLocationsNegative.Columns["UniqueKey"].Visible = false;
        }

        private void SetupColumns() 
        {
            RemoveUniqueKeyColumn();
            grdLocations.Columns["Nume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLocations.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLocationsPositive.Columns["Nume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLocationsPositive.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLocationsNegative.Columns["Nume"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLocationsNegative.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Refresh();
        }
    }
}
