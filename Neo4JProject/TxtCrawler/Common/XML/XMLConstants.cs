using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtCrawler.Common.XML
{
    public class XMLConstants
    {
        public static readonly string XMLSettingsFilePath = @"C:\Users\Petre\Documents\Visual Studio 2013\Projects\Neo4JProject\TxtCrawler\Common\XML\CrawlerSettings.xml";
        public static readonly string SettingsTag = "Settings";
        public static readonly string TitleTag = "Title";
        public static readonly string DescriptionIdTag = "DescriptionId";
        public static readonly string ReviewSummaryTag = "ReviewSummary";
        public static readonly string UserProfileTag = "UserProfile";
        public static readonly string PositiveCommentTag = "PositiveComment";
        public static readonly string NegativeCommentTag = "NegativeComment";
        public static readonly string UserGradeTag = "UserGrade";
        public static readonly string RoomsBaseTag = "RoomsBase";
        public static readonly string RoomTypeTag = "RoomType";
        public static readonly string HasBathroomTag = "HasBathroom";
        public static readonly string RoomsTag = "Rooms";
        public static readonly string RoomPriceTag = "RoomPrice";

        public static List<string> XMLTagsList 
        {
            get
            {
                var listToReturn = new List<string>();
                listToReturn.Add(TitleTag);
                listToReturn.Add(DescriptionIdTag);
                listToReturn.Add(ReviewSummaryTag);
                listToReturn.Add(UserProfileTag);
                listToReturn.Add(PositiveCommentTag);
                listToReturn.Add(NegativeCommentTag);
                listToReturn.Add(UserGradeTag);
                listToReturn.Add(RoomsBaseTag);
                listToReturn.Add(RoomTypeTag);
                listToReturn.Add(HasBathroomTag);
                listToReturn.Add(RoomsTag);
                listToReturn.Add(RoomPriceTag);
                return listToReturn;
            }
        }
    }
}
