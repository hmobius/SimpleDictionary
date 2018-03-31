using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class SampleValidXml
    {
        [Theory]
        [InlineData("MinimumPassingDoc.xml")]
        [InlineData("DefinitionExampleReference.xml")]
        [InlineData("AllPassingFeatures.xml")]
        public void AllSamplesAreValid(string filename)
        {
            Assert.True(IsValid(filename));
        }
        
        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\0_SampleValidXml");
            return val.DictionaryTest(xmlFileName, true);
        }
    }
}