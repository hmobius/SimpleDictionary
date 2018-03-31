using System;
using System.Xml;
using Xunit;

namespace SimpleDictionary
{
    public class ImageTests
    {
        [Theory]
        [InlineData("images_is_empty.xml")]
        [InlineData("images_is_mixed_content.xml")]
        [InlineData("images_is_duplicated.xml")]
        public void ImagesExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("image_not_empty.xml")]
        [InlineData("image_missing_filename.xml")]
        public void ImageExamplesFail(string filename)
        {
            Assert.False(IsValid(filename));
        }
        
        [Theory]
        [InlineData("image_is_valid.xml")]
        [InlineData("image_is_duplicated.xml")]
        public void ImageExamplesPass(string filename)
        {
            Assert.True(IsValid(filename));
        }



        private bool IsValid(string xmlFileName)
        {
            Validator val = new Validator("Tests\\9_ImageTests");
            return val.DictionaryTest(xmlFileName);
        }
    }
}