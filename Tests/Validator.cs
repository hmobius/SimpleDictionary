using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;

namespace SimpleDictionary
{
    public class Validator
    {
        private StringBuilder ErrorLog { get; set; }
        public string xmlFolderName { get; set; }

        public Validator(string folder)
        {
            xmlFolderName = folder;
        }

        public bool DictionaryTest(string xmlDocumentName)
        {
            return DictionaryTest(xmlDocumentName, false);
        }

        public bool DictionaryTest(string xmlDocumentName, bool showLog)
        {
            string workingDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\.."));
            
            return Test(
                Path.Combine(workingDirectory, xmlFolderName, xmlDocumentName), 
                Path.Combine(workingDirectory, "schema", "SimpleDictionary.xsd"),  
                "urn:Simple-Dictionary-Mono",
                showLog);
        }

        private bool Test(string xmlToTestLocation, string schemaLocation, string targetNamespace, bool showLog)
        {
            // Create the XmlSchemaSet class.
            XmlSchemaSet sc = new XmlSchemaSet();
            ErrorLog = new StringBuilder();

            // Add the schema to the collection.
            sc.Add(targetNamespace, schemaLocation);

            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create(xmlToTestLocation, settings);

            // Parse the file. 
            while (reader.Read()) ;

            if (ErrorLog.ToString() != String.Empty)
            {
                if (showLog)
                {
                    Console.Write(ErrorLog.ToString());
                }
                return false;
            }

            return true;
        }

        // Display any validation errors.
        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            ErrorLog.AppendFormat("Validation Error: {0}", e.Message ?? "Random fail").AppendLine();
        }
    }

}
