using LinkedInChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinkedInChecker.Managers
{
    /// <summary>
    /// Manage Profiles - Filter/search in many prof
    /// </summary>
    public class ProfilesManager : BaseViewModel
    {
        #region DataMembers
        private ObservableCollection<ProfileViewModel> _profiles { get; set; }
        private bool isFilterGeneral;
        private bool isSearchForSkill;

        #endregion

        #region Properties
        public string Filter;
        public ObservableCollection<ProfileViewModel> Profiles
        {
            get
            {
                return _profiles;
            }
        }

        #endregion

        #region Ctor
        public ProfilesManager()
        {
            updateProfiles(DataManager._Instance.Profiles.Select(x => new ProfileViewModel(x)));
        }

        #endregion

        #region Methods   
        private void updateProfiles(IEnumerable<ProfileViewModel> collection)
        {
            _profiles = new ObservableCollection<ProfileViewModel>(collection);
            OnpropertyChanged("Profiles");
            CollectionViewSource.GetDefaultView(Profiles).Filter = filterProfiles;
        }

        public void MakeGeneralFilter()
        {
            isFilterGeneral = true;
            CollectionViewSource.GetDefaultView(Profiles).Refresh();
            isFilterGeneral = false;
        }

        public void AddAllProfiles()
        {
            updateProfiles(DataManager._Instance.Profiles.Select(x => new ProfileViewModel(x)));
        }

        public void MakeSkillsFilter()
        {
            isSearchForSkill = true;
            CollectionViewSource.GetDefaultView(Profiles).Refresh();
            isSearchForSkill = false;
        }
        public void AddRecentlyAddedProfiles()
        {
            updateProfiles(Profiles.Where(x => x.CreateTime > DateTime.Now.AddMonths(-1)));
        }

        private bool filterProfiles(object item)
        {
            if (isFilterGeneral)
            {

                return generalFilter(item);
            }
            else if (isSearchForSkill)
            {

                return searchSkill(item);
            }

            return true;
        }

        private bool generalFilter(object item)
        {
            if (String.IsNullOrEmpty(Filter))
                return true;
            else
            {
                var profileManager = new ProfileManager((ProfileViewModel)item);

                return profileManager.FilterName(Filter) ||
                         profileManager.FilterTitle(Filter) ||
                        profileManager.FilterCurrentPosition(Filter) ||
                      profileManager.FilterSummery(Filter) ||
                       profileManager.FilterSkills(Filter);
            }
        }


        private bool searchSkill(object item)
        {
            if (String.IsNullOrEmpty(Filter))
                return true;
            else
            {
                var profileManager = new ProfileManager((ProfileViewModel)item);

                return profileManager.SearchSkill(Filter);
            }
        }

        public ProfileViewModel GetProfileByID(long ID)
        {  
             return Profiles.Where(x => x.ID.Equals(ID)).Cast<ProfileViewModel>().First();
        }

        #endregion
    }
}
