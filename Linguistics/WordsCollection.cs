using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class WordsCollection : System.Collections.IEnumerable
    {
        Word[] _words =
        {
            new Word { Name = "Home"},
            new Word { Name = "World"},
            new Word { Name = "Life"},
            new Word { Name = "Family"},
            new Word { Name = "Love"},
        };

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new WordsEnumerator(_words);
        }

        private class WordsEnumerator : System.Collections.IEnumerator
        {
            private Word[] _words;
            private int _position = -1;

            public WordsEnumerator(Word[] words)
            {
                _words = words;
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return _words[_position];
                }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                _position++;
                return (_position < _words.Length);
            }

            void System.Collections.IEnumerator.Reset()
            {
                _position = -1;
            }
        }
    }
}
