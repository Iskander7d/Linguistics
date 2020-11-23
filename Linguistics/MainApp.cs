using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class MainApp
    {
        static LanguageCollection languages = new LanguageCollection();
        static WordsCollection words = new WordsCollection();
        static void Main(string[] args)
        {
            var name = "John";
            var langObj = getNativeLang("English");
            Linguist linguist = new Linguist(langObj, name);
            linguist.GetInfo<Language>(langObj);

            var ie = words.GetEnumerator();
            while (ie.MoveNext())
            {
                Word word = (Word)ie.Current;
                word.SetDefault();
                linguist.GetInfo<Word>(word);
            }
            
            /*
            Console.Write("Type lingust's name: ");
            var name = Console.ReadLine();

            Language nativeLangObj;
            while (true)
            {
                Console.Write("Choose native language: ");
                var nativeLanguage = Console.ReadLine();
                var langObj = getNativeLang(nativeLanguage);
                if (langObj == null)
                {
                    Console.WriteLine("Incorrect language, try again.\n");
                    continue;
                }
                else
                {
                    nativeLangObj = langObj;
                    Linguist linguist = new Linguist(langObj, name);
                    linguist.Display();
                    break;
                }
            }
            */
        }

        static public Language getNativeLang(string nativeLang)
        {
            foreach (Language lang in languages)
            {
                
                if (lang.Name == nativeLang)
                    return lang;
            }

            return null;
        }
    }
}
