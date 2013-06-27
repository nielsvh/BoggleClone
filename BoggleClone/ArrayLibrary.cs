using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace BoggleClone
{
    class ArrayLibrary : LibraryInterface
    {
        string[] libArray;
        public void BuildLibrary(string LexiconFile)
        {
            StreamReader reader = new StreamReader(LexiconFile);
            string content = reader.ReadToEnd();
            this.libArray = content.Split(',');
        }

        public SearchResult SearchLibrary(string word)
        {
            return BinarySearch(word, 0, libArray.Length);
        }

        private SearchResult BinarySearch(string word, int start, int end)
        {
            if (start == end && !libArray[start].Equals(word))
            {
                return new SearchResult();
            }

            switch (string.Compare(word, libArray[(end - start) / 2 + start], true))
            {
                case 1:
                    return BinarySearch(word, (end - start) / 2 + start, end);
                    break;
                case -1:
                    return BinarySearch(word, start, end - (end - start) / 2);
                    break;
                case 0:
                    SearchResult res = new SearchResult();
                    res.ExistFlags = (int)ExistTypes.DOES_EXIST | (int)ExistTypes.END_OF_WORD;
                    return res;
                    break;
            }

            return new SearchResult();
        }
    }
}
