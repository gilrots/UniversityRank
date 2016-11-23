

namespace LinkedInChecker.Analyze
{
    /// <summary>
    /// gives a service analyzer for engiish texts.
    /// </summary>
    public class EnglishAnalyzer
    {
        #region DataMembers
        private string _txt;

        private int _spellErrors;
        private SpellCheckerService _spellChecker;

        #endregion

        #region Properties
        public int SpellErrors
        {
            get
            {
                return _spellErrors;
            }
        }
        #endregion

        #region Ctor
        public EnglishAnalyzer(string txt)
        {
            _spellChecker = new SpellCheckerService();
            _txt = txt;
        }

        #endregion

        #region Methods
        public bool AnalyzeSpells()
        {
            if (_spellChecker.MakeRequest(_txt))
            {
                _spellErrors = _spellChecker.response_error;
                return true;
            }
            return false;
        }
        #endregion

    }
}
