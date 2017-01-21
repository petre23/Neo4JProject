using Neo4JController.Helpers;
using Neo4JController.Interfaces;
using Neo4JModel.BO;
using Neo4JModel.DAO;
using Neo4JModel.DAO.SqlDAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TxtCrawler.Common;

namespace Neo4JController.Controllers
{
    public class MainViewController
    {
        IMainView _view;
        private Neo4JController.Controllers.Neo4JDataController _neo4JController;
        private Neo4JController.Controllers.SqlDataController _sqlController;
        private BindingList<Locatie> _allLocations;
        private BindingList<Locatie> _allPositiveLocations;
        private BindingList<Locatie> _allNegativeLocations;
        private float _userAvarage;

        private PrinterHelper _printHelper = new PrinterHelper();


        public MainViewController(IMainView view) 
        {
            _view = view;
            _neo4JController = new Controllers.Neo4JDataController();
            _sqlController = new Controllers.SqlDataController();
        }

        public void StartNeo4JvSqlSearch() 
        {
            if (string.IsNullOrEmpty(_view.TxtSearchBox.Text))
            {
                _view.InfoMessage("Please insert text in search field !");
                _view.BtnClearText.Enabled = false;
                return;
            }
            else
            {
                _view.BtnClearText.Enabled = true;
                var neo4JSerchText = _view.TxtSearchBox.Text;
                var sqlSerchText = _view.TxtSearchBox.Text;

                var neo4JSearchThread = new Thread(() =>
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var locations =  _neo4JController.GetAllLocationsWherNameStartsWith(neo4JSerchText);
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _view.AddTextNeo4JListBoxThreadSafe(string.Format("Found {0} locations", locations.Count.ToString()));
                    _view.AddTextNeo4JListBoxThreadSafe(string.Format("Done in {0} ms",elapsedMs.ToString()));
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
            var watch = System.Diagnostics.Stopwatch.StartNew();
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
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Elapsed time : {0} ms", elapsedMs.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Total Time : {0} ms",elapsedMs.ToString()));
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
            _printHelper.AddTextToBuilder(string.Format("Processing all Locations "));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locationsList = _neo4JController.GetAllLocations();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Locations found : {0}", locationsList.Count));
            _printHelper.AddTextToBuilder(string.Format("Locations found : {0}", locationsList.Count));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ",elapsedMs));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Locations : {0} ms", elapsedMs.ToString()));
            _allLocations = new BindingList<Locatie>(locationsList);
        }

        private void GetAllLocationsThatStartWith(string name)
        {
            _printHelper.AddTextToBuilder(string.Format("Processing all Locations where name starts with {0} : ", name));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locationsWhereNameStartsWithList = _neo4JController.GetAllLocationsWherNameStartsWith(name);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Locations where name starts with {} found : {0}", name, locationsWhereNameStartsWithList.Count));
            _printHelper.AddTextToBuilder(string.Format("Locations where name starts with {} found : {0}", name, locationsWhereNameStartsWithList.Count));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Locations : {0} ms", elapsedMs.ToString()));
        }

        private void GetAllUses()
        {
            _printHelper.AddTextToBuilder(string.Format("Processing all Users "));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var usersList = _neo4JController.GetAllUsers();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Users found : {0}", usersList.Count));
            _printHelper.AddTextToBuilder(string.Format("Users found : {0}", usersList.Count));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Users : {0} ms", elapsedMs.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        private void GetAllUsersWhereNameStartWith(string name)
        {
            _printHelper.AddTextToBuilder(string.Format("Processing all users where name starts with {0} : ", name));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var usersList = _neo4JController.GetAllUsersWhereNameStartsWith(name);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Users where name starts with {} found : {0}", name, usersList.Count));
            _printHelper.AddTextToBuilder(string.Format("Users where name starts with {} found : {0}", name, usersList.Count));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Users : {0} ms", elapsedMs.ToString()));
        }

        private void GetAllComments()
        {
            _printHelper.AddTextToBuilder("Processing all Comments : ");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var comments = _neo4JController.GetAllComments();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Comments found : {0}", comments.Count));
            _printHelper.AddTextToBuilder(string.Format("Comments found : {0}", comments.Count));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Comments : {0} ms", elapsedMs.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        private void GetAllPositiveComments()
        {
            _printHelper.AddTextToBuilder("Processing all Positive Comments : ");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var comments = _neo4JController.GetAllPositiveComments();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Positive Comments found : {0}", comments.Count));
            _printHelper.AddTextToBuilder(string.Format("Positive Comments found : {0}", comments.Count));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Comments : {0} ms", elapsedMs.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        private void GetAllNegativeComments()
        {
            _printHelper.AddTextToBuilder("Processing all Negative Comments : ");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var comments = _neo4JController.GetAllNegativeComments();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format("Negative Comments found : {0}", comments.Count));
            _printHelper.AddTextToBuilder(string.Format("Negative Comments found : {0}", comments.Count));
            _view.AddToTextBox(string.Format("Elapsed time for getting all Comments : {0} ms", elapsedMs.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        private void GetUserAvarageGrade()
        {
            _printHelper.AddTextToBuilder(string.Format("Procesing avarage user rating for all Locations"));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var userGrateAvarage = _neo4JController.GetUsersAvarageGrade();
            _printHelper.AddTextToBuilder(userGrateAvarage.ToString());
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _printHelper.AddTextToBuilder(string.Format("User avarage : {0}", userGrateAvarage.ToString()));
            _view.AddToTextBox(string.Format("User avarage grad total : {0}", userGrateAvarage.ToString()));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            _userAvarage = userGrateAvarage;
        }

        private void GetLocationsThatHaveMoreThan10PositiveComments()
        {
            _printHelper.AddTextToBuilder(string.Format("Procesing locations with more then 10 positive comments"));
            _view.AddToTextBox(string.Format("Procesing locations with more then 10 positive comments"));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWithMoreThanTenPositiveComments();
            _printHelper.AddTextToBuilder(string.Format("Locations found : {0}", locations.Count));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format(string.Format("Locations found : {0}", locations.Count)));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            _allPositiveLocations = new BindingList<Locatie>(locations);
        }

        private void GetLocationsThatHaveMoreThan10NegativeComments()
        {
            _printHelper.AddTextToBuilder(string.Format("Procesing locations with more then 10 negative comments"));
            _view.AddToTextBox(string.Format("Procesing locations with more then 10 negative comments"));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWithMoreThanTenNegativeComments();
            _printHelper.AddTextToBuilder(string.Format("Locations found : {0}", locations.Count));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format(string.Format("Locations found : {0}", locations.Count)));
            _view.AddToTextBox(string.Format(string.Format("Done in {0} ms ", elapsedMs)));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            _allNegativeLocations = new BindingList<Locatie>(locations);
        }


        private List<Locatie> GetLocationsWhereNameStartsWith(string nameStart)
        {
            _printHelper.AddTextToBuilder(string.Format("Procesing locations where name starts with : {0}",nameStart));
            _view.AddToTextBox(string.Format("Procesing locations where name starts with : {0}", nameStart));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetAllLocationsWherNameStartsWith(nameStart);
            _printHelper.AddTextToBuilder(string.Format("Locations found : {0}", locations.Count));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format(string.Format("Locations found : {0}", locations.Count)));
            _view.AddToTextBox(string.Format(string.Format("Done in {0} ms ", elapsedMs)));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
            return locations.ToList();
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
            _printHelper.AddTextToBuilder(string.Format("Procesing locations where description contains : {0}", text));
            _view.AddToTextBox(string.Format("Procesing locations where description contains : {0}", text));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var locations = _neo4JController.GetLocationsWhereDescriptionContains(text);
            _printHelper.AddTextToBuilder(string.Format("Locations found : {0}", locations.Count));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format(string.Format("Locations found : {0}", locations.Count)));
            _view.AddToTextBox(string.Format(string.Format("Done in {0} ms ", elapsedMs)));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        private void GetUserForLocation(Locatie locatie)
        {
            _printHelper.AddTextToBuilder(string.Format("Procesing users for location : {0}", locatie.Nume));
            _view.AddToTextBox(string.Format(string.Format("Procesing users for location : {0}", locatie.Nume)));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var users = _neo4JController.GetAllUsersForLocation(locatie);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            if (users.Count > 0)
            {
                _printHelper.AddTextToBuilder(string.Format("Users found : {0}", users.Count));
                _view.AddToTextBox(string.Format(string.Format("Users found : {0}", users.Count)));
                _view.AddToTextBox(string.Format(string.Format("Done in {0} ms ", elapsedMs)));
            }
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
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
            _printHelper.AddTextToBuilder(string.Format("Procesing users where name starts with : {0}", text));
            _view.AddToTextBox(string.Format(string.Format("Procesing users where name starts with  : {0}", text)));
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var users = _neo4JController.GetAllUsersWhereNameStartsWith(text);
            watch.Stop();
            _printHelper.AddTextToBuilder(string.Format("Users found : {0}", users.Count));
            var elapsedMs = watch.ElapsedMilliseconds;
            _view.AddToTextBox(string.Format(string.Format("Users found : {0}", users.Count)));
            _view.AddToTextBox(string.Format(string.Format("Done in {0} ms ", elapsedMs)));
            _printHelper.AddTextToBuilder(string.Format("Done in {0} ms ", elapsedMs));
        }

        public void ClearTextFromTextBoxes()
        {
            _view.LbNeo4JSearch.Items.Clear();
            _view.LbSqlSearch.Items.Clear();
            _view.TxtSearchBox.Clear();
            _view.BtnClearText.Enabled = false;
        }
    }
}
