using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimworldTestingSuite
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        public string Name { get; private set; }
        public TestAttribute(string name)
        {
            Name = name;
        }
    }
}
