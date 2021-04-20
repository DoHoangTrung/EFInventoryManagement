using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public static class ExtensionMethod
    {
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

            return s.ToString();
        }


    }
}
