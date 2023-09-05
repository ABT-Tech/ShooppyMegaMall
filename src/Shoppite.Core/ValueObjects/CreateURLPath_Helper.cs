using System;
using System.Collections.Generic;
using System.Text;

namespace Shoppite.Core.ValueObjects
{
    public class CreateURLPath_Helper
    {
        public string createurlpath(string value)
        {
            string returnpath = System.Text.RegularExpressions.Regex.Replace(value, @"(\s+|\.|\,|\:|\*|&|\?|\/)", "-").Replace("%", "").Replace("#", "").Replace("~", "").Replace("!", "").Replace("@", "").Replace("$", "").Replace("+", "-");

            return returnpath;
        }
    }
}
