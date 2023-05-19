using RegisterTestApp.Service.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RegisterTestApp.Service.Tests
{
    public class MinimumAllowedAgeAttributeTests
    {

        [Test]
        public void IsValid_ShouldReturnSuccess_WhenValueIsEqualToMinAllowedDate()
        {

            // Arrange
            const int MinimumAllowedAge = 18;
            MinimumAllowedAgeAttribute eighteenYearsOld = new MinimumAllowedAgeAttribute();

            DateTime value = DateTime.Now.Date.AddYears(-MinimumAllowedAge);

            // Act
            bool result = eighteenYearsOld.IsValid(value);

            // Assert
            Assert.True(result);
            Assert.AreEqual(null, eighteenYearsOld.ErrorMessage);

        }

        [Test]
        public void IsValid_ShouldReturnSuccess_WhenValueIsGreaterThanMinAllowedDate()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            MinimumAllowedAgeAttribute eighteenYearsOld = new MinimumAllowedAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddYears(-1);

            // Act
            bool result = eighteenYearsOld.IsValid(value);

            // Assert
            Assert.True(result);
            Assert.AreEqual(null, eighteenYearsOld.ErrorMessage);
        }

        [Test]
        public void IsValid_ShouldReturnValidationError_WhenValueIsLessThanMinAllowedDate()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            MinimumAllowedAgeAttribute eighteenYearsOld = new MinimumAllowedAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddYears(1);

            // Act
            bool result = eighteenYearsOld.IsValid(value);

            // Assert
            Assert.False(result);
            Assert.AreEqual("You should be at least 18 years old to use this app", eighteenYearsOld.ErrorMessage);
        }

        [Test]
        
        public void IsValid_ShouldReturnSuccess_WhenCriticalValueIsGreaterThanMinAllowedDate()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            MinimumAllowedAgeAttribute eighteenYearsOld = new MinimumAllowedAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddSeconds(-10.0);

            // Act
            bool result = eighteenYearsOld.IsValid(value);

            // Assert
            Assert.True(result);
            Assert.AreEqual(null, eighteenYearsOld.ErrorMessage);
        }

        [Test]
        public void IsValid_ShouldReturnValidationError_WhenCriticalValueIsLessThanMinAllowedDate()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            MinimumAllowedAgeAttribute eighteenYearsOld = new MinimumAllowedAgeAttribute();
            DateTime value = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddSeconds(10.0);

            // Act
            bool result = eighteenYearsOld.IsValid(value);

            // Assert
            Assert.False(result);
            Assert.AreEqual("You should be at least 18 years old to use this app", eighteenYearsOld.ErrorMessage);
        }
    }
}