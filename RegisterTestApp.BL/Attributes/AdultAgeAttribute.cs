using System.ComponentModel.DataAnnotations;


namespace RegisterTestApp.Service.Attributes;

/// <summary>
///  Validation DateTime field using attribute.
/// </summary>
public class AdultAgeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime minAllowedDate = DateTime.Now.Date.AddYears(-18);

        if (Convert.ToDateTime(value) > minAllowedDate)
        {
            return new ValidationResult("You should be at least 18 years old to use this app");
        }

        return ValidationResult.Success;

    }
}
