using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldTestingSuite
{
    // TODO: way to have tests run at other times (e.g. on main menu display, in-game)
    [StaticConstructorOnStartup]
    static class Bootstrapper
    {
        static Bootstrapper()
        {
            // foreach method with TestAttribute,
            //  print "{type TestAttribute name ?? type name}.{method TestAttribute name} tests:"
            //  run method (should be IEnumerable<bool>)
            //  print number of successful tests out of number of total tests
        }
    }
}
