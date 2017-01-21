using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo4JController.Interfaces
{
    public interface IMainView
    {
        Button BtnShowDatabaseGenerator{get;set;}
        Button BtnStartAnalysis{get;set;}
        Button BtnClearText { get; set; }
        Button BtnStartVersusForLocation { get; set; }
        TextBox TxtInfoLog{get;set;}
        ProgressBar PgbNeo4JQuery{get;set;}
        Label LblSearch { get; set; }
        TextBox TxtSearchBox { get; set; }
        ListBox LbNeo4JSearch { get; set; }
        ListBox LbSqlSearch { get; set; }
        Button BtnStartSearch { get; set; }

        void InfoMessage(string message);
        void AddTextNeo4JListBoxThreadSafe(string text);
        void AddTextSqlListBoxThreadSafe(string text);

        void AddToTextBox(string text);
    }
}
