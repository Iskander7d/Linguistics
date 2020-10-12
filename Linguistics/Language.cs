using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Language
    {
        private UInt64 id;
        public UInt64 Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool root, particle, ending;

        public void printInfo()
        {
            Console.WriteLine("ID: {0}\nName: {1}", id, name);
        }

    }

}
