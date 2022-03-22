using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtilities
{
    public static class TokenHelper
    {
        private const string GuidChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_";

        private static readonly Dictionary<char, int> GuidCharIndexesDic =
            GuidChars.ToDictionary(x => x, x => GuidChars.IndexOf(x));

        public static long GenerateRandomLong(long min = long.MinValue, long max = long.MaxValue, Random rand = null)
        {
            rand = rand ?? new Random();
            byte[] resBytes = new byte[sizeof(ulong)];
            rand.NextBytes(resBytes);
            long res = BitConverter.ToInt64(resBytes, 0);
            return res;
            /*long res = rand.Next((int)(min >> 32), (int)(max >> 32));
            res <<= 32;
            res |= (long)rand.Next((int)min, (int)max);*/
        }

        public static string GetKeyGuid(long key)
        {
            const int bytesCount = 11;
            const int cut = 0b111111;
            var res = new StringBuilder(bytesCount);

            for (int shiftNom = 0; shiftNom < bytesCount; shiftNom++)
            {
                int curNom = (int)(key & cut);
                char curChar = GuidChars[curNom];
                res.Append(curChar);
                key >>= 6;
            }
            return res.ToString();
        }

        public static long? GetGuidKey(string guid)
        {
            if (guid.Length != 11)
                return null;
            long res = 0;
            for (int shiftNom = 10; shiftNom >= 0; shiftNom--)
            {
                char curChar = guid[shiftNom];
                if (!GuidCharIndexesDic.TryGetValue(curChar, out int charIndex))
                    return null;

                res += charIndex;
                if (shiftNom > 0)
                    res <<= 6;
            }

            return res;
        }


    }
}
