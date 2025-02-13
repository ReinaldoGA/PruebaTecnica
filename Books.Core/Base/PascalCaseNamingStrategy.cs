using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Base
{
    /// <summary>
    /// Uses Pascal case naming strategy, first letter is capitalized, and first letter
    /// of subsequent words are capitalized.
    /// </summary>
    public class PascalCaseNamingStrategy : NamingStrategy
    {
        public PascalCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
        {
            ProcessDictionaryKeys = processDictionaryKeys;
            OverrideSpecifiedNames = overrideSpecifiedNames;
        }

        public PascalCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)
            : this(processDictionaryKeys, overrideSpecifiedNames)
        {
            ProcessExtensionDataNames = processExtensionDataNames;
        }

        public PascalCaseNamingStrategy()
        {
        }

        protected override string ResolvePropertyName(string name)
        {
            return ToPascalCase(name);
        }

        private static string ToPascalCase(string s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
            {
                return s;
            }

            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 0 && !char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToUpper(chars[i]);
                    break;
                }
                else if (i == 0)
                {
                    break;
                }

                if (i == 1 && !char.IsUpper(chars[i]))
                {
                    break;
                }

                bool hasNext = (i + 1 < chars.Length);
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    if (char.IsSeparator(chars[i + 1]))
                    {
                        chars[i] = char.ToLower(chars[i]);
                    }

                    break;
                }

                chars[i] = char.ToLower(chars[i]);
            }

            return new string(chars);
        }
    }
}
