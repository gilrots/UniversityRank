using LinkedInChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker
{
    public class Experience : Entity, IDataParser
    {
        public DateTime StartFrom { get; set; }
        public DateTime StartTo { get; set; }
        public string JobTitle { get; set; }
        public string Place { get; set; }

        public void Parse(string[] strRowData)
        {
            StartFrom = new DateTime(int.Parse(strRowData[0].Split('.')[1]), int.Parse(strRowData[0].Split('.')[0]),1);
            StartTo = new DateTime(int.Parse(strRowData[1].Split('.')[1]), int.Parse(strRowData[1].Split('.')[0]), 1);
            JobTitle = strRowData[2];
            Place = strRowData[3];  
        }
    }
}
