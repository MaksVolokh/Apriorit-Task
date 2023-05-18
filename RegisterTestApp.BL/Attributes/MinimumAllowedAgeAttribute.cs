using System.ComponentModel.DataAnnotations;


namespace RegisterTestApp.Service.Attributes;

/// <summary>
///  Validation DateTime field using attribute.
/// </summary>
public class MinimumAllowedAgeAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        const int MinimumAllowedAge = 18;
        DateTime minAllowedDate = DateTime.Now.Date.AddYears(-MinimumAllowedAge);

        if (Convert.ToDateTime(value) > minAllowedDate)
        {
            ErrorMessage = "You should be at least 18 years old to use this app";
            return false;
        }

        return true;
    }
}
