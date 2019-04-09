using System.Collections.Generic;

namespace Quote
{
    public interface ISplitFile
    {
        List<string[]> Split(string fileContent);
    }
}