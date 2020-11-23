using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Word: Displayed
    {
        static LanguageCollection languages = new LanguageCollection();
        public string Name { get; set; }

        private Dictionary<Language, bool> knownTranslation = new Dictionary<Language, bool>();

        public void AddTranslation(Language targetLang)
        {
            knownTranslation[targetLang] = true;
        }

        public void SetDefault()
        {
            foreach (Language lang in languages)
            {
                knownTranslation[lang] = false;
            }
        }

        public override void Display()
        {
            Console.WriteLine(this.Name);
            foreach (var kv in knownTranslation)
            {
                Console.WriteLine("{0} : {1}", kv.Key.Name, kv.Value);
            }
            Console.WriteLine();

        }


    }
}
