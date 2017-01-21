using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.BO
{
    public class Comment
    {
        public string PositiveComment { get; set; }
        public decimal UserGrade { get; set; }
        public string NegativeComment { get; set; }
        public string UniqueKey
        {
            get
            {
                string retVal = string.Empty;
                if (!string.IsNullOrEmpty(NegativeComment))
                    retVal = NegativeComment;
                if (!string.IsNullOrEmpty(PositiveComment))
                    retVal += PositiveComment;
                retVal += UserGrade.ToString();

                return retVal;
            }
        }
    }
}
