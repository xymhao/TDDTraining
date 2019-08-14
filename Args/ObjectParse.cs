using System;

namespace Args
{
    public abstract class ObjectParse
    {
        protected ObjectParse(SchemaInfo schemaInfo, ArgsParser argsParser, string flag)
        {
            SchemaInfo = schemaInfo;
            ArgsParser = argsParser;
            Value = GetArgsValue(flag);
            Flag = flag;
        }

        protected SchemaInfo SchemaInfo { get; }

        public ArgsParser ArgsParser { get; }

        protected string Value { get; }

        protected bool Exist { get; set; }

        public string Flag { get; }

        public abstract object GetValue();

        public bool IsNullValue()
        {
            return string.IsNullOrEmpty(Value);
        }

        public ArgumentException ParseArgumentException()
        {
            throw new ArgumentException($"-{Flag}:输入不是有效的{SchemaInfo.ArgsType.Name}类型！");
        }

        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string GetArgsValue(string flag)
        {
            var value = ArgsParser.GetValue(flag, out bool exist);
            Exist = exist;
            return value;
        }

        protected abstract void ValidateType();

    }
}
