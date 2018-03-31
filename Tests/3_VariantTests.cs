using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class VariantTests
    {
        [Theory]
        [InlineData("variants_is_empty.xml")]
        [InlineData("variants_is_duplicated.xml")]
        public void InvalidVariantsElement_fails(string filename)
        {
          Assert.False(IsValid(filename));
        }
                
        [Theory]
        [InlineData("variant_is_empty.xml")]
        [InlineData("variant_is_untrimmed.xml")]
        [InlineData("variant_is_whitespace_only.xml")]
        public void InvalidVariantElement_fails(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("variant_is_trimmed.xml")]
        [InlineData("variant_in_multiples.xml")]
        public void ValidVariantElement_passes(string filename)
        {
            Assert.True(IsValid(filename));
        }
                
        private bool IsValid(string xmlFileName, bool showLog = false)
        {
            Validator val = new Validator("Tests\\3_VariantTests");
            return val.DictionaryTest(xmlFileName, showLog);
        }
    }
}