using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bd.vienkiemsoat.web.Share
{
    public static class Extension
    {
        public static bool CompareText(this string soure, string strCompare)
        {
            soure = soure ?? "";
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase;
            soure = RemoveSign4VietnameseString(soure);
            strCompare = RemoveSign4VietnameseString(strCompare);
            if (soure.IndexOf(strCompare, stringComparison) >= 0)
            {
                return true;
            }
            return false;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        public static string RemoveSign4VietnameseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static bool ContainsWithNull(this string str, string compareStr)
        {
            if (str == null)
                return str == compareStr;

            return str.Contains(compareStr);
        }

        public static bool EqualsWithIgnoreCase(this string value, string compareValue)
        {
            value = value ?? "";
            compareValue = compareValue ?? "";
            string normalized1 = Regex.Replace(value, @"\s", "");
            string normalized2 = Regex.Replace(compareValue, @"\s", "");
            return string.Equals(normalized1, normalized2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
