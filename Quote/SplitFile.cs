using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quote
{
    public class SplitFile : ISplitFile
    {
        private const string Separator = "\r\n";

        private const string RegexSeparator = ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";

        public List<string[]> Split(string fileContent)
        {
            var listContent = new List<string[]>();

            string[] contentRows = fileContent.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

            Regex csvParser = new Regex(RegexSeparator);

            foreach (var row in contentRows)
            {
                string[] contentRow = csvParser.Split(row.Trim());

                listContent.Add(contentRow);
            }

            return listContent;
        }
    }
}