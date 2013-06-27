using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BoggleClone
{
    /// <summary>
    /// Tree node of the library used when using tree style of library.
    /// </summary>
    public class LibraryTreeNode
    {
        /// <summary>
        /// Lowest character in the lexicon. Default 'a' for english.
        /// </summary>
        static char LowestChar = 'a';

        public static char LowestLibraryChar
        {
            get { return LowestChar; }
        }

        /// <summary>
        /// Width of the tree. Default 26 for english.
        /// </summary>
        static int Width = 26;

        /// <summary>
        /// Child nodes of this node. 
        /// </summary>
        LibraryTreeNode[] Children;

        /// <summary>
        /// Is this node the end of a word?
        /// </summary>
        bool IsEnd = false;

#if DEBUG
        /// <summary>
        /// This node's representation.
        /// </summary>
        char NodeChar;
#endif

        /// <summary>
        /// Default constructor. Makes sure this.Children are initialized.
        /// </summary>
        public LibraryTreeNode()
        {
            this.Children = new LibraryTreeNode[26];
        }

        /// <summary>
        /// Recursive function to add string to library, one character at a time
        /// </summary>
        /// <param name="word">The word to be added</param>
        /// <param name="index">
        ///     Index of word parameter.
        ///     If -1, this node is the root. Skip into next nodes.
        /// </param>
        public void AddLetterNode(string word, int index)
        {
            if (index != -1){
#if DEBUG
                this.NodeChar = word[index];
#endif
                if (!this.IsEnd && word.Length == index + 1){
                    this.IsEnd = true;
                }

                if (word.Length == index + 1){
                    return;
                }
            }

            int childNodeIndex = word[index + 1] - LowestChar;

            if (this.Children[childNodeIndex] == null){
                this.Children[childNodeIndex] = new LibraryTreeNode();
            }

            this.Children[childNodeIndex].AddLetterNode(word, index + 1);
        }

        
        public SearchResult Search(string word, int index)
        {
            // does exist
            if (index == word.Length){
                SearchResult result = new SearchResult();
                result.ExistFlags = (int)ExistTypes.DOES_EXIST;

                // is end of word
                if (this.IsEnd){
		             result.ExistFlags |= (int)ExistTypes.END_OF_WORD;
	            }

                // is middle
                for (int i = 0; i < this.Children.Length; i++){
                        if(this.Children[i] != null){
                            result.ExistFlags |= (int)ExistTypes.MIDDLE_OF_WORD;
                            result.NextChars += (char)(i + LowestChar);
                        }
			    }

                return result;
            }else if (index < word.Length){
                // doesn't exist
                if (this.Children[word[index] - LowestChar] == null){
                    SearchResult result = new SearchResult();
                    result.ExistFlags = 0;
                    return result;
                }

                return this.Children[word[index] - LowestChar].Search(word, index + 1);
            }else{
                // Throw exception because we shouldn't ever be here. Give word and index info for debugging purposes.
                throw new IndexOutOfRangeException("Recursive call LibraryTreeNode.Search({0}, {1}) out of bounds.");
            }
        }
    }


    class TreeLibrary:LibraryInterface
    {
        /// <summary>
        /// Reference entier library from single node, to keep implementation details seperate.
        /// </summary>
        LibraryTreeNode LibraryTreeRoot;

        /// <summary>
        /// Build library. Here, read entire file and feed individual words to the tree to parse.
        /// </summary>
        public void BuildLibrary(string LexiconFile)
        {
            this.LibraryTreeRoot = new LibraryTreeNode();

            StreamReader reader = new StreamReader(LexiconFile);
            string lexiconWordList = reader.ReadToEnd();

            int pos = -1;
            int nextEnd;
            string word;
            while (pos < lexiconWordList.Length){
                nextEnd = lexiconWordList.IndexOf(',', pos + 1);
                if (nextEnd == -1){
                    break;
                }
                word = lexiconWordList.Substring(pos + 1, nextEnd - pos - 1).ToLower();

                this.LibraryTreeRoot.AddLetterNode(word, -1);

                pos = nextEnd;
            }
        }

        /// <summary>
        /// Depending on the searched word, there are three major outcomes:
        ///     The word is a word and:
        ///         Is part of another word
        ///         Is not part of another word
        ///     The word is not a word but:
        ///         Is part of another word
        ///         Is not part of another word
        ///     The word is not a word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public SearchResult SearchLibrary(string word)
        {
            return this.LibraryTreeRoot.Search(word, 0);
        }
    }
}
