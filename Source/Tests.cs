using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimworldTestingSuite
{
    /// <summary>
    /// Static class containing tests from the Rimworld Testing Suite.
    /// </summary>
    public static class Tests
    {
        private static Dictionary<LogMessageType, Action<string>> Console = new Dictionary<LogMessageType, Action<string>>()
        {
            { LogMessageType.Message, (string s) => Log.Message(s) },
            { LogMessageType.Warning, (string s) => Log.Warning(s) },
            { LogMessageType.Error,   (string s) => Log.Error(s)   }
        };
        /// <summary>
        /// When supplied an assertion and an operand, prints a message describing whether the assertion is true for that operand,
        /// of the type <see cref="LogMessageType.Message"/> if true or <c>level</c> if false.
        /// </summary>
        /// <typeparam name="T">The type of the operand.</typeparam>
        /// <param name="operand">The object the assertion is tested on.</param>
        /// <param name="assertion">A function which takes the operand and outputs <c>true</c> or <c>false</c>.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool Assert<T>(T operand, Func<T, bool> assertion, LogMessageType level = LogMessageType.Warning)
        {
            bool result = assertion(operand);
            // TODO: use attribute name
            if(result)
            {
                Log.Message("Success!");
            } 
            else
            {
                Console[level]("Failure!");
            }
            return result;
        }
        /// <summary>
        /// Asserts that a boolean value should be true. Best used to readably encapsulate simple assertions.
        /// </summary>
        /// <param name="assertion">The value to compare.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertTrue(bool assertion, LogMessageType level = LogMessageType.Warning)
            => Assert(assertion, (bool b) => assertion == true, level);
        /// <summary>
        /// Asserts that a boolean value should be false. Best used to readably encapsulate simple assertions.
        /// </summary>
        /// <param name="assertion">The value to compare.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertFalse(bool assertion, LogMessageType level = LogMessageType.Warning)
            => Assert(assertion, (bool b) => assertion == false, level);
        /// <summary>
        /// Asserts that a given <c>operand</c> is equal to a given <c>target</c>.
        /// </summary>
        /// <param name="operand">The object to compare.</param>
        /// <param name="target">The object to compare to.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertEqual(object operand, object target, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o == target, level);
        /// <summary>
        /// Asserts that a given <c>operand</c> is <em>not</em> equal to a given <c>target</c>.
        /// </summary>
        /// <param name="operand">The object to compare.</param>
        /// <param name="target">The object to compare to.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertNotEqual(object operand, object target, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o != target, level);
        /// <summary>
        /// Asserts that a given <c>operand</c> is <c>null</c>.
        /// </summary>
        /// <param name="operand">The object to compare.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertNull(object operand, LogMessageType level = LogMessageType.Warning)
            => Assert(operand, (object o) => o is null, level);
        /// <summary>
        /// Asserts that a given <c>operand</c> is <em>not</em> <c>null</c>.
        /// </summary>
        /// <param name="operand">The object to compare.</param>
        /// <param name="level">The level of message for the debug console to send when the assertion is false (default: <see cref="LogMessageType.Warning"/>).</param>
        public static bool AssertNonNull(object operand, LogMessageType level = LogMessageType.Warning)
            // i miss C# 9 already ;-;
            => Assert(operand, (object o) => !(o is null), level);
    }
}
