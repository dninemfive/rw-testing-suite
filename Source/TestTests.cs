using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimworldTestingSuite
{
    [Test("Test Tests")]
    public class TestTests
    {
        [Test("Assert")]
        public static IEnumerable<bool> Test()
        {
            yield return Tests.Assert("this should be true", (string s) => s == "this should be true");
        }
    }
}
