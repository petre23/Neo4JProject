using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtCrawler.Model;
using TxtCrawler.Helper;
using TxtCrawler.Common.XML;
using TxtCrawler.Common.Controller.SQL;

namespace TxtCrawler.Controller
{
    public class NodesProcessor
    {
        private Neo4jOperations neo4jOP = new Neo4jOperations();
        private SqlProcessor _sqlController = new SqlProcessor();

        public NodesProcessor() 
        {
        }

        public void AddLocationNode(Locatie location) 
        {
            neo4jOP.AddLocationNode(location);
        }

        public void ExtractComments(Locatie location,HtmlAgilityPack.HtmlNodeCollection nodeCollection)
        {
            var userList = new List<User>();
            foreach (var node in nodeCollection)
            {
                var user = new User();
                var userNode = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.UserProfileTag));
                if (userNode != null)
                {
                    var nodeText = userNode.InnerText.RemovebNbT();
                    var userComponents = nodeText.Split('(');
                    user.UserName = userComponents.FirstOrDefault();
                    user.PerioadaSejur = userComponents.Last().Replace(")", "");
                    userList.Add(user);
                }

                var comments = new Comment();
                var negativeCommentsNode = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.NegativeCommentTag));
                if (negativeCommentsNode != null)
                {
                    var nodeText = negativeCommentsNode.InnerText.RemovebNbT(); ;
                    comments.NegativeComment = nodeText;
                }
                var positiveCommentsNode = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.PositiveCommentTag));
                if (positiveCommentsNode != null)
                {
                    var nodeText = positiveCommentsNode.InnerText.RemovebNbT(); ;
                    comments.PositiveComment = nodeText;
                }
                var gradeCommentsNode = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.UserGradeTag));
                if (gradeCommentsNode != null)
                {
                    var nodeText = gradeCommentsNode.InnerText.RemovebNbT();
                    comments.UserGrade = Convert.ToDecimal(nodeText);
                }

                neo4jOP.CreateUserCommentRelation(user, comments);
                _sqlController.InsertUserWithoutLocation(user);
                _sqlController.InsertComment(comments,user.UserName);
            }
            neo4jOP.CreateLocationUserRelation(location, userList);
            _sqlController.InsertUsersForLocation(userList, location);
        }

        public void ExtractRooms(Locatie location, HtmlAgilityPack.HtmlNodeCollection nodeCollection)
        {
            List<Camera> camere = new List<Camera>();
            foreach (var node in nodeCollection)
            {
                var camera = new Camera();
                var nodTipCamera = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.RoomTypeTag));
                if (nodTipCamera != null)
                {
                    camera.TipCamere = nodTipCamera.InnerText;
                }

                var nodBaie = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.HasBathroomTag));
                if (nodBaie != null)
                {
                    camera.Baie = nodBaie.InnerText;
                }

                var nodCamere = node.SelectSingleNode(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.RoomsTag));
                if (nodCamere != null)
                {
                    camera.NumarCamera = nodCamere.InnerText;
                }

                var nodPret = node.SelectNodes(XMLDataAccess.Instance.GetElementFromFile(XMLConstants.RoomPriceTag));
                if (nodPret != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        camera.Pret.Add(nodPret[i].InnerText);
                    }
                }
                if (!string.IsNullOrEmpty(camera.NumarCamera) || !string.IsNullOrEmpty(camera.Baie) || !string.IsNullOrEmpty(camera.TipCamere))
                    camere.Add(camera);
            }
            if (camere.Any())
                neo4jOP.CreateLocationRoomRelation(location, camere);
        }

        public void ExtractFacebookComments(Locatie location, HtmlAgilityPack.HtmlNodeCollection nodeCollection)
        {
            List<FacebookComment> facebookComments = new List<FacebookComment>();
            foreach (var node in nodeCollection)
            {
                var fbComment = new FacebookComment();
                var fbUsername = node.SelectSingleNode(".//a[@class='UFICommentActorName']");
                if (fbUsername != null)
                {
                    fbComment.FacebookUsername = fbUsername.InnerText.RemovebNbT();
                }
                var fbComm = node.SelectSingleNode(".//span[@class = '_5mdd']");
                if (fbComm != null)
                {
                    var comm = fbComm.InnerText.RemovebNbT();
                    fbComment.Comment = comm;
                }
                if (!string.IsNullOrEmpty(fbComment.FacebookUsername) && !string.IsNullOrEmpty(fbComment.Comment))
                {
                    facebookComments.Add(fbComment);
                }
            }
            if (facebookComments != null)
            {
                neo4jOP.CreateLocationFacebookCommentRelation(location, facebookComments);
            }
        }

        public void UpdateLocation(Locatie location) 
        {
            neo4jOP.UpdateLocationDescription(location);
        }
    }
}
