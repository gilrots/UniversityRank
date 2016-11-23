using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInChecker
{
    public interface IDataParser
    {
        void Parse(string[] strRowData);
    }
}
