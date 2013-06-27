using BoggleClone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestBoggleTreeLib
{
    
    
    /// <summary>
    ///This is a test class for TreeLibraryTest and is intended
    ///to contain all TreeLibraryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TreeLibraryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for BuildLibrary
        ///</summary>
        [TestMethod()]
        public void BuildLibraryTest()
        {
            TreeLibrary target = new TreeLibrary(); // TODO: Initialize to an appropriate value
            string LexiconFile = "lexicon.txt"; // TODO: Initialize to an appropriate value
            target.BuildLibrary(LexiconFile);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            TreeLibrary target = new TreeLibrary(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            SearchResult actual;
            actual = target.SearchLibrary(word);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
