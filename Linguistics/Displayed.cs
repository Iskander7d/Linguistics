using System;
using System.Collections.Generic;
using System.Text;

namespace Linguistics
{
    class Displayed
    {
        public virtual void Display()
        {
        }
    }

    interface IDisplayed<out T>
    {
        T Display();
    }
}
