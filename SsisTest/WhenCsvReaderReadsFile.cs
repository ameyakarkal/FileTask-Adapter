using System;
using System.IO;
using Moq;
using NUnit.Framework;
using Scripts;
using Scripts.Builder;
using Scripts.Reader;
using Scripts.Validators;

namespace SsisTest
{
    [TestFixture]
    public class WhenCsvReaderReadsFile
    {
        protected const string SimpleFileHeader = "headertoken01,headertoken02,headertoken03,headertoken04";

        protected const string DoNotCare = null;

        protected string SimpleFileAbsoluteInputPath { get; set; }

        protected string SimpleFileAbsoluteOutputPath { get; set; }

        protected ISsisCsvReader Reader { get; set; }

        [SetUp]
        public void SetUp()
        {
            SimpleFileAbsoluteInputPath = Path.GetFullPath(@"..\..\Files\SimpleInputFile.txt");
            
            SimpleFileAbsoluteOutputPath = Path.Combine(Path.GetDirectoryName(SimpleFileAbsoluteInputPath), "SimpleOutputFile.txt");

            var mockValidator = new Mock<IValidator>();
            
            mockValidator.Setup(validator => validator.Validate(It.IsAny<ISsisFileRequest>())).Returns(Validation.Success);

            var mockHeaderBuilder = new Mock<IHeaderBuilder>();

            Reader = new SsisSsisCsvReader(mockValidator.Object, mockHeaderBuilder.Object);
        }

        [Test]
        public void ShouldReadRowCorrectly()
        {
            var request = new SsisFileRequest(SimpleFileAbsoluteInputPath, SimpleFileAbsoluteOutputPath, SimpleFileHeader);
            

        }
    }
}