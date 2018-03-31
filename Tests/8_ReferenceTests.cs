using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class ReferenceTests
    {
        [Theory]
        [InlineData("reference_is_empty.xml")]
        [InlineData("reference_no_author.xml")]
        [InlineData("reference_no_text.xml")]
        [InlineData("reference_no_work.xml")]
        [InlineData("reference_two_authors.xml")]
        [InlineData("reference_two_texts.xml")]
        [InlineData("reference_two_works.xml")]
        [InlineData("reference_wrong_order.xml")]
        public void ReferenceExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("reference_is_duplicated.xml")]
        public void ReferenceExamplesPass(string filename)
        {
            Assert.True(IsValid(filename));
        }

        [Theory]
        [InlineData("author_is_empty.xml")]
        [InlineData("author_is_untrimmed.xml")]
        [InlineData("author_is_whitespace_only.xml")]
        [InlineData("work_is_empty.xml")]
        [InlineData("work_is_untrimmed.xml")]
        [InlineData("work_is_whitespace_only.xml")]
        public void ReferenceContentExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("text_is_empty.xml")]
        [InlineData("text_is_mixed_content.xml")]
        public void ReferenceContentExamplesPass(string filename)
        {
            Assert.True(IsValid(filename));
        }



        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\8_ReferenceTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}