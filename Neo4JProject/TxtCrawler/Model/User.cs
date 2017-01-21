using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtCrawler.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string PerioadaSejur { get; set; }
        public string UniqueKey
        {
            get 
            {
                var retVal = string.Empty;
                if (!string.IsNullOrEmpty(UserName))
                    retVal += UserName.Replace(" ",string.Empty);
                if (!string.IsNullOrEmpty(PerioadaSejur))
                    retVal += PerioadaSejur.Replace(" ",string.Empty);
                return retVal;
            }
        }

    }
}
