using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace LinkedInChecker.ViewModel
{
    public class ProfileViewModel : BaseViewModelEntity<Profile>
    {

        #region DataMembers
        private ObservableCollection<SkillViewModel> _skills;
        private ObservableCollection<EducationViewModel> _educations;
        private ObservableCollection<ExperienceViewModel> _experience;

        #endregion

        #region Properties
        public long ID
        {
            get
            {
                return Model.Id;
            }
        }

        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
                OnpropertyChanged("Name");
            }
        }

        public string CurrentTitle
        {
            get
            {
                return Model.CurrentTitle;
            }
            set
            {
                Model.CurrentTitle = value;
                OnpropertyChanged("CurrentTitle");

            }
        }


        public string CurrentPosition
        {
            get
            {
                return Model.CurrentPosition;
            }
            set
            {
                Model.CurrentPosition = value;
                OnpropertyChanged("CurrentPosition");

            }
        }

        public string Summary
        {
            get
            {
                return Model.Summary;
            }
            set
            {
                Model.CurrentPosition = value;
                OnpropertyChanged("Summary");

            }
        }

        public ObservableCollection<SkillViewModel> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                OnpropertyChanged("Skills");
            }
        }

        public ObservableCollection<EducationViewModel> EducationExperience
        {
            get
            {
                return _educations;
            }
            set
            {
                _educations = value;
                OnpropertyChanged("EducationExper");
            }
        }

        public ObservableCollection<ExperienceViewModel> WorkExperience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
                OnpropertyChanged("WorkExperience");
            }
        }

        public DateTime CreateTime
        {
            get
            {
                return Model.CreateTime;
            }
        }

        #endregion

        #region Ctor
        public ProfileViewModel(Profile p) : base(p)
        {

        }
        protected override void LoadFromModel(Profile model)
        {
            Model.CreateTime = model.CreateTime;
            Model.Id = model.Id;
            Model.Name = model.Name;
            Model.Summary = model.Summary;
            Model.CurrentPosition = model.CurrentPosition;
            Model.CurrentTitle = model.CurrentTitle;

            loadEducationsFromModel(model.Educations);
            loadSkillsFromModel(model.Skills);
            loadExperienceFromModel(model.WorkExcperience);
        }

        #endregion

        #region Methods
        private void loadEducationsFromModel(List<Education> EducationList)
        {
            _educations = new ObservableCollection<EducationViewModel>();

            foreach (var currEducation in EducationList)
            {
                _educations.Add(new EducationViewModel(currEducation));
            }
        }

        private void loadSkillsFromModel(List<Skill> SkillsList)
        {
            _skills = new ObservableCollection<SkillViewModel>();

            foreach (var currSkill in SkillsList)
            {
                _skills.Add(new SkillViewModel(currSkill));
            }
        }

        private void loadExperienceFromModel(List<Experience> ExperienceList)
        {
            _experience = new ObservableCollection<ExperienceViewModel>();

            foreach (var currExperience in ExperienceList)
            {
                _experience.Add(new ExperienceViewModel(currExperience));
            }
        }

        #endregion
    }
}
