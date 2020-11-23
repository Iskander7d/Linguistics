using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    public class LanguageCollection : System.Collections.IEnumerable
    {
        Language[] _languages =
        {
            new Amorphous       { Name = "Chinese", Level = 1},
            new Amorphous       { Name = "Vietnamese", Level = 1},
            new Amorphous       { Name = "Thai", Level = 1},
            new Agglutinative   { Name = "Turkish", Level = 2},
            new Agglutinative   { Name = "Kazakh", Level = 2},
            new Agglutinative   { Name = "Japanese", Level = 2},
            new Fusional        { Name = "Russian", Level = 3},
            new Fusional        { Name = "English", Level = 3},
            new Fusional        { Name = "German", Level = 3},
            new Alternating     { Name = "Arabic", Level = 3},
            new Alternating     { Name = "Hebrew", Level = 3},
            new Alternating     { Name = "Amharic", Level = 3},
        };

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new LanguageEnumerator(_languages);

        }

        private class LanguageEnumerator : System.Collections.IEnumerator
        {
            private Language[] _languages;
            private int _position = -1;

            public LanguageEnumerator(Language[] languages)
            {
                _languages = languages;
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return _languages[_position];
                }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _position++;
                return (_position < _languages.Length);
            }

            void System.Collections.IEnumerator.Reset()
            {
                _position = -1;
            }
        }
    }
}
