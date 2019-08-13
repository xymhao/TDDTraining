using System;
using System.Collections.Generic;
using Args;
using NUnit.Framework;

namespace ArgsTest
{
    /// <summary>
    /// -l -p 8080 -d /usr/logs
    /// -l ��������ˡ�-l����ΪTrue������ΪFalse��
    /// p��port���˿ںţ���ǵ�ֵ�������͡�
    /// d��directory��Ŀ¼����ǵ�ֵ���ַ����͡�
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

            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.����argsValues, argsSchema��ȡvalue
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase("", "d")]
        public void Should_Return_Value_Whern_Input_lp(object expectedVal, string key)
        {
            string argsText = "-l -p";
            string schemaText = "l:bool p:int d:string";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.����argsValues, argsSchema��ȡvalue
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase(false, "l")]
        public void Should_Return_Value_Whern_Input_WithOut_l(object expectedVal, string key)
        {

            string argsText = "-p";
            string schemaText = "l:bool p:int d:string";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.����argsValues, argsSchema��ȡvalue
            var args = new Args.Args(argsArray, argsSchema);
            Assert.AreEqual(expectedVal, args.GetValue(key));
        }

        [TestCase("-l -p asd -d /usr/logs")]
        [TestCase("-l -p -d /usr/logs")]
        public void Should_Return_Exception_Whern_Input_IntArgs_Error(string argsText)
        {
            string schemaText = "l:bool p:int d:string";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);

            //3.����argsValues, argsSchema��ȡvalue
            var args = new Args.Args(argsArray, argsSchema);
            Assert.Throws<ArgumentException>(() =>  args.GetValue("p"), "-p:������Ч��int���ͣ�");
        }

        [Test]
        public void Should_Return_IEnumerable_Whern_Input_StringList()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            var args = new Args.Args(argsArray, argsSchema);
            var expectValue = new List<string>() {"this", "is", "a", "list"};
            Assert.AreEqual(expectValue, args.GetValue("g"));
        }


        [Test]
        public void Should_Return_IEnumerable_Whern_Input_d()
        {
            string argsText = "-g this,is,a,list -d 1,2,-3,5";
            string schemaText = "g:List<string> d:List<int>";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            var args = new Args.Args(argsArray, argsSchema);
            var expectValue = new List<int>() {1, 2, -3, 5};
            Assert.AreEqual(expectValue, args.GetValue("d"));
        }

        [Test]
        public void Should_Return_True_Whern()
        {
            string argsText = "-l -p asd -d /usr/logs";
            string schemaText = "l:bool p:int d:string";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
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
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("l");
            ObjectParse parse = new BoolParse(info, argsArray, "l");
            Assert.AreEqual(expectValue, parse.GetValue());
        }

        [TestCase("-l asd -p asd -d /usr/logs")]
        public void Should_Return_Exception_Whern_Input_ErrorBool(string argsText)
        {
            string schemaText = "l:bool p:int d:string";
            string[] argsArray = InitArgsParam(argsText, schemaText, out ArgsSchema argsSchema);
            SchemaInfo info = argsSchema.GetSchemaInfo("l");
            ObjectParse parse = new BoolParse(info, argsArray, "l");
            Assert.Throws<ArgumentException>(() => parse.GetValue(), "-p:������Ч��bool���ͣ�");
        }
        public static string[] InitArgsParam(string argsText, string schemaText, out ArgsSchema argsSchema)
        {
            //1.���������ַ�����ֳ�main�������õ��ַ�������
            var argsArray = ArgsParser.Parser(argsText);
            Assert.Positive(argsArray.Length);

            //2. ���ַ�����ʽ��Schema�����ɶ���
            argsSchema = new ArgsSchema(schemaText);
            Assert.IsNotNull(argsSchema);
            return argsArray;
        }
    }
}