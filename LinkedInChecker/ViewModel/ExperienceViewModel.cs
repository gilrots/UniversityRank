using System;


namespace LinkedInChecker
{
    public class ExperienceViewModel : BaseViewModelEntity<Experience>
    {
        #region Properties
        public DateTime DateFrom
        {
            get
            {
                return Model.StartFrom;
            }
            set
            {
                Model.StartFrom = value;
                OnpropertyChanged("DateFrom");
            }
        }

        public DateTime DateTo
        {
            get
            {
                return Model.StartTo;
            }
            set
            {
                Model.StartTo = value;
                OnpropertyChanged("DateTo");
            }
        }


        public string JobTitle
        {
            get
            {
                return Model.JobTitle;
            }
            set
            {
                Model.JobTitle = value;
                OnpropertyChanged("JobTitle");
            }
        }
        public string Place
        {
            get
            {
                return Model.Place;
            }
            set
            {
                Model.Place = value;
                OnpropertyChanged("Place");
            }
        }

        #endregion

        #region Ctor
        public ExperienceViewModel(Experience ex) : base(ex)
        {

        }

        protected override void LoadFromModel(Experience model)
        {
            Model.Id = model.Id;
            Model.JobTitle = model.JobTitle;
            Model.Place = model.Place;
            Model.StartFrom = model.StartFrom;
            Model.StartTo = model.StartTo;
        }

        #endregion
    }
}
