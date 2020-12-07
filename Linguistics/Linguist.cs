using System;
using System.Collections.Generic;
using System.Linq;
/*
Лингвист может читать и переводить слова.
Лингвист имеет начальный уровень (каждая языковая группа - это уровень).
И у каждой языковой группы есть начальный язык, слова в котором доступны для чтения и перевода. Условимся, что это его родной язык.

Поведение Лингвиста внутри языковой группы:
1. Прочитать_слово(язык, слово). Если Лингвист знает этот язык, то как итог, слово будет прочитано (выучено) и готово для перевода.
2. Перевести_слово(язык_1, язык_2, слово). Если Лингвист знает эти 2 языка, то слово на втором языке будет выучено и готово для перевода.
2а. Если язык_1 и язык_2 не из одной группы, то Лингвист должен обладать уровнем таким же, как максимальный из двух языков, или выше.
2б. Если они из одной группы, то Лингвист может их переводить в любом случае.
3. После того, как все слова в языках одной группы будут выучены, то уровень Лингвиста повысится, и он сможет изучать новые слова в следующей языковой группе.

Поведение Лингвиста при изучении новой группы уровня выше:
4. Чтобы изучить слова в начальном языке новой группы, необходимо перевести их на любой известный язык.
5. Изучив новое слово в начальном языке, Лингвист может перевести его на другой язык в новой языковой группе.

Поведение Лингвиста при изучении новой группы уровня ниже:
Допустим, что существует Лингвист с начальный уровнем 2.
Это очень способный Лингвист, и поэтому он может с легкостью переводить слова из своей группы на любой языкк группы 1.
Это не значит, что он уже знает языки группы 1, он все еще может их изучить, но для этого ему не нужно работать с начальным языком.
Для этого ему просто необходимо перевести слово на новый язык.


Общие моменты:
Изучая новую группу уровнем выше, Лингвист должен сначала выучить слово из начальной группы, т.е перевести его (п.4).
Затем он может изучить слово в другом языке новой группы через слово начального языка. Тем самым он будет знать перевод слова на +2 языках.
Условимся, что языковая группы состоит из 3 языков. Для изучения и перевода лингвисту доступны 5 слов.

Увждое слово - это объект класса Word.
Поля класса - id и список языков, на которых Лингвист знает это слово.
 */
namespace Linguistics
{
    class Linguist
    {
        private string name;
        private int level;
        private Language nativeLanguage;
        private string nativeLanguageName;

        private WordsCollection words = new WordsCollection();
        private LanguageCollection languages = new LanguageCollection();

        public delegate void LinguistHandler(string message);
        public event LinguistHandler Notify;

        public Linguist(Language lang, string newName)
        {
            SetDefault();
            name = newName;
            level = lang.Level;
            SetNativeLanguage(lang);
        }

        public void SetDefault()
        {
            foreach (Word w in words)
            {
                w.SetDefault();
            }
        }

        public Language GetNativeLanguage()
        {
            return nativeLanguage;
        }

        private void SetNativeLanguage(Language lang)
        {
            nativeLanguage = lang;
            nativeLanguageName = lang.Name;

            foreach (Language l in languages)
            {
                if (l.Name == lang.Name)
                {
                    l.IsLearned = true;
                }
            }

            foreach (Word w in words)
            {
                w.knownTranslation[lang] = true;
            }
        }

        public void Display()
        {
            Console.WriteLine("Name: {0} \nNative language: {1} \nSkills Level: {2}\n",
                name, nativeLanguageName, level);

            foreach (Language lang in languages)
            {
                GetInfo<Language>(lang);
            }

            foreach (Word w in words)
            {
                Console.WriteLine("{0}:", w.Name);
                foreach (var kt in w.knownTranslation)
                {
                    Console.WriteLine("     {0} - {1}", kt.Key.Name, kt.Value);
                }
            }
        }

        public void DisplayKnownWords()
        {
            foreach (Word w in words)
            {
                Console.WriteLine("{0}:", w.Name);
                foreach (var kt in w.knownTranslation)
                {
                    if (kt.Value)
                    {
                        Console.WriteLine("     {0} - {1}", kt.Key.Name, kt.Value);
                    }
                }
            }
        }

        public void GetInfo<T>(T obj) where T : Displayed
        {
            obj.Display();
        }

        private Language GetLanguage(string langStr)
        {
            foreach (Language lang in languages)
            {
                if (lang.Name == langStr)
                {
                    return lang;
                }
            }

            return null;
        }

        public void learnWord(string baseLangStr, string otherLangStr, string wordToLearn)
        {
            Language baseLang = GetLanguage(baseLangStr);
            Language otherLang = GetLanguage(otherLangStr);
            if (baseLang.IsLearned)
            {
                if (this.level >= otherLang.Level)
                {
                    foreach (Word w in words)
                    {
                        if (w.Name == wordToLearn)
                        {
                            w.knownTranslation[otherLang] = true;
                            Console.WriteLine("{0} has been known on {1}", w.Name, otherLangStr);
                            otherLang.LearnProgress++;

                            string notify = String.Format("word '{0}' on {1} learned by {2}", w.Name, otherLangStr, this.name);
                            Notify?.Invoke(notify);
                        }
                    }
                    CheckLanguageLearn(otherLang);
                }
                else
                {
                    Console.WriteLine("not enough skill");

                    string notify = String.Format("Failed attempt: word {0} was not learned", wordToLearn);
                    Notify?.Invoke(notify);
                }
            }
            else
            {
                Console.WriteLine("Base language is not learned");

                string notify = String.Format("Failed attempt: in learn word '{0}' from {1} to {2}", wordToLearn, baseLangStr, otherLangStr);
                Notify?.Invoke(notify);
            }
        }

        private void CheckLanguageLearn(Language lang)
        {
            if (lang.LearnProgress == 5)
            {
                lang.IsLearned = true;
                Console.WriteLine("{0} has just been known!", lang.Name);

                string notify = String.Format("Language {0} learned by {1}", lang.Name, this.name);
                Notify?.Invoke(notify);
            }

            CheckLvlUp();
        }

        private void CheckLvlUp()
        {
            int lvlProgress = 0;
            foreach (Language lang in languages)
            {
                if (lang.Level == this.level && lang.IsLearned)
                {
                    lvlProgress++;
                }
            }
            
            if (lvlProgress == 3)
            {
                level++;
                Console.WriteLine("LVLUP! level is {0}", this.level);

                string notify = String.Format("{0}'s level is up: {1}", this.name, this.level);
                Notify?.Invoke(notify);
            }
        }

    }
}
