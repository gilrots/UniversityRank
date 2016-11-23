
namespace LinkedInChecker.ViewModel
{

    /// <summary>
    /// This class connects between the view and the model
    /// </summary>
    public class EducationViewModel : BaseViewModelEntity<Education>
    {
        #region Properties
        public int StartYear
        {
            get
            {
                return Model.YearFrom;
            }
            set
            {
                Model.YearFrom = value;
                OnpropertyChanged("StartYear");
            }
        }

        public int YearTo
        {
            get
            {
                return Model.YearTo;
            }
            set
            {
                Model.YearTo = value;
                OnpropertyChanged("YearTo");
            }
        }

        public string School
        {
            get
            {
                return Model.School;
            }
            set
            {
                Model.School = value;
                OnpropertyChanged("School");
            }
        }

        public DegreeTypes DegreeType
        {
            get
            {
                return Model.DegreeType;
            }
            set
            {
                Model.DegreeType = value;
                OnpropertyChanged("DegreeType");
            }
        }

        public string FieldOfStudy
        {
            get
            {
                return Model.FieldOfStudy;
            }
            set
            {
                Model.FieldOfStudy = value;
                OnpropertyChanged("FieldOfStudy");
            }
        }

        #endregion

        #region Ctor

        public EducationViewModel(Education education) : base(education)
        {

        }
        protected override void LoadFromModel(Education model)
        {
            Model.School = model.School;
            Model.YearFrom = model.YearFrom;
            Model.YearTo = model.YearTo;
            Model.DegreeType = model.DegreeType;
            Model.FieldOfStudy = model.FieldOfStudy;
        }
        #endregion

    }
}
