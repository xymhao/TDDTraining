using System;
using System.Collections.Generic;
using System.Linq;

namespace Args
{
    public class StringListParse : ObjectParse
    {
        public StringListParse(SchemaInfo schemaInfo, string[] argsArray, string flag) : base(schemaInfo, argsArray, flag)
        {
        }

        public override object GetValue()
        {
            ValidateType();

            if (!Exist) return SchemaInfo.DefaultValue;
            try
            {
                var result = Value.ToString().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                return result;
            }
            catch
            {
                throw ParseArgumentException();
            }
        }

        protected override void ValidateType()
        {
            if (SchemaInfo.ArgsType != typeof(List<string>))
            {
                throw new ArgumentException("StringListParse:缺省值设置默认类型不是List<string>类型");
            }
        }
    }
}
