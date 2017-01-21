using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;

namespace TxtCrawler.Common
{
    public class Neo4jConfig
    {
        public static Neo4jConfig Instance 
        {
            get { return new Neo4jConfig(); }
        }

        public Neo4jClient.GraphClient ClientC 
        {
            get
            {
                var _clientC = new Neo4jClient.GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "licenta");
                _clientC.Connect();
                return _clientC;
            }
        }
    }
}
