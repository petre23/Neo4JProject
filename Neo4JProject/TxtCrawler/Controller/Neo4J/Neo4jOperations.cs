using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtCrawler.Common;
using TxtCrawler.Model;

namespace TxtCrawler.Controller
{
    public class Neo4jOperations
    {
        private Neo4jClient.GraphClient _client;

        public Neo4jOperations() 
        {
            _client = Neo4jConfig.Instance.ClientC;
        }

        public void AddLocationNode(Locatie locatie)
        {
            try
            {
                _client.Cypher.Create("CONSTRAINT ON (locatie : Locatie) ASSERT locatie.Nume IS UNIQUE").ExecuteWithoutResults();
                _client.Cypher.Create("(locatie : Locatie{locatie})").WithParam("locatie", locatie).ExecuteWithoutResults();
            }
            catch (Exception ex)
            {
            }
        }

        public void AddCommentsNode(Comment comments)
        {
            try
            {
                _client.Cypher.Create("(comment : Comment{comment})").WithParam("comment", comments).ExecuteWithoutResults();
            }
            catch(Exception ex)
            {
            }
        }

        public void AddRoomNode(Camera camera)
        {
            try
            {
                _client.Cypher.Create("(camera : Camera{camera})").WithParam("camera", camera).ExecuteWithoutResults();
            }
            catch (Exception ex) 
            {
            }
        }

        public void AddUserNode(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    _client.Cypher.Create("CONSTRAINT ON (user : User) ASSERT user.UniqueKey IS UNIQUE").ExecuteWithoutResults();
                    _client.Cypher.Create("(user : User{user})").WithParam("user", user).ExecuteWithoutResults();
                }
            }
            catch(Exception ex)
            {
            }
        }

        public void AddFacebookCommentNode(FacebookComment facebookComment)
        {
            try
            {
                if (!string.IsNullOrEmpty(facebookComment.FacebookUsername))
                {
                    _client.Cypher.Create("CONSTRAINT ON (facebookComment : FacebookComment) ASSERT facebookComment.FacebookUsername IS UNIQUE").ExecuteWithoutResults();
                    _client.Cypher.Create("(facebookComment : FacebookComment{facebookComment})").WithParam("facebookComment", facebookComment).ExecuteWithoutResults();
                }
            }
            catch (Exception ex) 
            {
            }
        }

        static List<string> usernameList = new List<string>();
        public void CreateUserCommentRelation(User userData, Comment comments)
        {
            try
            {
                if (!usernameList.Contains(userData.UniqueKey))
                {
                    AddUserNode(userData);
                    usernameList.Add(userData.UniqueKey);
                    AddCommentsNode(comments);
                    var query = _client.Cypher
                            .Match("(user:User)", "(comment:Comment)")
                            .Where((User user) => user.UniqueKey == userData.UniqueKey)
                            .AndWhere((Comment comment) => comment.UniqueKey == comments.UniqueKey)
                            .Create("(user)-[:Commented]->(comment)");
                    query.ExecuteWithoutResults();
                }
            }
            catch
            {

            }
        }

        public void CreateLocationRoomRelation(Locatie locatieData, List<Camera> cameraData)
        {
            try
            {
                //AddLocationNode(locatieData);
                foreach (var room in cameraData)
                {
                    AddRoomNode(room);
                    var query = _client.Cypher
                            .Match("(locatie:Locatie)", "(camera:Camera)")
                            .Where((Locatie locatie) => locatie.UniqueKey == locatieData.UniqueKey)
                            .AndWhere((Camera camera) => camera.UniqueKey == room.UniqueKey)
                            .Create("(locatie)-[:Has_Room]->(camera)");
                    query.ExecuteWithoutResults();
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        List<string> userVisited = new List<string>();
        public void CreateLocationUserRelation(Locatie locatieData, List<User> userList)
        {
            try
            {
                foreach (var usr in userList)
                {
                    if (!userVisited.Contains(usr.UniqueKey))
                    {
                        var query = _client.Cypher
                                .Match("(locatie:Locatie)", "(user:User)")
                                .Where((Locatie locatie) => locatie.UniqueKey == locatieData.UniqueKey)
                                .AndWhere((User user) => user.UniqueKey == usr.UniqueKey)
                                .Create("(user)-[:Visited]->(locatie)");
                        query.ExecuteWithoutResults();
                    }
                    userVisited.Add(usr.UniqueKey);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateLocationFacebookCommentRelation(Locatie locatieData, List<FacebookComment> facebookComments)
        {
            try
            {
                foreach (var comment in facebookComments)
                {
                    AddFacebookCommentNode(comment);
                    var query = _client.Cypher
                            .Match("(locatie:Locatie)", "(user:User)")
                            .Where((Locatie locatie) => locatie.UniqueKey == locatieData.UniqueKey)
                            .AndWhere((FacebookComment facebookComment) => facebookComment.FacebookUsername == comment.FacebookUsername)
                            .Create("(facebookComment)-[:Commented_On_Facebook_About]->(locatie)");
                    query.ExecuteWithoutResults();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateLocationDescription(Locatie location) 
        {
            try
            {
                if (location != null && !string.IsNullOrEmpty(location.Description))
                {
                    _client.Cypher.Match("(locatie:Locatie)")
                        .Where((Locatie locatie) => locatie.UniqueKey == location.UniqueKey)
                        .Set("locatie = {location}")
                        .WithParam("location", location)
                        .ExecuteWithoutResults();
                }
            }
            catch (Exception ex) 
            {

            }
        }
    }
}
