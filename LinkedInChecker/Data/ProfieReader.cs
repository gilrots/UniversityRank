using System.Collections.Generic;
using System.IO;

namespace LinkedInChecker
{
    /// <summary>
    /// this class can reads profiles from the db
    /// </summary>
    public class ProfileReader 
    {
        #region Const
        public const string DATABASE_PATH = "C:\\LinkedInData.txt";
        #endregion

        #region DataMembers
        private static ProfileReader _instance;
        #endregion

        #region Properties
        public static ProfileReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProfileReader();
                }
                return _instance;
            }
        }
        #endregion

        #region Ctor
        private ProfileReader()
        {
        }

        #endregion

        #region Methods
        public List<Profile> GetAllProfiles()
        {
            var ProfileList = new List<Profile>();

            var streamReader = new StreamReader(DATABASE_PATH);

            var str = streamReader.ReadLine();
            while (str != null)
            { 
                ProfileList.Add(GetProfile(str));
                str = streamReader.ReadLine();
            }
            return ProfileList;
        }

        public Profile GetProfile(string str)
        {
            var profileReturn = EntityFactory<Profile>.CreateEntity();

            string[] x = str.Split(Global.FIRSTLEVEL);

            profileReturn.Parse(x);

            return profileReturn;
        }

        #endregion
    }
}
