using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class LocatieDAO : BaseDAO
    {
        public LocatieDAO() : base() 
        { }

        public List<Locatie> GetAllLocationsFromDB()
        {
            var locations = _client.Cypher
                            .Match("(type:Locatie)")
                            .Return(type => type.As<Locatie>())
                            .Results;

            return locations.ToList();
        }

        public Locatie GetLocationByUniqueKey(string uniqueKey) 
        {
            var locations = _client.Cypher
                            .Match("(locatie:Locatie)")
                            .Where((Locatie locatie) => locatie.UniqueKey == uniqueKey)
                            .Return(locatie => locatie.As<Locatie>())
                            .Results;
            return locations.ToList().FirstOrDefault();
        }

        public Locatie GetLocationByName(string locationName)
        {
            var locations = _client.Cypher
                            .Match("(locatie:Locatie)")
                            .Where((Locatie locatie) => locatie.Nume == locationName)
                            .Return(locatie => locatie.As<Locatie>())
                            .Results;
            return locations.ToList().FirstOrDefault();
        }

        public List<Locatie> GetLocationThatStartsWith(string locationName)
        {
            var locations = _client.Cypher
                            .Match("(locatie:Locatie)")
                            .Where("locatie.Description =~ {locationName}")
                            .WithParam("locationName", string.Format("{0}.*", locationName))
                            .Return(locatie => locatie.As<Locatie>())
                            .Results;

            return locations.ToList();
        }

        public List<Locatie> GetLocationWhereDescriptionContains(string descriptionWord)
        {
            var locations = _client.Cypher
                            .Match("(locatie:Locatie)")
                            .Where("locatie.Description =~ {descriptionWord}")
                            .WithParam("descriptionWord", string.Format(".*{0}.*", descriptionWord))
                            .Return(locatie => locatie.As<Locatie>())
                            .Results;

            return locations.ToList();
        }
    }
}
