using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Word
    {
        static LanguageCollection languages = new LanguageCollection();
        public string Name { get; set; }

        static public Dictionary<Language, bool> knownTranslation = new Dictionary<Language, bool>();

        public void initTranslation(Language nativeLang)
        {
            var ie = languages.GetEnumerator();
            while (ie.MoveNext())
            {
                Language lang = (Language)ie.Current;
                if (lang == nativeLang)
                    knownTranslation[(Language)ie.Current] = true;
            }
            ie.Reset();
        }

        public void setDefaultTranslation()
        {
        }
        public Dictionary<Language, bool> getInfo()
        {
            return knownTranslation;
        }

        public void addTranslation(Language lang)
        {
            knownTranslation[lang] = true;
        }
    }
}
