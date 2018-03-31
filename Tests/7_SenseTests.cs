using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class SenseTests
    {
        [Theory]
        [InlineData("senses_is_duplicated.xml")]
        [InlineData("senses_is_empty.xml")]
        [InlineData("senses_is_mixed_content.xml")]
        public void SensesExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("sense_is_empty.xml")]
        [InlineData("sense_example_no_definition.xml")]
        [InlineData("sense_reference_no_definition.xml")]
        public void SenseExamplesFail(string filename)
        {
          Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("definition_is_duplicated.xml")]
        public void DefinitionExamplesFail(string filename)
        {
          Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("definition_is_simple_string.xml")]
        [InlineData("definition_is_mixed_content.xml")]
        public void DefinitionExamplesPass(string filename)
        {
          Assert.True(IsValid(filename));
        }

        [Theory]
        [InlineData("example_is_empty.xml")]
        [InlineData("example_text_is_duplicated.xml")]
        public void ExampleExamplesFail(string filename)
        {
          Assert.False(IsValid(filename));
        }

        [Theory]
        [InlineData("example_is_duplicated.xml")]
        [InlineData("example_text_is_empty.xml")]
        [InlineData("example_text_is_mixed_content.xml")]
        [InlineData("example_text_is_simple_string.xml")]
        public void ExampleExamplesPass(string filename)
        {
          Assert.True(IsValid(filename));
        }
                
        
        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\7_SenseTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}