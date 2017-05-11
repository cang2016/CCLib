using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class StringHelper
    {
        /// <summary>
        /// 替换单引号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSingleQuotation(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.Replace("'", "''");
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 看是否含有汉字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsHZ(string str)
        {
            Regex rx = new Regex("^[\u4e00-\u9fa5]$"); //是否含有汉字
            char[] s = str.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (rx.IsMatch(s[i].ToString()))
                    return true;
            }
            return false;
        }
    }
}
