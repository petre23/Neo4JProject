using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtCrawler.Model
{
    public class Locatie
    {
        public string Nume
        {
            get;
            set;
        }
        public string Description { get; set; }

        public string UniqueKey 
        {
            get 
            {
                var retVal = string.Empty;
                if (!string.IsNullOrEmpty(Nume))
                    retVal = Nume.Replace(" ",string.Empty);
                return retVal;
            }
        }
    }
}
