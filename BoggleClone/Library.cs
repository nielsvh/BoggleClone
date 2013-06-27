using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace BoggleClone
{
    /*
    /// <summary>
    /// Tree node of the library used when using tree style of library.
    /// </summary>
    public class LibraryTreeNode
    {
        /// <summary>
        /// Children nodes of this leaf node
        /// </summary>
        LibraryTreeNode[] children;

        /// <summary>
        /// bool of whether this letter is the end of a word
        /// </summary>
        bool isEnd = false;

        /// <summary>
        /// the character that this node represents
        /// </summary>
        char nodeChar;

        /// <summary>
        /// Default constructor. Make sure children are set up for data entry.
        /// </summary>
        public LibraryTreeNode()
        {
            children = new LibraryTreeNode[26];
        }

        /// <summary>
        /// Recursive function to add a word to the library, one character at a time
        /// </summary>
        /// <param name="word">The word to be added</param>
        /// <param name="index">The index within the word that this step is at</param>
        public void AddWord(string word, int index)
        {
            // set this node's character
            this.nodeChar = word[index];
            // if this is the end of the word, set this node as such
            if (!this.isEnd && word.Length == index + 1)
                this.isEnd = true;
            
            // check to see if we are at the end. If we are, return
            if (word.Length == index+1)
                return;

            // get the index of the next leaf node to add
            int nodeIndex = word[index+1] - 'a';
            // make sure the node is ready to be set up
            if (children[nodeIndex] == null)
                children[nodeIndex] = new LibraryTreeNode();
            // call this with the next step
            children[nodeIndex].AddWord(word, index+1);
        }
    }

    /// <summary>
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
    }*/

    /// <summary>
    /// Library class builds and houses the lexicon of accepted words.
    /// </summary>
    public class Library
    {
        public TimeSpan BuildLibrary(LibraryType type)
        {
            this.currentType = type;
            Stopwatch stopwatch = Stopwatch.StartNew();
            switch (type)
            {
                case LibraryType.TREE:
                    BuildTreeLibrary();
                    break;
                case LibraryType.HASH_TABLE:
                    BuildHashLibrary();
                    break;
                case LibraryType.ARRAY:
                    BuildArrayLibrary();
                    break;
            }
            stopwatch.Stop();
            return stopwatch.Elapsed;

        }
    }
}