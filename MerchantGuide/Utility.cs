using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MerchantGuide
{
    /// <summary>
    ///     工具
    /// </summary>
    public class Utility
    {
        public static IList<string> ReadTxt(string path)
        {
            IList<string> result = new List<string>();
            using (var sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
                sr.Close();
                return result;
            }
        }
    }
}