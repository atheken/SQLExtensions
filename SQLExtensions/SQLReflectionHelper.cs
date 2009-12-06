using System;
using System.Collections.Generic;
using System.Reflection;
using SQLExtensions;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace SQLExtensions
{
    public static class SqlReflectionHelper
    {
        public static Dictionary<String, String> _sqlMapping = new Dictionary<string, string>();

        private static void LoadMapping()
        {
            var dict = SqlReflectionHelper._sqlMapping;
            dict.Clear();
            dict[typeof(String).FullName] = "nvarchar(max)";
            dict[typeof(int).FullName] = "int";
            dict[typeof(byte).FullName] = "tinyint";
            dict[typeof(byte?).FullName] = "tinyint";
            dict[typeof(long).FullName] = "bigint";
            dict[typeof(short).FullName] = "smallint";
            dict[typeof(DateTime).FullName] = "datetime";
            dict[typeof(DateTime?).FullName] = "datetime";
            dict[typeof(byte[]).FullName] = "binary";
            dict[typeof(bool).FullName] = "bit";
            dict[typeof(decimal).FullName] = "decimal";
            dict[typeof(float?).FullName] = "float";
            dict[typeof(float?).FullName] = "float";
            dict[typeof(double).FullName] = "float";
            dict[typeof(double?).FullName] = "float";
            dict[typeof(char[]).FullName] = "nvarchar(max)";
            dict[typeof(char).FullName] = "nchar(1)";
            dict[typeof(Single).FullName] =  "real";
            dict[typeof(Single?).FullName] = "real";
            dict[typeof(Guid).FullName] = "uniqueidentifier";
            dict[typeof(Guid?).FullName] = "uniqueidentifier";
        }

        public static IEnumerable<String> GenerateFunctionDefs()
        {
            SqlReflectionHelper.LoadMapping();

            var types =  Assembly.GetAssembly(typeof(SqlRegularExpressions)).GetTypes().Where(y =>!y.IsAbstract);
            
            foreach(var t in types)
            {
                foreach (var m in t.GetMethods(BindingFlags.Static|BindingFlags.Public))
                {
                    var attrib = m.GetCustomAttributes(false).OfType<SqlFunctionAttribute>().FirstOrDefault();
                    if (attrib != null)
                    {
                        var p = m.GetParameters();

                        var retval = String.Format("CREATE FUNCTION [dbo].{0}({1}) {2} WITH EXECUTE AS CALLER AS" +
                            " EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlRegularExpressions].[GroupMatch];",
                            attrib.Name ?? m.Name,
                            p.Aggregate("",(seed,current)=>seed += current.Name + " " + 
                                SqlReflectionHelper._sqlMapping[current.ParameterType.FullName] + ",").TrimEnd(','),
                                m.ReturnType != null ? "RETURNS "+ SqlReflectionHelper._sqlMapping[m.ReturnType.FullName] :"" );

                        yield return retval;
                    }
                }
            }
            yield break;
        }
    }
}
