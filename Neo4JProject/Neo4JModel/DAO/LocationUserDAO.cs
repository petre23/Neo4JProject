using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class LocationUserDAO:BaseDAO
    {
        public LocationUserDAO()
            : base()
        { }

        public List<User> GetUserForAllLocations()
        {
            var users = _client.Cypher
                            .Match("(user:User)-[:Visited]->(locatie:Locatie)")
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList();
        }

        public List<User> GetUserForLocationWithName(string locationName) 
        {
            var users = _client.Cypher
                            .Match("(user:User)-[:Visited]->(locatie:Locatie)")
                            .Where((Locatie locatie) => locatie.Nume == locationName)
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList();
        }

        public List<User> GetUserForLocationThatStartsWith(string locationStartsWith)
        {
            var users = _client.Cypher
                            .Match("(user:User)-[:Visited]->(locatie:Locatie)")
                            .Where((Locatie locatie) => locatie.Nume.StartsWith(locationStartsWith))
                            .Return(user => user.As<User>())
                            .Results;
            return users.ToList();
        }

        public List<User> GetUsersThatVisitedLocation(Locatie location,string userHomeLocation)
        {
            var users = _client.Cypher
                            .Match("(user:User)-[:Visited]->(locatie:Locatie)")
                            .Where((Locatie locatie) => locatie.Nume.Contains(locatie.Nume))
                            .AndWhere((User user) => user.UserName.Contains(userHomeLocation))
                            .Return(user => user.As<User>())
                            .Results;

            return users.ToList();
        }

       
        public List<Locatie> GetLocationsThatHaveTenPositiveComments()
        {
            var locations = _client.Cypher
                   .Match("(locatie:Locatie)<-[:Visited]-(user:User)-[:Commented]->(comment:Comment) WITH locatie,count(user) as usr ,CASE WHEN comment.PositiveComment is not null THEN 1 ELSE 0 END as c")
                   .Where("usr >= 10")
                   .AndWhere("c = 1")
                   .Return(locatie => locatie.As<Locatie>())
                   .Results;
            return locations.ToList();
        }

        public List<Locatie> GetLocationsThatHaveTenNegativeComments()
        {
            var locations = _client.Cypher
                   .Match("(locatie:Locatie)<-[:Visited]-(user:User)-[:Commented]->(comment:Comment) WITH locatie,count(user) as usr ,CASE WHEN comment.NegativeComment is not null THEN 1 ELSE 0 END as c")
                   .Where("usr >= 10")
                   .AndWhere("c = 1")
                   .Return(locatie => locatie.As<Locatie>())
                   .Results;
            return locations.ToList();
        }
    }
}
