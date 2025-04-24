using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string TextAr, string TextEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if(culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return TextAr;
            return TextEn;
        }
    }
}
