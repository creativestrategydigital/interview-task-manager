using System;
using System.Linq;

namespace TaskManager.App
{
    public class Helpers
    {
        public static string GenerateRandomString(int length = 8)
        {
            Random random = new Random(); 
            const string chars = "abcdefghijklmponqrstuvwxyz01234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}