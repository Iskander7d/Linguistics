using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Language : Displayed
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public bool IsLearned { get; set; }

        public int LearnProgress { get; set; }

        public override void Display()
        {
            Console.WriteLine("Language: {0}; Level: {1}; IsLearned: {2}\n", Name, Level, IsLearned);
        }

    }

    class Amorphous : Language
    {
        public override void Display()
        {
            base.Display();
            //Console.WriteLine("language's word is complex of simple words." +
                //"\nWords constst of root only.\n");
        }
    }

    class Agglutinative : Language
    {
        public override void Display()
        {
            base.Display();
            //Console.WriteLine("Words are constructed from affixes, suffixes," +
                //"and so on, which allows" +
               // "for a variety of grammatical meanings.\n" +
                //"A long sentence may consist of 2-3 words.\n");
        }
    }

    class Fusional : Language
    {
        public override void Display()
        {
            base.Display();
           // Console.WriteLine("Words in such languages are usually shorter than in agglutinating" +
               // "languages, but longer than in isolating languages.\n" +
              //  "Morphemes in such languages can Express several grammatical meanings at once.\n");
        }
    }

    class Alternating : Fusional
    {
        public override void Display()
        {
            base.Display();
           // Console.WriteLine("It is a subtype of inflectional languages." +
             //   "the inflection here is \"intertwined\" with\n" +
             //   "the root, which has only a semantic meaning.\n" +
             //   "All grammatical meanings are expressed by vowels and their combinations.\n");
        }
    }
}
