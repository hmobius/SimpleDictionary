using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class HeadwordTests
    {
        [Theory]
        [InlineData("oneemptyheadwords.xml")]
        [InlineData("twoemptyheadwords.xml")]
        [InlineData("twovalidheadwords.xml")]
        [InlineData("headword_is_empty_element.xml")]
        [InlineData("word_is_empty.xml")]
        [InlineData("word_is_whitespace_only.xml")]
        [InlineData("word_is_untrimmed.xml")]
        public void InvalidHeadwordsElement_Fails(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("word_is_trimmed.xml")]
        [InlineData("word_in_multiples.xml")]
        public void ValidHeadwordsElements_passes(string filename)
        {
            Assert.True(IsValid(filename));
        }
        
        [Theory]
        [InlineData("homograph_is_negative.xml")]
        [InlineData("homograph_is_zero.xml")]
        public void InvalidHomographNumbers_fails(string filename)
        {
            Assert.False(IsValid(filename));
        }

        [Fact]
        public void Homograph_is_positive_fails()
        {
            Assert.True(IsValid("homograph_is_positive.xml"));
        }

        private bool IsValid(string xmlFileName, bool showLog = false)
        {
            Validator val = new Validator("Tests\\2_HeadwordTests");
            return val.DictionaryTest(xmlFileName, showLog);
        }
    }
}