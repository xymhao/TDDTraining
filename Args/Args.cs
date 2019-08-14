using System;
using System.Collections.Generic;

namespace Args
{
    public class Args
    {
        public ArgsParser ArgsParser { get; set; }

        public ArgsSchema ArgsSchema { get; set; }


        public Args(ArgsParser argsParser, ArgsSchema argsSchema)
        {
            ArgsParser = argsParser;
            ArgsSchema = argsSchema;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="flag"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public object GetValue(string flag)
        {
            var schemaInfo = ArgsSchema.GetSchemaInfo(flag);
            var parse = GetParse(schemaInfo, flag);
            return parse.GetValue();
        }

        private ObjectParse GetParse(SchemaInfo schemaInfo, string flag)
        {
            switch (schemaInfo.ArgsType)
            {
                case Type t when t == typeof(bool):
                    return new BoolParse(schemaInfo, ArgsParser, flag);
                case Type t when t == typeof(int):
                    return new IntParse(schemaInfo, ArgsParser, flag);
                case Type t when t == typeof(string):
                    return new StringParse(schemaInfo, ArgsParser, flag);
                case Type t when t == typeof(List<string>):
                    return new StringListParse(schemaInfo, ArgsParser, flag);
                case Type t when t == typeof(List<int>):
                    return  new IntListParse(schemaInfo, ArgsParser, flag);
                default: throw new ArgumentException($"-{flag}:命令无效");
            }
        }
    }
}
