using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nullpointer.Metaphone;
using Microsoft.SqlServer.Server;

namespace SQLExtensions
{
    public static class SqlSoundsLike
    {
        /// <summary>
        /// Returns the primary key from a double metaphone calculation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name = "Metaphone", IsDeterministic = true)]
        public static String Metaphone(String data)
        {
            string primaryKey = null;
            string secondaryKey = null;
            if (data != null)
            {
                ShortDoubleMetaphone.doubleMetaphone(data, ref primaryKey, ref secondaryKey);
            }
            return primaryKey;
        }

        /// <summary>
        /// Returns the alternate key from a double metaphone calculation
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name = "MetaphoneAlternate", IsDeterministic = true)]
        public static String MetaphoneAlternate(String data)
        {
            string primaryKey = null;
            string secondaryKey = null;
            if (data != null)
            {
                ShortDoubleMetaphone.doubleMetaphone(data, ref primaryKey, ref secondaryKey);
            }
            return secondaryKey;
        }

        /// <summary>
        /// Returns a short key from a double metaphone calculation
        /// (although this is less readable, it allows for much better index and storage performance)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name = "ShortMetaphone", IsDeterministic = true)]
        public static short ShortMetaphone(String data)
        {
            short retval = 0;
            if (!String.IsNullOrEmpty(data))
            {
                retval = (short)new ShortDoubleMetaphone(data).PrimaryShortKey;
            }
            return retval;
        }

        /// <summary>
        /// Returns a short alternate key from a double metaphone calculation
        /// (although this is less readable, it allows for much better index and storage performance)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name = "ShortMetaphoneAlternate", IsDeterministic = true)]
        public static short ShortMetaphoneAlternate(String data)
        {
            short retval = 0;
            if (!String.IsNullOrEmpty(data))
            {
                retval = (short)new ShortDoubleMetaphone(data).AlternateShortKey;
            }
            return retval;
        }
    }

}
