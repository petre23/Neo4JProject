using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.Common
{
    public class Neo4jConfig
    {
        public static Neo4jConfig Instance
        {
            get { return new Neo4jConfig(); }
        }

        public Neo4jClient.GraphClient Client
        {
            get
            {
                try
                {
                    var _clientC = new Neo4jClient.GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "licenta");
                    _clientC.Connect();
                    return _clientC;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
