using LinkedInChecker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker
{
    public class Profile : Entity, IDataParser
    {
        public string Name { get; set; }
        public string CurrentTitle { get; set; }
        public string CurrentPosition { get; set; }
        public string Summary { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Experience> WorkExcperience { get; set; }
        public List<Education> Educations { get; set; }

        public void Parse(string[] strRowData)
        {
            Id = long.Parse(strRowData[0]);
            Name = strRowData[1];
            CurrentTitle = strRowData[2];
            CurrentPosition = strRowData[3];
            Summary = strRowData[4];

            Skills = EntityFactory<Skill>.GetEntityList(strRowData[5].Split(Global.SECONDLEVEL));

            WorkExcperience = EntityFactory<Experience>.GetEntityList(strRowData[6].Split(Global.SECONDLEVEL));

            Educations = EntityFactory<Education>.GetEntityList(strRowData[7].Split(Global.SECONDLEVEL));

            var creationDate = strRowData[8].Split('.');
            CreateTime = new DateTime(int.Parse(creationDate[2]), int.Parse(creationDate[1]), int.Parse(creationDate[0])); 

        }
    }
}
