using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class SimpleTests
    {
        [Fact]
        public void EmptyDoc_ThrowsException()
        {
            Exception ex = Assert.Throws<XmlException>(() => Assert.False(IsValid("empty.xml")));
            Assert.Equal("Root element is missing.", ex.Message);
        }

        [Theory]
        [InlineData("emptydictionary.xml")]
        [InlineData("emptyentry.xml")]
        [InlineData("entry_suppressed_not_boolean.xml")]
        public void EmptyDictionaryElement_Fails(string filename)
        {
            Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("entry_suppressed_true.xml")]
        public void Entry_suppressed_true_passes(string filename)
        {
          Assert.True(IsValid(filename));
        }        
        
        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\1_SimpleTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}