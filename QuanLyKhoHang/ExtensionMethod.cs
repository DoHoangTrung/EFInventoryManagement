using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public static class ExtensionMethod
    {
        public static string Format(this string text)
        {
            //removeSpace
            text = text.Trim();
            text = Regex.Replace(text, @"\s+", " ");
            //lowercase and remove accents

            StringBuilder result = new StringBuilder();
            var arrayText = text.ToLower().Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char c in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString().Normalize(NormalizationForm.FormC);
        }
        public static string RemoveSpace(this string text)
        {
            text = text.Trim();
            text = Regex.Replace(text, @"\s+", " ");
            return text;
        }
        public static string LowerCaseAndRemoveAccents(this string text)
        { 
            StringBuilder s = new StringBuilder();
            var arrayText = text.ToLower().Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char c in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    s.Append(c);
                }
            }

            return s.ToString().Normalize(NormalizationForm.FormC);
        }

        public static int ToInt(this int? number)
        {
            int result = number ?? default(int);
            return result;
        }
    }
}
