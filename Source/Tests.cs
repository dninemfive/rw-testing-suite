using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldTestingSuite
{
    public enum AssertionLevel { Message, Warning, Error }
    public static class Tests
    {
        private static Dictionary<AssertionLevel, Action<string>> Console = new Dictionary<AssertionLevel, Action<string>>()
        {
            { AssertionLevel.Message, (string s) => Log.Message(s) },
            { AssertionLevel.Warning, (string s) => Log.Warning(s) },
            { AssertionLevel.Error,   (string s) => Log.Error(s)   }
        };
        public static void Assert<T>(T operand, Func<T, bool> assertion, AssertionLevel level = AssertionLevel.Warning)
        {
            bool result = assertion(operand);
            // TODO: use attribute name
            string resultDescription = result ? $"Assertion successful" : "Assertion failed";
            Console[level](resultDescription);
        }
        public static void AssertTrue(bool assertion, AssertionLevel level = AssertionLevel.Warning)
            => Assert(assertion, (bool b) => assertion == true, level);
        public static void AssertFalse(bool assertion, AssertionLevel level = AssertionLevel.Warning)
            => Assert(assertion, (bool b) => assertion == false, level);
        public static void AssertEqual(object operand, object target, AssertionLevel level = AssertionLevel.Warning)
            => Assert(operand, (object o) => o == target, level);
        public static void AssertNotEqual(object operand, object target, AssertionLevel level = AssertionLevel.Warning)
            => Assert(operand, (object o) => o != target, level);
        public static void AssertNull(object operand, AssertionLevel level = AssertionLevel.Warning)
            => Assert(operand, (object o) => o is null, level);
        public static void AssertNonNull(object operand, AssertionLevel level = AssertionLevel.Warning)
            // i miss C# 9 already ;-;
            => Assert(operand, (object o) => !(o is null), level);
    }
}
