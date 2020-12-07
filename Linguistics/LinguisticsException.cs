using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class LinguisticsException : Exception
    {
        private static string baseException = "Unkown exception";

        public LinguisticsException() : base(baseException)
        {

        }

        public LinguisticsException(string invalidUserInput) : base($"Invalid user input: {invalidUserInput}")
        {

        }

        public LinguisticsException(string invalidUserInput, LanguageCollection langs) : base($"Invalid user input: {invalidUserInput}")
        {
            Console.WriteLine("Possible lanuages to learn: ");
            foreach(Language l in langs)
            {
                Console.WriteLine(l.Name);
            }
        }
    }
}
