using System;

namespace Args
{
    public class BoolParse : ObjectParse
    {
        public BoolParse(SchemaInfo schemaInfo, ArgsParser argsParser, string flag) : base(schemaInfo, argsParser, flag)
        {
        }

        public override object GetValue()
        {
            ValidateType();

            if (Exist && IsNullValue())
            {
                return true;
            }

            // ReSharper disable once InvertIf
            if (Exist)
            {
                if (bool.TryParse(Value, out bool boolValue))
                    return boolValue;
                throw ParseArgumentException();
            }

            return SchemaInfo.DefaultValue;
        }

        protected override void ValidateType()
        {
            if (SchemaInfo.ArgsType != typeof(bool))
            {
                throw new ArgumentException("StringListParse:缺省值设置默认类型不是bool类型");
            }
        }
    }
}
