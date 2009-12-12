using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

namespace SQLExtensions
{

    /// <summary>
    /// A useful set of regular expression functions that can be used in the database.
    /// </summary>
    public static class SqlRegularExpressions
    {

        /// <summary>
        /// This method will test that the data is found in the 
        /// </summary>
        /// <param name="regexPattern"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name="IsMatch",IsDeterministic = true)]
        public static bool IsMatch(String regexPattern, String data)
        {
            return  new Regex(regexPattern).Match(data).Success;
        }

        /// <summary>
        /// Returns Group 0 if the data matches the regex, returns null if it doesn't match.
        /// </summary>
        /// <param name="regexPattern"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [SqlFunction(Name="Match", IsDeterministic = true)]
        public static String Match(String regexPattern, String data)
        {
            String retval = null;
            if (data != null)
            {
                var m = new Regex(regexPattern).Match(data);
                if (m.Success)
                {
                    retval = m.Value;
                }
            }
            return retval;
        }

        /// <summary>
        /// Get the specified group from the match, null if that group doesn't exist, or the pattern doesn't match.
        /// </summary>
        /// <param name="regexPattern"></param>
        /// <param name="data"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        [SqlFunction(Name="GroupMatch", IsDeterministic = true)]
        public static String GroupMatch(String regexPattern, String data, int group)
        {
            String retval = null;
            var m = new Regex(regexPattern).Match(data);
            if (m.Success && m.Groups.Count >= group)
            {
                retval = m.Groups[group].Value;
            }
            return retval;
        }

        /// <summary>
        /// Replaces the matches of the regular expression with the replacement in the source data.
        /// </summary>
        /// <param name="regexPattern"></param>
        /// <param name="data"></param>
        /// <param name="replacement">The string with the replacement(s) applied</param>
        /// <returns></returns>
        [SqlMethod(Name="RegexReplace", IsDeterministic=true)]
        public static String RegexReplace(String regexPattern, String data, String replacement)
        {
            return data == null ? null : new Regex(regexPattern).Replace(data, replacement);
        }

        //here would be a useful place to demonstrate a Table-Valued Function def on Matches.


    }
}
