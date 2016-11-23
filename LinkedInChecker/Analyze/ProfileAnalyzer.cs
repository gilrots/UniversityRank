using LinkedInChecker.Model;
using LinkedInChecker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LinkedInChecker.Analyze
{
    /// <summary>
    /// Represents the analyze Profile - spell checking, universities rank
    /// </summary>
    public class ProfileAnalyzer : BaseViewModel
    {
        #region DataMembers

        private bool _isValid;
        private EnglishLevels _englishLevel;
        private string _profileName = string.Empty;

        private Dictionary<Func<double, bool>, EnglishLevels> _englishLevels = new Dictionary<Func<double, bool>, EnglishLevels>
        {
            {x=>x <= 0.15, EnglishLevels.Good },
            {x=>x > 0.15 && x<=0.40, EnglishLevels.Average },
            {x=>x > 0.40, EnglishLevels.Bad }
        };
        #endregion

        #region Properties
        public string ProfileName
       {
            get
            {
                return _profileName;
            }
            set
            {
                _profileName = value;
                OnpropertyChanged("ProfileName");
            }
        }
       
       public bool IsValid
       {
           get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                OnpropertyChanged("IsValid");
            }
       }
       public string Summary { get; set; }

        public EnglishLevels ProfileEnglishLevel
        {
            get
            {
                return _englishLevel;
            }
            set
            {
                _englishLevel = value;
                OnpropertyChanged("ProfileEnglishLevel");
            }
        }

        #endregion


        #region Ctor
        public ProfileAnalyzer(string profileName, string summary)
        {   
            Summary = summary;
            ProfileName = profileName;
        }
        #endregion

        #region Methods
        public void CalcEnglishLevelBySummary()
        {

            var englishAnalyze = new EnglishAnalyzer(Summary);
            if (englishAnalyze.AnalyzeSpells())
            {

                double errorPercentage = englishAnalyze.SpellErrors / double.Parse(getWordCount().ToString());

                ProfileEnglishLevel = getEnglishLevel(errorPercentage);
                IsValid = true;
            }
            else
                IsValid = false;


        }

        private EnglishLevels getEnglishLevel(double percentage)
        {
            return _englishLevels.First(x => x.Key(percentage)).Value;
        }
            
        private int getWordCount()
        {
            return Summary.Split(' ').Length -1;
        }

        #endregion

    }
}
