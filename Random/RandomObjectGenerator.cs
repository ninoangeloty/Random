using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomJunk
{
    public class RandomObjectGenerator
    {
        public T Generate<T>()
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double) ||
                typeof(T) == typeof(decimal) || typeof(T) == typeof(float))
            {
                var random = new Random();
                return (T)Convert.ChangeType(random.Next(), typeof(T));
            }
            else if (typeof(T) == typeof(Guid))
            {
                return (T)Convert.ChangeType(Guid.NewGuid(), typeof(T));
            }
            else if (typeof(T) == typeof(string))
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
            {
                return default(T);
            }
        }
    }
}
