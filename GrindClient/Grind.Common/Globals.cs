using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grind.Common
{
    public class Globals
    {
        public static RootObject rootObject;
        public static List<Person> People;
        public Globals()
        {
            People = new List<Person>();
        }
    }
}
