using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.BO
{
    public class Camera
    {
        public string NumarCamera { get; set; }
        public string TipCamere { get; set; }
        public string Baie { get; set; }

        List<string> _pret = new List<string>();
        public List<string> Pret
        {
            get { return _pret; }
            set { _pret = value; }
        }

        public string UniqueKey
        {
            get
            {
                var retVal = string.Empty;
                if (!string.IsNullOrEmpty(TipCamere))
                    retVal = TipCamere;
                if (!string.IsNullOrEmpty(Baie))
                    retVal += Baie;
                if (!string.IsNullOrEmpty(NumarCamera))
                    retVal += NumarCamera;
                if (Pret.Any())
                {
                    foreach (var p in Pret)
                        retVal += p;
                }
                return retVal;
            }
        }
    }
}
