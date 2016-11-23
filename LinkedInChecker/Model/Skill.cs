using LinkedInChecker.Model;
using System.Collections.Generic;

namespace LinkedInChecker
{
    public class Skill : Entity, IDataParser
    {
        public string Title { get; set; }
        private string _description { get; set; }

        public void Parse(string[] strRowData)
        {
            Title = strRowData[0];
        }

        public static List<Skill> GetSkillsList(string[] strRowData)
        {
            var skills = new List<Skill>();
            foreach (var currItem in strRowData)
            {
                var s = new Skill();
                s.Parse(currItem.Split(' '));
                skills.Add(s);
            }

            return skills;
        }
    }
}
