using System;

namespace Args
{
    public abstract class ObjectParse
    {
        protected ObjectParse(SchemaInfo schemaInfo, string[] argsArray, string flag)
        {
            SchemaInfo = schemaInfo;
            ArgsArray = argsArray;
            Value = GetArgsValue(flag, out bool exist);
            Exist = exist;
            Flag = flag;
        }

        protected SchemaInfo SchemaInfo { get; }

        public string[] ArgsArray { get; }

        protected string Value { get; }

        protected bool Exist { get; }

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
        /// <param name="exist"></param>
        /// <returns></returns>
        private string GetArgsValue(string flag, out bool exist)
        {
            exist = false;
            foreach (string arg in ArgsArray)
            {
                var arr = arg.Split(" ");
                if (arr[0] != flag) continue;
                exist = true;
                return arr.Length > 1 ? arr[1] : null;
            }
            return null;
        }

        protected abstract void ValidateType();

    }
}
