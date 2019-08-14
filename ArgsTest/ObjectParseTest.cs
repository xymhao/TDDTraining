using System;
using System.Collections.Generic;
using Args;
using NUnit.Framework;

namespace ArgsTest
{
    public class ObjectParseTest
    {
        [Test]
        public void Should_Return_StringList_Whern_Input_Param()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("g");
            ObjectParse parse = new StringListParse(info, argsArray, "g");
            var expectValue = new List<string>() { "this", "is", "a", "list" };
            Assert.AreEqual(expectValue, parse.GetValue());
        }

        [Test]
        public void Should_Return_IntList_Whern_Input_Param()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("d");
            ObjectParse parse = new IntListParse(info, argsArray, "d");
            List<int> expectValue = new List<int>() { 1, 2, -3, 5 };
            Assert.AreEqual(expectValue, parse.GetValue());
        }

        [Test]
        public void Should_Return_Error_Whern_InitParse_By_StringSchema()
        {
            string argsText = "-l -p 8080 -d /usr/logs";
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("d");
            ObjectParse parse = new IntParse(info, argsArray, "p");
            Assert.Throws<ArgumentException>(() => parse.GetValue(), "缺省值设置默认类型不是int类型");
        }


        [Test]
        public void Should_Return_True_Whern()
        {
            string argsText = "-l -p asd -d /usr/logs";
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("l");
            ObjectParse parse = new BoolParse(info, argsArray, "l");
            Assert.AreEqual(true, parse.GetValue());
        }

        [TestCase(true, "-l -p asd -d /usr/logs")]
        [TestCase(false, "-p asd -d /usr/logs")]
        [TestCase(false, "-l false -p asd -d /usr/logs")]
        [TestCase(true, "-l true -p asd -d /usr/logs")]
        public void Should_Return_True_Whern_Input_Param(bool expectValue, string argsText)
        {
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("l");
            ObjectParse parse = new BoolParse(info, argsArray, "l");
            Assert.AreEqual(expectValue, parse.GetValue());
        }

        [TestCase("-l asd -p asd -d /usr/logs")]
        public void Should_Return_Exception_Whern_Input_ErrorBool(string argsText)
        {
            string schemaText = "l:bool p:int d:string";
            ArgsParser argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("l");
            ObjectParse parse = new BoolParse(info, argsArray, "l");
            Assert.Throws<ArgumentException>(() => parse.GetValue(), "-p:不是有效的bool类型！");
        }
    }
}
