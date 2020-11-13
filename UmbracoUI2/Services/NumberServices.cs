using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoDI2.Services
{
    public class NumberServices:INumber
    {
        public int GetNumber()
        {
            return 10000;
        }

    }
}