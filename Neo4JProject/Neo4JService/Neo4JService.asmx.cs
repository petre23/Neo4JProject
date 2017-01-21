using Neo4JController.Controllers;
using Neo4JController.Interfaces;
using Neo4JModel.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace Neo4JService
{
    /// <summary>
    /// Summary description for Neo4JService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Neo4JService : System.Web.Services.WebService
    {
        private MainViewController _controller;

        public Neo4JService(IMainView form) 
        {
            _controller = new MainViewController(form);
        }

        [WebMethod]
        public void OpenDatabaseGeneratorTool()
        {
            _controller.OpenDatabseGenerator();
        }

        [WebMethod]
        public void ExecuteNeo4JActions() 
        {
            _controller.ExecuteAnalysis();
        }

        [WebMethod]
        public void PrintRaport()
        {
            _controller.PrintRaport();
        }


        [WebMethod]
        public void StartVersusSearch() 
        {
            _controller.StartNeo4JvSqlSearch();
        }

        [WebMethod]
        public void ClearText() 
        {
            _controller.ClearTextFromTextBoxes();
        }

        [WebMethod]
        public void StartVersusComparation() 
        {
            _controller.StartVersusComparation();
        }

        [WebMethod]
        public BindingList<Locatie> GetAllLocationsDataSource() 
        {
            return _controller.GetAllLocationsDataSource();
        }

        [WebMethod]
        public BindingList<Locatie> GetPositiveDataSource()
        {
            return _controller.GetPositiveDataSource();
        }

        [WebMethod]
        public BindingList<Locatie> GetNegativeDataSource()
        {
            return _controller.GetNegativeDataSource();
        }

        [WebMethod]
        public float GetUsersAvarage()
        {
            return _controller.GetUsersAvarageGrade();
        }
    }
}
