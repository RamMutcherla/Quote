using System;
using System.Collections.Generic;
using System.IO;

namespace Quote
{
    public class ReadFile : IReadFile
    {
        private readonly ISplitFile splitFile;

        public ReadFile(ISplitFile splitFile)
        {
            if (splitFile == null)
            {
                throw new ArgumentNullException(nameof(splitFile));
            }

            this.splitFile = splitFile;
        }

        public List<string[]> Read(string filePath)
        {
            string bodyContent;

            try
            {
                bodyContent = File.ReadAllText(filePath);
            }
            catch (Exception exp)
            {
                throw new IOException("Error occured when reading the file to memory", exp.InnerException);
            }

            var listContent = this.splitFile.Split(bodyContent);

            return listContent;
        }
    }
}