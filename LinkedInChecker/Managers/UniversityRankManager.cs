using LinkedInChecker.Model;
using LinkedInChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker.Managers
{
    public class UniversityRankManager : BaseViewModel
    {
        private ObservableCollection<UniversityRankViewModel> _universityRanks { get; set; }

        public ObservableCollection<UniversityRankViewModel> UniversitiesRank
        {
            get
            {
                return _universityRanks;
            }
        }
        
        public UniversityRankManager()
        {
            _universityRanks = new ObservableCollection<UniversityRankViewModel>(DataManager._Instance.UniversityRanks.Select(x=>new UniversityRankViewModel(x)));
        }
    }
}
