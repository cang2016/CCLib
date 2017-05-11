using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;
using System.Collections.ObjectModel;

namespace Common
{
    public class ConvertToPinYin
    {
        public static string ToPinyin(string simpleChinese)
        {
            char[] ch = simpleChinese.ToArray();
            string pinyinString = string.Empty;

            foreach (char c in ch)
            {
                if (ChineseChar.IsValidChar(c))
                {
                    ChineseChar chineseChar = new ChineseChar(c);
                    ReadOnlyCollection<string> pinyin = chineseChar.Pinyins;
                    pinyinString += (pinyin[0].Substring(0, pinyin[0].Length - 1));
                }
                else
                {
                    pinyinString += c.ToString();
                }
            }

            return pinyinString.ToLower();
        }
    }
}
