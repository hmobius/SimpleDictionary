using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class PronunciationTests
    {
        [Theory]
        [InlineData("pronunciations_is_empty.xml")]
        [InlineData("pronunciations_is_duplicated.xml")]
        [InlineData("pronunciations_is_mixed_content.xml")]
        public void InvalidPronunciations_fails(string filename)
        {
          Assert.False(IsValid(filename));
        }
                
        
        /// You cannot place constraints on a mixed content's text nodes. 
        /// You can constrain the elements of the mixed content as usual, but the actual mixed-in text is free from constraints.
        /// Some pronunciations need stresses so we can't enforce blank content

        [Theory]
        [InlineData("pronunciation_is_empty.xml")]
        [InlineData("pronunciation_is_untrimmed.xml")]
        [InlineData("pronunciation_is_whitespace_only.xml")]
        public void pronunciation_mixedcontent_passes_but_should_fail(string filename)
        {
          Assert.True(IsValid(filename));
        }
                
        [Theory]
        [InlineData("pronunciation_is_duplicated.xml")]
        [InlineData("pronunciation_is_trimmed.xml")]
        [InlineData("prontype_is_valid.xml")]
        [InlineData("stress_single.xml")]
        public void ValidPronunciationElement_passes(string filename)
        {
          Assert.True(IsValid(filename));
        }

        [Theory]
        [InlineData("prontype_is_invalid.xml")]
        [InlineData("prontype_is_missing.xml")]
        [InlineData("stress_empty.xml")]
        [InlineData("stress_multiple.xml")]
        public void InvalidPronunciationElement_fails(string filename)
        {
          Assert.False(IsValid(filename));
        }
                                
        [Fact]
        public void prontype_multiples_for_one_pronunciation_throws_error()
        {
            Exception ex = Assert.Throws<XmlException>(() => Assert.False(IsValid("prontype_multiples_for_one_pronunciation.xml")));
            Assert.StartsWith("'pronType' is a duplicate attribute name.", ex.Message);
        }        

        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\6_PronunciationTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}