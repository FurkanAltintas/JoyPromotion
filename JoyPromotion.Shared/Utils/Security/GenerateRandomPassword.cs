using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Shared.Utils.Security
{
    public static class GenerateRandomPassword
    {
        private const int RequiredLength = 8;
        private const int RequiredUniqueChars = 4;
        private const bool RequireDigit = true;
        private const bool RequireLowercase = true;
        private const bool RequireUppercase = true;
        private const bool RequireNonAlphanumeric = true;

        public static string Password()
        {
            string[] randomChars = new[]
            {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijklmnopqrstuvwxyz",
                "0123456789",
                "!@$?_-<>.,"
            };

            Random random = new();
            List<char> chars = new();

            if (RequireUppercase)
            {
                chars.Insert(random.Next(0, chars.Count),
                randomChars[0][random.Next(0, randomChars[0].Length)]);
            }

            if (RequireLowercase)
            {
                chars.Insert(random.Next(0, chars.Count),
                randomChars[1][random.Next(0, randomChars[1].Length)]);
            }

            if (RequireDigit)
            {
                chars.Insert(random.Next(0, chars.Count),
                randomChars[2][random.Next(0, randomChars[2].Length)]);
            }

            if (RequireNonAlphanumeric)
            {
                chars.Insert(random.Next(0, chars.Count),
               randomChars[3][random.Next(0, randomChars[3].Length)]);
            }

            for (int i = chars.Count; i < RequiredLength || chars.Distinct().Count() < RequiredUniqueChars; i++)
            {
                string rc = randomChars[random.Next(0, randomChars.Length)];
                chars.Insert(random.Next(0, chars.Count),
                    rc[random.Next(0, rc.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
