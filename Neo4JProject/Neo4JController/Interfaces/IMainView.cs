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
        void InfoMessage(string message);
        void AddTextNeo4JListBoxThreadSafe(string text);
        void AddTextSqlListBoxThreadSafe(string text);
        void AddToTextBox(string text);
        bool IsSearchBoxEmpty();
        string GetSearchText();
        void ClearView();
    }
}
