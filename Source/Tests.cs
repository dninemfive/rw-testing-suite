using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldTestingSuite
{
    public static class Tests
    {
        private static Dictionary<LogMessageType, Action<string>> Console = new Dictionary<LogMessageType, Action<string>>()
        {
            { LogMessageType.Message, (string s) => Log.Message(s) },
            { LogMessageType.Warning, (string s) => Log.Warning(s) },
            { LogMessageType.Error,   (string s) => Log.Error(s)   }
        };
        public static void Assert<T>(T operand, Func<T, bool> assertion, LogMessageType level = LogMessageType.Warning)
        {
            bool result = assertion(operand);
            // TODO: use attribute name
            string resultDescription = result ? $"Assertion successful" : "Assertion failed";
            Console[level](resultDescription);
        }
        public static void AssertTrue(bool assertion, LogMessageType level = LogMessageType.Warning)
            => Assert(assertion, (bool b) => assertion == true, level);
        public static void AssertFalse(bool assertion, LogMessageType level = LogMessageType.Warning)
            => Assert(assertion, (bool b) => assertion == false, level);
        public static void AssertEqual(object operand, object target, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o == target, level);
        public static void AssertNotEqual(object operand, object target, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o != target, level);
        public static void AssertNull(object operand, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o is null, level);
        public static void AssertNonNull(object operand, LogMessageType level = LogMessageType.Warning)
            // i miss C# 9 already ;-;
            => Assert(operand, (object o) => !(o is null), level);
    }
}
