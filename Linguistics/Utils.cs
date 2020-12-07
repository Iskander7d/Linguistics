using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Utils
    {
        static public Language getLanguage(string lang)
        {
            LanguageCollection languages = new LanguageCollection();

            foreach (Language l in languages)
            {

                if (l.Name == lang)
                    return l;
            }

            return null;
        }
    }
}
