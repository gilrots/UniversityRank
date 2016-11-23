using LinkedInChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker.Managers
{
    /// <summary>
    /// Manage skills - filter
    /// </summary>
    public class SkillManager
    {
        #region DataMember
        private SkillViewModel _skill;
        #endregion

        #region Ctor
        public SkillManager(SkillViewModel s)
        {
            _skill = s;
        }
        #endregion

        #region Methods
        public bool FilterTitle(string filter)
        {
            return EntityFilter.FilterText(_skill.Title, filter);
        }
        #endregion
    }
}
