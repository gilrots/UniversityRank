using LinkedInChecker.Model;

namespace LinkedInChecker.ViewModel
{
    public class UniversityRankViewModel : BaseViewModelEntity<UniversityRank>
    {

        private string _university;
        private int _rank;

        public string UniversityName
        {
            get
            {
                return _university;
            }
            set
            {
                _university = value;
                OnpropertyChanged("UniversityName");
            }
        }

        public int Rank
        {
            get
            {
                return _rank ;
            }
            set
            {
                _rank = value;
                OnpropertyChanged("Rank");
            }
        }

        public UniversityRankViewModel(UniversityRank model) : base(model)
        {
        }

        protected override void LoadFromModel(UniversityRank model)
        {
            UniversityName = model.University;
            Rank = model.Rank;
        }
    }
}
