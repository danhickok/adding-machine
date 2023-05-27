using System.Text;

namespace AddingMachine.Core
{
    internal static class Extensions
    {
        public static string Serialize(this Dictionary<string, string> dictionary)
        {
            var sb = new StringBuilder();

            var first = true;
            foreach (var key in dictionary.Keys)
            {
                if (!first)
                {
                    sb.Append('|');
                }

                sb.Append(key);
                sb.Append('=');
                sb.Append(dictionary[key]);
                first = false;
            }

            return sb.ToString();
        }

        public static void Deserialize(this Dictionary<string, string> dictionary, string value)
        {
            dictionary.Clear();
            var entries = value.Split('|');
            foreach (var entry in entries)
            {
                var keyValuePair = entry.Split('=');
                dictionary[keyValuePair[0]] = keyValuePair[1];
            }
        }
    }
}
