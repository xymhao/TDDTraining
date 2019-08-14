using System;
using System.Collections.Generic;

namespace Args
{
    public class ArgsParser
    {
        private readonly Dictionary<string, string> ArgsDict = new Dictionary<string, string>();

        public ArgsParser(string argsText)
        {
            argsText = argsText.Trim();
            var argsSplit = argsText.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < argsSplit.Length; i++)
            {
                var key = argsSplit[i];
                string value = null;
                if (i + 1 < argsSplit.Length)
                {
                    string nextArg = argsSplit[i+1];
                    if (!nextArg.StartsWith("-", StringComparison.Ordinal) || IsNumber(nextArg))
                    {
                        value = nextArg;
                        i++;
                    }
                }
                ArgsDict.Add(key.TrimStart('-'), value);
            }
        }

        private static bool IsNumber(string nextArg)
        {
            return nextArg.ToCharArray()[0] == '-' 
                   && nextArg.ToCharArray()[1] <= '9' 
                   && nextArg.ToCharArray()[1] >= '0';
        }


        public string GetValue(string flag, out bool exist)
        {
            exist = ArgsDict.TryGetValue(flag, out string value);
            return value;
        }
    }
}
