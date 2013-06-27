using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BoggleClone
{
    // types of search results
    public enum ExistTypes { DOES_EXIST = 1, MIDDLE_OF_WORD = 2, END_OF_WORD = 4 }

    // search result struct tells AI about searched word and what letters to look for next.
    public struct SearchResult {
        public int ExistFlags;
        public string NextChars;
    }

    /// <summary>
    /// Strategy pattern interface. All libraries implement this so they can be swapped out at run time.
    /// </summary>
    public interface LibraryInterface
    {
        void BuildLibrary(string LexiconFile);
        SearchResult SearchLibrary(string word);
    }
}
