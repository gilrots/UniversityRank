using System;


namespace LinkedInChecker
{
    /// <summary>
    /// This class allows to filter in Text, ignoring UpperLowerCase
    /// </summary>
    public static class EntityFilter 
    {
        public static bool FilterText(string text, string filter)
        {
            return text.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
