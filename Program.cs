using System;

namespace CSharpUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TokenHelper

            Console.WriteLine("Hello World!");
            var generatedLong = TokenHelper.GenerateRandomLong();
            Console.WriteLine(generatedLong);
            var token = TokenHelper.GetKeyGuid(generatedLong);
            Console.WriteLine(token);
            var reGeneratedLong = TokenHelper.GetGuidKey(token);
            Console.WriteLine(reGeneratedLong);

            #endregion

            #region MD5Core
            var passHash =  MD5Core.GetHashString("password");

            #endregion


        }
    }
}
