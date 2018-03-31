using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class XrefTests
    {
        [Theory]
        [InlineData("xrefs_is_empty.xml")]
        [InlineData("xrefs_is_duplicated.xml")]
        public void XrefsExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("xrefs_is_valid.xml")]
        [InlineData("xrefs_within_mixed.xml")]
        public void XrefsExamplesPass(string filename)
        {
            Assert.True(IsValid(filename));
        }
        
        [Theory]
        [InlineData("xref_is_empty.xml")]
        [InlineData("xref_no_blockid.xml")]
        public void XrefExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("xref_is_duplicated.xml")]
        [InlineData("xref_no_homograph.xml")]
        [InlineData("xref_no_targetid.xml")]
        public void XrefExamplesPass(string filename)
        {
            Assert.True(IsValid(filename));
        }

        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\10_XrefTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}