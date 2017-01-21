using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.Common
{
    public class BaseDAO
    {
        public Neo4jClient.GraphClient _client;
        public BaseDAO()
        {
            _client = Neo4jConfig.Instance.Client;
        }
    }
}
