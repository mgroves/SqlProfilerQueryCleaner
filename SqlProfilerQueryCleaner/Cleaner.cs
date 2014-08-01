using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlProfilerQueryCleaner
{
    public class Cleaner
    {
        public static string Clean(string sql)
        {
            // remove executesql call
            string resultSql = sql.Replace("exec sp_executesql N'", "");

            // split between sql and params
            var splitSql = resultSql.Split(new[] { "',N'" }, StringSplitOptions.None);
            resultSql = splitSql[0];
            var unescapedSql = resultSql.Replace("''", "'");
            unescapedSql = SqlFormatter.SqlFormatter.Format(unescapedSql);

            var rearrangedParameters = GetParameterDeclarationAndValues(splitSql[1]);

            // put a line between the parameters and the SQL
            return rearrangedParameters + Environment.NewLine + unescapedSql;
        }

        static string GetParameterDeclarationAndValues(string sqlParams)
        {
            // split by ,@ instead of just , so that decimal(x,y) doesn't screw it up
            var csv = Regex.Split(sqlParams, ",@");
            var declarations = new List<string>();
            var firstHalfIndex = 0;

            // the first half are declarations, so they don't have '=' in them
            while (!csv[firstHalfIndex].Contains("="))
            {
                // trim off the '@' which will only be on the first one
                var nameAndType = csv[firstHalfIndex].Trim('@');
                // add an '@' back on and remove the trailing single quote (flipside of '@' trim).
                nameAndType = "@" + nameAndType.Trim('\'');
                // add it to the list
                declarations.Add(nameAndType);
                firstHalfIndex++;
            }

            // the second half are value assignments
            // that correspond to the declarations
            var values = new List<string>();
            for (int secondHalfIndex = firstHalfIndex; secondHalfIndex < csv.Length; secondHalfIndex++)
            {
                // we already have the var name, so split it at the equal
                // and just take the right-hand side
                var valueAssignment = csv[secondHalfIndex].Split('=')[1];
                values.Add(valueAssignment.Trim());
            }

            // combine the declaration (name/type) with the assignments (values)
            var declarationBuilder = new StringBuilder();
            for (int combinedIndex = 0; combinedIndex < declarations.Count; combinedIndex++)
                declarationBuilder.AppendFormat("DECLARE {0}={1};", declarations[combinedIndex], values[combinedIndex]).AppendLine();
            return declarationBuilder.ToString();
        }
    }
}