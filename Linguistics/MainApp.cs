using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Language l = new Language();
            l.Id = 1;
            l.Name = "Russian";
            l.printInfo();
        }
    }
}
