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
            string[] argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
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
            string[] argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
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
            string[] argsArray = ArgsTests.InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("d");
            ObjectParse parse = new IntParse(info, argsArray, "p");
            Assert.Throws<ArgumentException>(() => parse.GetValue(), "缺省值设置默认类型不是int类型");
        }
    }
}
