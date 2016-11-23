using LinkedInChecker.Model;
using System.Collections.Generic;
using System.IO;

namespace LinkedInChecker.Data
{
    /// <summary>
    /// This class can reads universities ranks from the db
    /// </summary>
    public class URankReader
    {
        #region DataMembers
        private static URankReader _instance;
        #endregion

        #region Const
        public const string DATABASE_PATH = "C:\\university_ranks2016.txt";
        #endregion

        #region Properties


        public static URankReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new URankReader();
                }
                return _instance;
            }
        }
        #endregion

        #region Ctor
        private URankReader()
        {
        }
        #endregion

        #region Methods
        public List<UniversityRank> GetAllRanks()
        {
            var ProfileList = new List<UniversityRank>();

            var streamReader = new StreamReader(DATABASE_PATH);

            var str = streamReader.ReadLine();
            while (str != null)
            {
                ProfileList.Add(GetUniversityRank(str));
                str = streamReader.ReadLine();
            }
            return ProfileList;
        }

        public UniversityRank GetUniversityRank(string str)
        {
            var universityRank = EntityFactory<UniversityRank>.CreateEntity();

            string[] x = str.Split(Global.FIRSTLEVEL);

            universityRank.Parse(x);

            return universityRank;
        }

        #endregion
    }
}
