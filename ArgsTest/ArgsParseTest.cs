using System;
using System.Collections.Generic;
using System.Text;
using Args;
using NUnit.Framework;

namespace ArgsTest
{
    [TestFixture]
    public class ArgsParseTest
    {
        [TestCase("l", "true")]
        [TestCase("p", "8080")]
        [TestCase("d", "/usr/logs")]
        public void Should_Parse_Param_When(string flag, string expect) 
        {
            var argsText = "-l true -p 8080 -d /usr/logs";
            var argsParse = new ArgsParser(argsText);
            Assert.AreEqual(expect, argsParse.GetValue(flag, out bool exist));
            Assert.IsTrue(exist);
        }

        [Test]
        public void Should_Parse_Param_When_No_Value()
        {
            var argsText = "-l -p 8080 -d /usr/logs";
            var argsParse = new ArgsParser(argsText);
            Assert.IsNull( argsParse.GetValue("l", out bool exist));
            Assert.True(exist);
        }

        [Test]
        public void Should_Parse_Param_When_Input__Negative_Number()
        {
            var argsText = "-l -p -9 -d /usr/logs";
            var argsParse = new ArgsParser(argsText);
            Assert.AreEqual("-9",argsParse.GetValue("p", out bool existP));
            Assert.IsTrue(existP);
            Assert.AreEqual("/usr/logs", argsParse.GetValue("d", out bool existD));
            Assert.IsTrue(existD);

        }

    }
}
