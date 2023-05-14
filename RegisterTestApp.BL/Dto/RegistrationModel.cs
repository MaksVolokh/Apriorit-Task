using RegisterTestApp.Service.Attributes;

namespace RegisterTestApp.Service.Dto
{
    public class RegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] PhoneNumbers { get; set; }

        [AdultAge]
         public DateTime DateOfBirth { get; set; }
    }
}
