using System;
using System.Collections.Generic;

namespace Args
{
    public class SchemaInfo
    {
        public Type ArgsType { get; set; }

        public Object DefaultValue { get; set; }

        public SchemaInfo(string type)
        {
            switch (type)
            {
                case "bool":
                    ArgsType = typeof(bool);
                    DefaultValue = false; break;
                case "string":
                    ArgsType = typeof(string);
                    DefaultValue = string.Empty; break;
                case "int":
                    ArgsType = typeof(int);
                    DefaultValue = 0; break;
                case "List<string>":
                    ArgsType = typeof(List<string>);
                    DefaultValue = new List<string>(); break;
                case "List<int>":
                    ArgsType = typeof(List<int>);
                    DefaultValue = new List<int>(); break;
                default: throw new ArgumentException("类型不存在！");
            }
        }
    }
}