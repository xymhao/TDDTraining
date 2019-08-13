using System;

namespace Args
{
    public class IntParse : ObjectParse
    {
        public IntParse(SchemaInfo schemaInfo, string[] argsArray, string flag) : base(schemaInfo, argsArray, flag)
        {
        }

        public override object GetValue()
        {
            ValidateType();
            if (!Exist) return SchemaInfo.DefaultValue;
            if (int.TryParse(Value, out int intValue))
                return intValue;
            throw ParseArgumentException();

        }

        protected override void ValidateType()
        {
            if (SchemaInfo.ArgsType != typeof(int))
            {
                throw new ArgumentException("IntParse:缺省值设置默认类型不是int类型");
            }
        }
    }
}
