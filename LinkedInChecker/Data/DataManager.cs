using LinkedInChecker.Data;
using LinkedInChecker.Model;
using System.Collections.Generic;


namespace LinkedInChecker
{
    /// <summary>
    /// this class represents the data from the db
    /// </summary>
    public class DataManager
    {
        private static DataManager _instance;
        private List<Profile> _profiles;
        private List<UniversityRank> _universityRanks; 
        public static DataManager _Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }

        public List<Profile> Profiles => _profiles ?? (_profiles = ProfileReader.Instance.GetAllProfiles());

        public List<UniversityRank> UniversityRanks => _universityRanks ?? (_universityRanks = URankReader.Instance.GetAllRanks());

        private DataManager()
        {

        }
    }
}
