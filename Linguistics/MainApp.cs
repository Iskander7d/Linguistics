using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Linguistics
{
    class MainApp
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your name: ");
                var name = Console.ReadLine();
                if (name == "")
                {
                    throw new LinguisticsException("name");
                }

                Console.Write("Enter your native language: ");
                var langObj = Utils.getLanguage(Console.ReadLine());
                if (langObj == null)
                {
                    LanguageCollection langs = new LanguageCollection();
                    throw new LinguisticsException("null lang object", langs);
                }

                Linguist linguist = new Linguist(langObj, name);

                Logger logger = new Logger();
                linguist.Notify += logger.LoggingNotify;

                linguist.learnWord("Chinese", "English", "Home");
                linguist.learnWord("Vietnamese", "Chinese", "Home");
                linguist.learnWord("Vietnamese", "Chinese", "World");
                linguist.learnWord("Vietnamese", "Chinese", "Life");
                linguist.learnWord("Vietnamese", "Chinese", "Family");
                linguist.learnWord("Vietnamese", "Chinese", "Love");
                linguist.learnWord("Vietnamese", "Thai", "Home");
                linguist.learnWord("Vietnamese", "Thai", "World");
                linguist.learnWord("Vietnamese", "Thai", "Life");
                linguist.learnWord("Vietnamese", "Thai", "Family");
                linguist.learnWord("Vietnamese", "Thai", "Love");
            }
            catch(LinguisticsException le)
            {
                Console.WriteLine(le.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
