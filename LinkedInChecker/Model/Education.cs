using LinkedInChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker
{
    public class Education : Entity, IDataParser
    {
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string School { get; set; }
        public DegreeTypes DegreeType { get; set; }
        public string FieldOfStudy { get; set; }

        public void Parse(string[] strRowData)
        {
            YearFrom = int.Parse(strRowData[0]);
            YearTo = int.Parse(strRowData[1]);
            School = strRowData[2];
            DegreeType = (DegreeTypes)int.Parse(strRowData[3]);
            FieldOfStudy = strRowData[4];
        }
    }
}
