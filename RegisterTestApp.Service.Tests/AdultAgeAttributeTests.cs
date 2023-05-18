
using System.ComponentModel.DataAnnotations;

namespace RegisterTestApp.Service.Tests
{
    public class AdultAgeAttributeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsValid_ShouldReturnSuccess_WhenValueIsEqualToMinAllowedDate()
        {
            // Arrange
            var attribute = new AdultAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-18);

            // Act
            var result = attribute.IsValid(value, null);

            // Assert
            Assert.AreEqual(ValidationResult.Success, result);
        }

        [Test]
        public void IsValid_ShouldReturnSuccess_WhenValueIsGreaterThanMinAllowedDate()
        {
            // Arrange
            AdultAgeAttribute attribute = new AdultAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-19);

            // Act
            var result = attribute.IsValid(value, null);

            // Assert
            Assert.AreEqual(ValidationResult.Success, result);
        }

        [Test]
        public void IsValid_ShouldReturnValidationError_WhenValueIsLessThanMinAllowedDate()
        {
            // Arrange
            AdultAgeAttribute attribute = new AdultAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-17);

            // Act
            var result = attribute.IsValid(value, null);

            // Assert
            Assert.AreEqual("You should be at least 18 years old to use this app", result.ErrorMessage);
        }
    }
}