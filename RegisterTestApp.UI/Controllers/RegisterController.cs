using Microsoft.AspNetCore.Mvc;

using RegisterTestApp.Service;
using RegisterTestApp.Service.Dto;

namespace RegisterTestApp.UI.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegisterController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(RegistrationModel model)
    {
        // Validation request model inside controller. (there is another validation based on attributes)
        // both are valid, and may be used any
        const int MinimumAllowedAge = 18;
        DateTime minAllowedDate = DateTime.Now.Date.AddYears(-MinimumAllowedAge);

        var isAdult = model.DateOfBirth > minAllowedDate;

        if (isAdult)
        {
            return BadRequest("You should be at least 18 years old to use this app");
        }

        var id = await _registrationService.AddRequest(model);
        return Ok(await _registrationService.GetById(id));
    }
}
