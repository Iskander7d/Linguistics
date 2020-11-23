using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Nationality
    {
        private string ethnic;
        public string Ethnic
        {
            get { return ethnic; }
            set { ethnic = value; }
        }

        private string primaryLanguageGroup;
    }

    class Asian : Nationality
    {
        private string ethnic = "asian";

        private string primaryLanguageGroup = "amorphous";
    }


}
