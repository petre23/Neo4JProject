using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JModel.DAO.SqlDAO
{
    public class SqlConstants
    {
        public const string LOCATION_NAME_COLUMN = "Nume";
        public const string LOCATION_DESCRIPTION_COLUMN = "Description";
        public const string UNIQUE_KEY_COLUMN = "UniqueKey";
        public const string COMMENT_POSITIVE_COMMENT_COLUMN = "PositiveComment";
        public const string COMMENT_NEGATIVE_COMMENT_COLUMN = "NegativeComment";
        public const string COMMENT_USER_GRADE_COLUMN = "UserGrade";
        public const string ROOM_NUMBER_COLUMN = "NumarCamera";
        public const string ROOM_TYPE_COLUMN = "TipCamere";
        public const string ROOM_HAS_BATH_COLUMN = "Baie";
        public const string ROOM_PRICE_COLUMN = "Pret";
        public const string ROOM_FOR_COLUMN = "ROOM_FOR";
        public const string USER_NAME_COLUMN = "UserName";
        public const string USER_PERIOD_COLUMN = "PerioadaSejur";
        public const string USER_HAS_VISITED_COLUMN = "Has_Visited";
        public const string AUTHOR_COLUMN = "userID";
        public const string AVARAGE_COLUMN = "Avarage";

        public const string LOCATION_NAME_PARAMETER = "@Nume";
        public const string LOCATION_DESCRIPTION_PARAMETER = "@Description";
        public const string UNIQUE_KEY_PARAMETER = "@UniqueKey";
        public const string COMMENT_POSITIVE_COMMENT_PARAMETER = "@PositiveComment";
        public const string COMMENT_NEGATIVE_COMMENT_PARAMETER = "@NegativeComment";
        public const string COMMENT_USER_GRADE_PARAMETER = "@UserGrade";
        public const string ROOM_NUMBER_PARAMETER = "@NumarCamera";
        public const string ROOM_TYPE_PARAMETER = "@TipCamere";
        public const string ROOM_HAS_BATH_PARAMETER = "@Baie";
        public const string ROOM_PRICE_PARAMETER = "@Pret";
        public const string ROOM_FOR_PARAMETER = "@ROOM_FOR";
        public const string USER_NAME_PARAMETER = "@UserName";
        public const string USER_PERIOD_PARAMETER = "@PerioadaSejur";
        public const string USER_HAS_VISITED_PARAMETER = "@Has_Visited";
        public const string AUTHOR_PARAMETER = "@userID";


        public const string GET_ALL_LOCATIONS_QUERY = "SELECT * FROM Locatie";
        public const string GET_ALL_LOCATIONS_THAT_START_WITH_QUERY = "SELECT * FROM Locatie WHERE Nume LIKE @Nume";
        public const string GET_ALL_USERS_QUERY = "SELECT * FROM SYS_User";
        public const string GET_ALL_COMMENTS_QUERY = "SELECT * FROM COMMENT";
        public const string GET_ALL_USER_FOR_LOCATION_QUERY = "SELECT * FROM SYS_USER WHERE locationID = @Nume";
        public const string GET_ALL_COMMENTS_FOR_USER_QUERY = "SELECT * FROM COMMENT WHERE userID = @userID";
        public const string GET_ALL_COMMENTS_WITH_POSITIVE_FEEDBACK_QUERY = "SELECT * FROM COMMENT WHERE PositiveComment IS NOT NULL";
        public const string GET_ALL_COMMENTS_WITH_NEGATIVE_FEEDBACK_QUERY = "SELECT * FROM COMMENT WHERE NegativeComment IS NOT NULL";
        public const string GET_USER_GRADES_AVARAGE_QUERY = "SELECT AVG(CAST(Comment.UserGrade AS float))as Avarage FROM COMMENT";
        public const string GET_USER_WHERE_NAME_STARTS_WITH_QUERY = "SELECT * FROM SYS_User WHERE UserName LIKE @UserName";
        public const string GET_LOCATIONS_WITH_MORE_THAN_TEN_POSITIVE_COMMENTS = @"   DECLARE @NumeLocatie varchar(250),@Result int
                                                                                                DECLARE @tempTable table(Nume varchar(250))

                                                                                                DECLARE cursor_locatii CURSOR for 
                                                                                                SELECT DISTINCT Nume
                                                                                                from Locatie INNER JOIN 
                                                                                                SYS_User ON SYS_User.locationID = Nume

                                                                                                OPEN cursor_locatii

                                                                                                WHILE @@FETCH_STATUS = 0
                                                                                                BEGIN
	                                                                                                Fetch NEXT from cursor_locatii into @NumeLocatie
	                                                                                                SELECT DISTINCT @Result = Count(*) FROM SYS_User where SYS_User.locationID = @NumeLocatie AND(SELECT DISTINCT Count(*) from Comment where COMMENT.userID = SYS_User.UserName AND COMMENT.PositiveComment <> ' ') > 0
	                                                                                                IF @Result >= 10
		                                                                                                Insert into @tempTable values (@NumeLocatie)
	                                                                                                ELSE 
		                                                                                                PRINT 'no'
                                                                                                END
                                                                                                close cursor_locatii
                                                                                                DEALLOCATE cursor_locatii
                                                                                                Select * from @tempTable
                                                                                                Delete from @tempTable";

        public const string GET_LOCATIONS_WITH_MORE_THAN_TEN_NEGATIVE_COMMENTS = @"   DECLARE @NumeLocatie varchar(250),@Result int
                                                                                                DECLARE @tempTable table(Nume varchar(250))

                                                                                                DECLARE cursor_locatii CURSOR for 
                                                                                                SELECT DISTINCT Nume
                                                                                                from Locatie INNER JOIN 
                                                                                                SYS_User ON SYS_User.locationID = Nume

                                                                                                OPEN cursor_locatii

                                                                                                WHILE @@FETCH_STATUS = 0
                                                                                                BEGIN
	                                                                                                Fetch NEXT from cursor_locatii into @NumeLocatie
	                                                                                                SELECT DISTINCT @Result = Count(*) FROM SYS_User where SYS_User.locationID = @NumeLocatie AND(SELECT DISTINCT Count(*) from Comment where COMMENT.userID = SYS_User.UserName AND COMMENT.NegativeComment <> ' ') > 0
	                                                                                                IF @Result >= 10
		                                                                                                Insert into @tempTable values (@NumeLocatie)
	                                                                                                ELSE 
		                                                                                                PRINT 'no'
                                                                                                END
                                                                                                close cursor_locatii
                                                                                                DEALLOCATE cursor_locatii
                                                                                                Select * from @tempTable
                                                                                                Delete from @tempTable";
    }
}
