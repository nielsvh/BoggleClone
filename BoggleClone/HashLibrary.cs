using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace BoggleClone
{/// <summary>
    /// Node for hash table version of library
    /// </summary>
    public class LibraryHashNode
    {
        /// <summary>
        /// children dictionary of this node
        /// </summary>
        Dictionary<char, LibraryHashNode> children;
        /// <summary>
        /// bool of whether this letter is the end of a word
        /// </summary>
        public bool isEnd = false;
        /// <summary>
        /// the character that this node represents
        /// </summary>
        char nodeChar;

        /// <summary>
        /// Constructor set the character of this node
        /// </summary>
        /// <param name="nodeChar">This node's character</param>
        public LibraryHashNode(char nodeChar)
        {
            children = new Dictionary<char, LibraryHashNode>();
            this.nodeChar = nodeChar;
        }
        public void AddWord(string word, int index)
        {
            if (index == word.Length)
                return;

            LibraryHashNode node;
            if (!children.ContainsKey(word[index]))
            {
                node = new LibraryHashNode(word[index]);
                this.children.Add(word[index], node);
            }
            else
            {
                node = children[word[index]];
            }

            if (index + 1 == word.Length)
                node.isEnd = true;
            node.AddWord(word, index + 1);


        }
    }


    class HashLibrary : LibraryInterface
    {
        HashSet<string> libHash;
        public void BuildLibrary(string LexiconFile)
        {
            StreamReader reader = new StreamReader("lexicon.txt");
            string content = reader.ReadToEnd();
            this.libHash = new HashSet<string>(content.Split(','));
        }

        public SearchResult SearchLibrary(string word)
        {
            switch (this.libHash.Contains(word))
            {
                case true:
                    SearchResult res = new SearchResult();
                    res.ExistFlags = (int)ExistTypes.DOES_EXIST | (int)ExistTypes.END_OF_WORD;
                    return res;
                    break;
                case false:
                    return new SearchResult();
                    break;
            }
            return new SearchResult();
        }
    }
}
