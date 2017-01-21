using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TxtCrawler.Helper
{
    public static class StringExtension
    {
        public static string RemovebNbT(this string text)
        {
            text = Regex.Replace(text, @"\\n|\\t", "");
            return text;
        }
    }
}
