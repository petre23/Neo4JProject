using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class CameraDAO : BaseDAO
    {
        public CameraDAO()
            : base() 
        {
        }

        public List<Camera> GetAllRoomsFromDB()
        {
            var rooms = _client.Cypher
                        .Match("(type:Camera)")
                        .Return(type => type.As<Camera>())
                        .Results;

            return rooms.ToList();
        }

        public Camera GetRoomByUniqueKey(string uniqueKey)
        {
            var rooms = _client.Cypher
                            .Match("(camera:Camera)")
                            .Where((Camera camera) => camera.UniqueKey == uniqueKey)
                            .Return(camera => camera.As<Camera>())
                            .Results;
            return rooms.ToList().FirstOrDefault();
        }

        public List<Camera> GetRoomsByRoomType(string tipCamera)
        {
            var rooms = _client.Cypher
                            .Match("(camera:Camera)")
                            .Where((Camera camera) => camera.TipCamere == tipCamera)
                            .Return(camera => camera.As<Camera>())
                            .Results;
            return rooms.ToList();
        }

        public List<Camera> GetAllRoomsWithBath()
        {
            var rooms = _client.Cypher
                            .Match("(camera:Camera)")
                            .Where((Camera camera) => camera.Baie == "da")
                            .Return(user => user.As<Camera>())
                            .Results;
            return rooms.ToList();
        }
    }
}
