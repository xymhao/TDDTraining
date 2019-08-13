using System;

namespace Args
{
    public class StringParse : ObjectParse
    {
        public StringParse(SchemaInfo schemaInfo, string[] argsArray, string flag) : base(schemaInfo, argsArray, flag)
        {
        }

        public override object GetValue()
        {
            ValidateType();
            return Exist ? Value : SchemaInfo.DefaultValue;
        }

        protected override void ValidateType()
        {
            if (SchemaInfo.ArgsType != typeof(string))
            {
                throw new ArgumentException("StringParse:缺省值设置默认类型不是string类型");

            }
        }
    }
}
