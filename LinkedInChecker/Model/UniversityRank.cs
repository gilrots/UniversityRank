using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker.Model
{
    public class UniversityRank : IDataParser
    {
        public string University { get; set; }
        public int    Rank { get; set; }

        public void Parse(string[] strRowData)
        {
            University = strRowData[0];
            Rank = int.Parse(strRowData[1]);
        }
    }
}
