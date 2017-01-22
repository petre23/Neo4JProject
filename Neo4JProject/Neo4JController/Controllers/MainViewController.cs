using Neo4JController.Helpers;
using Neo4JController.Interfaces;
using Neo4JModel.BO;
using Neo4JModel.DAO;
using Neo4JModel.DAO.SqlDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxtCrawler.Common;

namespace Neo4JController.Controllers
{
    public class MainViewController : IDisposable
    {
        IMainView _view;
        private Neo4JController.Controllers.Neo4JDataController _neo4JController;
        private Neo4JController.Controllers.SqlDataController _sqlController;
        private BindingList<Locatie> _allLocations;
        private BindingList<Locatie> _allPositiveLocations;
        private BindingList<Locatie> _allNegativeLocations;
        private float _userAvarage;
        System.Diagnostics.Stopwatch _watch;

        private PrinterHelper _printHelper = new PrinterHelper();

        public MainViewController(IMainView view) 
        {
            _view = view;
            _neo4JController = new Controllers.Neo4JDataController();
            _sqlController = new Controllers.SqlDataController();
        }

        public void StartNeo4JvSqlSearch() 
        {
            if (_view.IsSearchBoxEmpty())
            {
                var neo4JSerchText = _view.GetSearchText();
                var sqlSerchText = _view.GetSearchText();

                var neo4JSearchThread = new Thread(() =>
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var locations = _neo4JController.GetAllLocationsWherNameStartsWith(neo4JSerchText);
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} locations", locations.Count.ToString()));
                    _view.AddTextNeo4JListBoxThreadSafe(string.Format("Done in {0} ms", elapsedMs.ToString()));
                });

                var sqlSearchThread = new Thread(() =>
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var locations = _sqlController.GetAllLocationsWherNameStartsWith(sqlSerchText);
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _view.AddTextSqlListBoxThreadSafe(string.Format("Found {0} locations", locations.Count.ToString()));
                    _view.AddTextSqlListBoxThreadSafe(string.Format("Done in {0} ms", elapsedMs.ToString()));
                });

                neo4JSearchThread.Start();
                sqlSearchThread.Start();
            }
        }


        public void StartVersusComparation() 
        {
            var neoThread = new Thread(StartNeo4JExecution);
            var sqlThread = new Thread(StartSqlExecution);

            neoThread.Start();
            sqlThread.Start();
        }


        private void StartSqlExecution() 
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var allLocations = _sqlController.GetAllLocations();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 6763 locations , in {0} ms", watch.ElapsedMilliseconds));
                var allUsers = _sqlController.GetAllUsers();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 4092 users in {0} ms",  watch.ElapsedMilliseconds));
                var allComments = _sqlController.GetAllComments();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 4092 comments in {0} ms", watch.ElapsedMilliseconds));
                var allPositiveComments = _sqlController.GetAllPositiveComments();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 4004 positive comments in {0} ms", watch.ElapsedMilliseconds));
                var allNegativeComments = _sqlController.GetAllNegativeComments();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 2204 negative comments in {0} ms",  watch.ElapsedMilliseconds));
                var locationWithPositiveComments = _sqlController.GetAllLocationsWithMoreThanTenPositiveComments();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 125 locations that have more than 10 positive commenents in {0} ms", watch.ElapsedMilliseconds));
                var locationWithNegativeComments = _sqlController.GetAllLocationsWithMoreThanTenNegativeComments();
                _view.AddTextSqlListBoxThreadSafe(string.Format("Found 50 locations that have more than 10 negative commenents comments in {0} ms", watch.ElapsedMilliseconds));
                var elapsedMs = watch.ElapsedMilliseconds;
                _view.AddTextSqlListBoxThreadSafe(string.Format("Done in {0} ms", elapsedMs.ToString()));
            }
            catch (Exception ex) 
            {

            }
        }

        private void StartNeo4JExecution()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var allLocations = _neo4JController.GetAllLocations();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} locations , in {1} ms", allLocations.Count, watch.ElapsedMilliseconds));
                var allUsers = _neo4JController.GetAllUsers();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} users in {1} ms", allUsers.Count, watch.ElapsedMilliseconds));
                var allComments = _neo4JController.GetAllComments();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} comments in {1} ms", allComments.Count, watch.ElapsedMilliseconds));
                var allPositiveComments = _neo4JController.GetAllPositiveComments();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} positive comments in {1} ms", allPositiveComments.Count, watch.ElapsedMilliseconds));
                var allNegativeComments = _neo4JController.GetAllNegativeComments();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} negative comments in {1} ms", allNegativeComments.Count, watch.ElapsedMilliseconds));
                var locationWithPositiveComments = _neo4JController.GetAllLocationsWithMoreThanTenPositiveComments();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} locations that have more than 10 positive commenents in {1} ms", locationWithPositiveComments.Count, watch.ElapsedMilliseconds));
                var locationWithNegativeComments = _neo4JController.GetAllLocationsWithMoreThanTenNegativeComments();
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} locations that have more than 10 negative commenents comments in {1} ms", locationWithNegativeComments.Count, watch.ElapsedMilliseconds));
                var elapsedMs = watch.ElapsedMilliseconds;
                _view.AddTextNeo4JListBoxThreadSafe(string.Format("Done in {0} ms", elapsedMs.ToString()));
            }
            catch (Exception ex)
            {

            }
        }

        public void OpenDatabseGenerator() 
        {
            var databaseGenrator = new MainView();
            databaseGenrator.Show();
        }

        public void ExecuteAnalysis() 
        {
            ExecuteDatabaseNeo4jAnalyser();
        }

        private void ExecuteDatabaseNeo4jAnalyser()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            GetAllLocations();
            GetAllUses();
            GetAllComments();
            GetAllNegativeComments();
            GetAllPositiveComments();
            GetUserAvarageGrade();
            GetLocationsThatHaveMoreThan10PositiveComments();
            GetLocationsThatHaveMoreThan10NegativeComments();
            GetDataWhereLocationStratsWith();
            GetLocationsWithDescriptionContaining();
            GetUsersWithNameStart();
            _watch.Stop();
            WriteInfo("Elapsed time : {0} ms");
        }

        public void PrintRaport() 
        {
            _printHelper.SaveReport();
        }

        public BindingList<Locatie> GetAllLocationsDataSource() 
        {
            return _allLocations;
        }

        public BindingList<Locatie> GetPositiveDataSource()
        {
            return _allPositiveLocations;
        }

        public BindingList<Locatie> GetNegativeDataSource()
        {
            return _allNegativeLocations;
        }

        public float GetUsersAvarageGrade() 
        {
            return _userAvarage;
        }

        private List<string> LocationStartTextList()
        {
            var list = new List<string>();
            list.Add("Pensi");
            list.Add("Hote");
            list.Add("Cam");
            list.Add("Cas");
            list.Add("Casa");
            list.Add("Ca");
            list.Add("Apar");
            list.Add("Ap");
            return list;
        }

        private void GetDataWhereLocationStratsWith()
        {
            Parallel.ForEach(LocationStartTextList(), (locationStart) =>
            {
                var locations = GetLocationsWhereNameStartsWith(locationStart);
                foreach (var loc in locations)
                {
                    GetUserForLocation(loc);
                }
            });
        }

        private void GetAllLocations() 
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocations();
            _allLocations = new BindingList<Locatie>(locations);
            ExecuteNeo4JActionForList<Locatie>("Processed all Locations : ", locations);
        }

        private void GetAllLocationsThatStartWith(string name)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<Locatie>(string.Format("Processed all Locations where name starts with:{0} ",name), _neo4JController.GetAllLocationsWherNameStartsWith(name));
        }

        private void GetAllUses()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<User>("Processed all users : ", _neo4JController.GetAllUsers());
        }

        private void GetAllUsersWhereNameStartWith(string name)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<User>(string.Format("Processed all Users where name starts with:{0} ",name), _neo4JController.GetAllUsersWhereNameStartsWith(name));
        }

        private void GetAllComments()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<Comment>("Processed all comments : ", _neo4JController.GetAllComments());
        }

        private void GetAllPositiveComments()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<Comment>("Processed all positive comments : ", _neo4JController.GetAllPositiveComments());
        }

        private void GetAllNegativeComments()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            ExecuteNeo4JActionForList<Comment>("Processed all negative comments : ", _neo4JController.GetAllNegativeComments());
        }

        private void GetUserAvarageGrade()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var userGrateAvarage = _neo4JController.GetUsersAvarageGrade();
            _userAvarage = userGrateAvarage;
            ExecuteNeo4JAction<float>("Processed Avarage Grade : ", userGrateAvarage);
        }

        private void GetLocationsThatHaveMoreThan10PositiveComments()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWithMoreThanTenPositiveComments();
            _allPositiveLocations = new BindingList<Locatie>(locations);
            ExecuteNeo4JActionForList<Locatie>("Processed all locations that have more than 10 positive comments : ", locations);
        }

        private void GetLocationsThatHaveMoreThan10NegativeComments()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWithMoreThanTenNegativeComments();
            _allNegativeLocations = new BindingList<Locatie>(locations);
            ExecuteNeo4JActionForList<Locatie>("Processed all locations that have more than 10 negativs comments : ", locations);
        }


        private List<Locatie> GetLocationsWhereNameStartsWith(string nameStart)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWherNameStartsWith(nameStart);
            _allPositiveLocations = new BindingList<Locatie>(locations);
            ExecuteNeo4JActionForList<Locatie>(string.Format("Processed locations where name starts with : {0}", nameStart), locations);
            return locations;
        }

        private void GetLocationsWithDescriptionContaining() 
        {
            var list = new List<string>() {"Baie","Masa","Frumos","Priveliste","Deal","Camp","Munte","Aer","Oameni"};
            foreach (var descr in list) 
            {
                GetLocationsWhereDescriptionContains(descr);
            }
        }

        private void GetLocationsWhereDescriptionContains(string text)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetLocationsWhereDescriptionContains(text);
            ExecuteNeo4JActionForList<Locatie>(string.Format("Processed locations where description contains : {0}", text), locations);
        }

        private void GetUserForLocation(Locatie locatie)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var users = _neo4JController.GetAllUsersForLocation(locatie);
            ExecuteNeo4JActionForList<User>(string.Format("Processed locations where description contains : {0}", locatie.Nume), users);
        }


        private void GetUsersWithNameStart() 
        {
            var list = new List<string> { "Al","An","Bo","Cr","Cl","Ma","Pe","So","Fl","Li","Ad","Mi","Re","Io","Eu","Ge","Ghe","Va"};
            foreach (var name in list) 
            {
                GetUserWhereUserNameStartsWith(name);
            }
        }

        private void GetUserWhereUserNameStartsWith(string text)
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
            var users = _neo4JController.GetAllUsersWhereNameStartsWith(text);
            ExecuteNeo4JActionForList<User>(string.Format("Processed users where name starts with : {0}", text), users);
        }

        public void ClearTextFromTextBoxes()
        {
            _view.ClearView();
        }

        public void Dispose()
        {
            _view = null;
            _sqlController.Dispose();
            _neo4JController.Dispose();
            _allLocations = null;
            _allNegativeLocations = null;
            _allPositiveLocations = null;
            _userAvarage = 0;
        }

        private void ExecuteNeo4JActionForList<T>(string actionMessage, List<T> list) 
        {
            _printHelper.AddTextToBuilder(actionMessage);
            _watch.Stop();
            var elapsedMs = _watch.ElapsedMilliseconds;
            if (list.Any())
            {
                var type = list.FirstOrDefault().GetType().Name.ToString();
                WriteInfo(string.Format("{0} {1}",actionMessage, list.Count));
            }
        }

        private void ExecuteNeo4JAction<T>(string actionMessage, T obj)
        {
            _printHelper.AddTextToBuilder(actionMessage);
            _printHelper.AddTextToBuilder(obj.ToString());
            _watch.Stop();
            WriteInfo(string.Format("{0} for {1}", actionMessage, obj.ToString()));
        }

        private void WriteInfo(string text) 
        {
            var elapsedMs = _watch.ElapsedMilliseconds;
            if (string.IsNullOrEmpty(text))
            {
                _printHelper.AddTextToBuilder(string.Format("Processing finised in {0} ms ", elapsedMs));
            }
            else
            {
                _view.AddToTextBox(text);
                _printHelper.AddTextToBuilder(text);
                _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            }
        }
    }
}
