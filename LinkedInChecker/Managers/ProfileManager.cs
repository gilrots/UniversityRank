using LinkedInChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker.Managers
{
    /// <summary>
    /// Manage a profile - filter, Search
    /// </summary>
    public class ProfileManager
    {
        #region DataMembers
        private ProfileViewModel _profile;

        #endregion

        #region Ctor
        public ProfileManager(ProfileViewModel p)
        {
            _profile = p;
        }
        #endregion

        #region methods
        public bool FilterName(string Filter)
        {
            return EntityFilter.FilterText(_profile.Name, Filter);
        }

        public bool FilterTitle(string Filter)
        {
            return EntityFilter.FilterText(_profile.CurrentTitle, Filter);
        }

        public bool FilterCurrentPosition(string Filter)
        {
            return EntityFilter.FilterText(_profile.CurrentPosition, Filter);
        }

        public bool FilterSummery(string Filter)
        {
            return EntityFilter.FilterText(_profile.Summary, Filter);
        }

        public bool FilterSkills(string filter)
        {
            foreach (var currSkill in _profile.Skills)
            {
                if (new SkillManager(currSkill).FilterTitle(filter))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SearchSkill(string skillTitle)
        {
            foreach (var currSkill in _profile.Skills)
            {
                if (currSkill.CompareTo(skillTitle).Equals(1))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
