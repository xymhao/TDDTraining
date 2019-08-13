using System;
using System.Collections.Generic;
using System.Linq;

namespace Args
{
    public class IntListParse : ObjectParse
    {
        public IntListParse(SchemaInfo info, string[] argsArray, string flag) : base(info, argsArray, flag)
        {

        }

        public override object GetValue()
        {
            ValidateType();
            if (!Exist)
                return SchemaInfo.DefaultValue;
            try
            {
                var result = Value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                return result.ConvertAll(Convert.ToInt32);
            }
            catch
            {
                throw ParseArgumentException();
            }
        }

        protected override void ValidateType()
        {
            if (SchemaInfo.ArgsType != typeof(List<int>))
            {
                throw new ArgumentException("IntListParse:缺省值设置默认类型不是List<int>类型");
            }
        }
    }
}