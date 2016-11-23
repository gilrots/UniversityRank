using System;


namespace LinkedInChecker.ViewModel
{
    public class SkillViewModel : BaseViewModelEntity<Skill>, IComparable
    {

        #region Properties
        public string Title
        {
            get
            {
                return Model.Title;
            }
            set
            {
                Model.Title = value;
                OnpropertyChanged("Title");
            }
        }

        #endregion

        #region Ctor
        public SkillViewModel(Skill model) : base(model)
        {

        }

        protected override void LoadFromModel(Skill model)
        {
            Model.Title = model.Title;
        }

        #endregion

        #region Methods
        public int CompareTo(object obj)
        {        
            if (Title.Equals(obj.ToString(), StringComparison.OrdinalIgnoreCase))
                return 1;
            else
                return 0;
        }
        #endregion
    }
}
