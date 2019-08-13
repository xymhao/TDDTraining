using System;
using System.Collections.Generic;
using System.Text;

namespace Args
{
    public class ArgsSchema
    {
        public Dictionary<string, SchemaInfo> SchemaDict { get; set; } = new Dictionary<string, SchemaInfo>();

        public ArgsSchema(string schemaText)
        {
            var schemaArr = schemaText.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in schemaArr)
            {
                var key = s.Split(":")[0];
                var type = s.Split(":")[1];
                SchemaDict.Add(key, new SchemaInfo(type));
            }
        }


        public SchemaInfo GetSchemaInfo(string flag)
        {
            return SchemaDict.GetValueOrDefault(flag);
        }
    }
}
