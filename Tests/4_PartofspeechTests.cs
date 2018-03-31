using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{ 
    public class PartOfSpeechTests
    {
        [Theory]
        [InlineData("pos_is_empty.xml")]
        [InlineData("pos_multiples_with_correct_postype.xml")]
        [InlineData("pos_multiples_with_correct_posqualifier.xml")]
        public void ValidPartOfSpeech_passes(string filename)
        {
            Assert.True(IsValid(filename));
        }

        [Theory]
        [InlineData("pos_without_postype.xml")]
        [InlineData("pos_with_incorrect_postype.xml")]
        [InlineData("pos_with_incorrect_posqualifier.xml")]
        public void InvalidPartOfSpeech_fails(string filename)
        {
            Assert.False(IsValid(filename));
        }
                                        
        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\4_Partofspeechtests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}