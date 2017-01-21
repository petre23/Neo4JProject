using Neo4JModel.BO;
using Neo4JModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO
{
    public class CommentDAO:BaseDAO
    {
        public CommentDAO()
            : base()
        { }

        public List<Comment> GetAllCommetsFromDB()
        {
            var comment = _client.Cypher
                        .Match("(type:Comment)")
                        .Return(type => type.As<Comment>())
                        .Results;

            return comment.ToList();
        }

        public Comment GetCommentsByUniqueKey(string uniqueKey)
        {
            var comments = _client.Cypher
                            .Match("(comment:Comment)")
                            .Where((Comment comment) => comment.UniqueKey == uniqueKey)
                            .Return(comment => comment.As<Comment>())
                            .Results;
            return comments.ToList().FirstOrDefault();
        }

        public List<Comment> GetAllPositiveComments()
        {
            var comments = _client.Cypher
                            .Match("(comment:Comment)")
                            .Where("comment.PositiveComment is not null")
                            .Return(comment => comment.As<Comment>())
                            .Results;
            return comments.ToList();
        }

        public List<Comment> GetAllNegativeComments()
        {
            var comments = _client.Cypher
                            .Match("(comment:Comment)")
                            .Where("comment.NegativeComment is not null")
                            .Return(comment => comment.As<Comment>())
                            .Results;
            return comments.ToList();
        }

        public float GetAvarageUserGrades()
        {
            var comments = _client.Cypher
                            .Match("(comment:Comment)")
                            .Where("comment.PositiveComment is not null")
                            .Return(comment => comment.As<Comment>())
                            .Results;
    
            return CalculateAvarage(comments.ToList());
        }

        private float CalculateAvarage(List<Comment> comments) 
        {
            try
            {
                decimal sum = 0;
                foreach (var comment in comments)
                {
                    sum += comment.UserGrade;
                }

                var avarage = sum / comments.Count;
                return (float)avarage;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
