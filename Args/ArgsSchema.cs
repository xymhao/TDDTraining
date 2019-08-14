using System;
using System.Collections.Generic;
using System.Text;

namespace Args
{
    public class ArgsSchema : Dictionary<string, SchemaInfo>
    {
        private Dictionary<string, SchemaInfo> SchemaDict { get; set; } = new Dictionary<string, SchemaInfo>();

        public ArgsSchema(string schemaText)
        {
            var schemaArr = schemaText.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in schemaArr)
            {
                var key = s.Split(":")[0];
                var type = s.Split(":")[1];
                Add(key, new SchemaInfo(type, key));
            }
        }


        public SchemaInfo GetSchemaInfo(string flag)
        {
            TryGetValue(flag, out SchemaInfo info);
            return info;
        }
    }
}
