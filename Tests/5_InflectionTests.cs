using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class InflectionTests
    {
        [Theory]
        [InlineData("inflections_is_empty.xml")]
        [InlineData("inflections_is_duplicated.xml")]
        [InlineData("inflections_is_mixed_content.xml")]
        [InlineData("inflection_is_empty.xml")]
        public void InvalidInflections_fails(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("inflection_is_duplicated.xml")]
        [InlineData("inflection_is_trimmed.xml")]
        [InlineData("inftype_is_valid.xml")]
        public void ValidInflectionElement_passes(string filename)
        {
          Assert.True(IsValid(filename));
        }

        [Theory]
        [InlineData("inflection_is_untrimmed.xml")]
        [InlineData("inflection_is_whitespace_only.xml")]
        [InlineData("inftype_is_invalid.xml")]
        public void InvalidInflectionElement_fails(string filename)
        {
          Assert.False(IsValid(filename));
        }
                
        [Fact]
        public void inftype_multiples_for_one_inflection_throws_error()
        {
            Exception ex = Assert.Throws<XmlException>(() => Assert.False(IsValid("inftype_multiples_for_one_inflection.xml")));
            Assert.StartsWith("'infType' is a duplicate attribute name.", ex.Message);
        }
        
        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\5_InflectionTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}