using Microsoft.AspNetCore.Mvc;
using Moq;
using RegisterTestApp.Service;
using RegisterTestApp.Service.Dto;
using RegisterTestApp.UI.Controllers;

namespace RegisterTestApp.UI.Tests
{
    public class RegisterControllerTests
    {
        private RegisterController _registerController;
        private Mock<IRegistrationService> _registrationServiceMock;

        [SetUp]
        public void Setup()
        {
            _registrationServiceMock = new Mock<IRegistrationService>();
            _registerController = new RegisterController(_registrationServiceMock.Object);
        }

        [Test]
        public async Task Post_ValidModel_ReturnsOkResult()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            RegistrationModel validModel = new RegistrationModel
            {
                DateOfBirth = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddYears(-1), 
                                                               
            };

            _registrationServiceMock.Setup(x => x.AddRequest(validModel)).ReturnsAsync(1);
            _registrationServiceMock.Setup(x => x.GetById(1)).ReturnsAsync(validModel);

            // Act
            IActionResult result = await _registerController.Post(validModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            OkObjectResult okResult = (OkObjectResult)result;
            Assert.AreEqual(validModel, okResult.Value);
        }

        [Test]
        public async Task Post_UnderageModel_ReturnsBadRequest()
        {
            // Arrange
            const int MinimumAllowedAge = 18;
            RegistrationModel underageModel = new RegistrationModel
            {
                DateOfBirth = DateTime.Now.Date.AddYears(-MinimumAllowedAge).AddYears(1), 
                                                               
            };

            // Act
            IActionResult result = await _registerController.Post(underageModel);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            BadRequestObjectResult badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual("You should be at least 18 years old to use this app", badRequestResult.Value);
        }
    }
}