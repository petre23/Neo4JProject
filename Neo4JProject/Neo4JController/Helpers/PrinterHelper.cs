using Neo4JModel.BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo4JController.Helpers
{
    public class PrinterHelper
    {
        StringBuilder _stringBuilder = new StringBuilder();
        private string _filePath = string.Empty;

        public void AddTextToBuilder(string text)
        {
            _stringBuilder.AppendLine(text);
        }

        public void PrintLocations(List<Locatie> locations)
        {
            foreach (var loc in locations)
            {
                AddTextToBuilder("Location Name : " + loc.Nume);
            }
        }

        public void PrintUsers(List<User> users)
        {
            foreach (var usr in users)
            {
                AddTextToBuilder("User Name : " + usr.UserName);
                AddTextToBuilder("Perioada sejur : " + usr.PerioadaSejur);
            }
        }

        public void PrintComment(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                AddTextToBuilder("Negative Comment : " + comment.NegativeComment);
                AddTextToBuilder("Positive Comment : " + comment.PositiveComment);
                AddTextToBuilder("User grade : " + comment.UserGrade);
            }
        }

        public void SaveReport()
        {
            WriteToFile(_stringBuilder);
        }

        private static object locker = new Object();
        public void WriteToFile(StringBuilder text)
        {
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "Word document|*.doc";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = theDialog.FileName;
            }
            else
                return;
            lock (locker)
            {
                using (FileStream file = new FileStream(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                {
                    writer.Write(text.ToString());
                }
            }

        }
    }
}
