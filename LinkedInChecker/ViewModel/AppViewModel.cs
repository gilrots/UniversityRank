using LinkedInChecker.Analyze;
using LinkedInChecker.Managers;
using LinkedInChecker.ViewModel;

namespace LinkedInChecker
{
    /// <summary>
    /// Manage the MainWindow - connects between the view and the BL
    /// </summary>
    public class AppViewModel : BaseViewModel
    {
        #region DataMembers
        private ProfileAnalyzer _profileAnalyzer;
        #endregion

        #region Properties
        public ProfilesManager ProfilesManager { get; set; }
        public UniversityRankManager UniversityManager { get; set; }
        public ProfileAnalyzer ProfileAnalyzer
        {
            get
            {
                return _profileAnalyzer;
            }
            set
            {
                _profileAnalyzer = value;
                OnpropertyChanged("ProfileAnalyzer");
            }
        }

        #endregion

        #region Commands       
        public RelayCommand GeneralFilterProfile { get; set; }
        public RelayCommand SkillsSearchProfile { get; set; }
        public RelayCommand ChangeDisplayProfile { get; set; }
        public RelayCommand AnalyzeEnglishQuality { get; set; }

        #endregion

        #region Ctor
        public AppViewModel()
        {    
            GeneralFilterProfile = new RelayCommand(GeneralFilter);
            SkillsSearchProfile = new RelayCommand(SkillsSearch);
            ChangeDisplayProfile = new RelayCommand(DisplayAllOrNot);
            AnalyzeEnglishQuality = new RelayCommand(AnalyzeEnglish);

            ProfilesManager = new ProfilesManager();
            ProfileAnalyzer = new ProfileAnalyzer(string.Empty, string.Empty);
            UniversityManager = new UniversityRankManager();

        }

        #endregion

        #region CommandActions   
        public void AnalyzeEnglish(object parameter)
        {
            if (parameter != null)
            {
                var profile = ProfilesManager.GetProfileByID(long.Parse(parameter.ToString()));
                ProfileAnalyzer = new ProfileAnalyzer(profile.Name, profile.Summary);
                ProfileAnalyzer.CalcEnglishLevelBySummary();
            }
        }
        public void GeneralFilter(object parameter)
        {
            ProfilesManager.Filter = parameter.ToString();
            ProfilesManager.MakeGeneralFilter();
        }

        public void DisplayAllOrNot(object parameter)
        {
            var selectedIndex = int.Parse(parameter.ToString());
            if (Global.INDEXOFALLPROFILE.Equals(selectedIndex))
                ProfilesManager.AddAllProfiles();
            else if (Global.INDEXOFRECENTLYPROFILE.Equals(selectedIndex))
                ProfilesManager.AddRecentlyAddedProfiles();

        }

        public void SkillsSearch(object parameter)
        {
            ProfilesManager.Filter = parameter.ToString();
            ProfilesManager.MakeSkillsFilter();

        }

        #endregion


    }
}
