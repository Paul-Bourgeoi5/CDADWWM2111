using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CallFunctionsFromOtherProject
{
    class StringVsStringBuilder
    {
        public static string WithStringBuilder()
        {
            
            string word = "a";
            StringBuilder sentence = new();
            for (int i = 0; i < 100000; i++)
            {
                sentence.Append(word);
            }
            return sentence.ToString();
        }
        public static string WithoutStringBuilder()
        {
            string word = "a";
            string sentence = "";
            for (int i = 0; i < 100000; i++)
            {
                sentence += word;
            }
            return sentence;
        }
    }
}
