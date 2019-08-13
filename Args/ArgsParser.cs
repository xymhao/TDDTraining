using System;
using System.Collections.Generic;
using System.Text;

namespace Args
{
    public class ArgsParser
    {
        public static string[] Parser(string argsText)
        {
            argsText = argsText.Trim();
            return $" {argsText}".Split(new[] { " -" }, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
