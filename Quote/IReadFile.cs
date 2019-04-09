using System.Collections.Generic;

namespace Quote
{
    public interface IReadFile
    {
        List<string[]> Read(string filePath);
    }
}