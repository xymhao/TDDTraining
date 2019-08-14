using System;
using System.Collections.Generic;
using Args;
using NUnit.Framework;

namespace ArgsTest
{
    /// <summary>
    /// -l -p 8080 -d /usr/logs
    /// -l 如果传入了“-l”就为True，否则为False。
    /// p（port，端口号）标记的值是整数型。
    /// d（directory，目录）标记的值是字符串型。
    /// 
    /// </summary>
    [TestFixture]
    public class ArgsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(true, "l")]
        [TestCase(8080, "p")]
        [TestCase("/usr/logs", "d")]
        public void Should_Return_Value_Whern_Input_Args(object expectedVal, string key)
        {

            string argsText = "-l -p 8080 -d /usr/logs";
            string schemaText = "l:bool p:int d:string";

            var argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.根据argsValues, argsSchema获取value
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase("", "d")]
        public void Should_Return_Value_Whern_Input_lp(object expectedVal, string key)
        {
            string argsText = "-l -p";
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.根据argsValues, argsSchema获取value
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase(false, "l")]
        public void Should_Return_Value_Whern_Input_WithOut_l(object expectedVal, string key)
        {

            string argsText = "-p";
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.根据argsValues, argsSchema获取value
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase("-l -p asd -d /usr/logs")]
        [TestCase("-l -p -d /usr/logs")]
        public void Should_Return_Exception_Whern_Input_IntArgs_Error(string argsText)
        {
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.根据argsValues, argsSchema获取value
            var args = new Args.Args(argsArray, argsSchema);
            Assert.Throws<ArgumentException>(() =>  args.GetValue("p"), "-p:不是有效的int类型！");
        }

        [Test]
        public void Should_Return_IEnumerable_Whern_Input_StringList()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            ArgsParser argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            var args = new Args.Args(argsArray, argsSchema);
            var expectValue = new List<string>() {"this", "is", "a", "list"};
            Assert.AreEqual(expectValue, args.GetValue("g"));
        }


        [Test]
        public void Should_Return_IEnumerable_Whern_Input_d()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            ArgsParser argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            var args = new Args.Args(argsArray, argsSchema);
            var expectValue = new List<int>() {1, 2, -3, 5};
            Assert.AreEqual(expectValue, args.GetValue("d"));
        }

        public static ArgsParser InitArgsParam(string argsText, string schemaText, out ArgsSchema argsSchema)
        {
            //1.把命令行字符串拆分成main函数可用的字符串数组
            var argsArray = new ArgsParser(argsText);
            Assert.IsNotNull(argsArray);

            //2. 把字符串形式的Schema解析成对象
            argsSchema = new ArgsSchema(schemaText);
            Assert.IsNotNull(argsSchema);
            return argsArray;
        }
    }
}