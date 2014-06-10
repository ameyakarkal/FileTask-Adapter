using Scripts.Validators;

namespace SsisTest
{
    using System;
    using Moq;
    using NUnit.Framework;
    using Scripts;

    [TestFixture]
    public class WhenValidatingFile
    {
        private IValidator _validator;

        private Mock<ISsisFileRequest> _mockFileProperties;
 
        [SetUp]
        public void SetUp()
        {
            _mockFileProperties = new Mock<ISsisFileRequest>();

            _validator = new Validator();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenFileHeaderIsEmpty()
        {
            _mockFileProperties.Setup(x => x.GetFileHeader()).Returns((string)null);
            
            _validator.Validate(_mockFileProperties.Object);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThowExceptionWhenInputFileIsEmpty()
        {
            _mockFileProperties.Setup(x => x.GetInputFilePath()).Returns((string)null);

            _validator.Validate(_mockFileProperties.Object);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenOutputFileIsEmpty()
        {
            _mockFileProperties.Setup(x => x.GetInputFilePath()).Returns((string)null);

            _validator.Validate(_mockFileProperties.Object);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenDuplicatesInHeader()
        {
            var stringWithDuplicateHeaders = string.Format("{0},{0}", "headertoken");

            _mockFileProperties.Setup(x => x.GetFileHeader()).Returns(stringWithDuplicateHeaders);

            _validator.Validate(_mockFileProperties.Object);
        }
    }
}