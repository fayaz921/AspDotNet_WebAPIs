using AspDotNetCore_WebAPIs.Dtos.Authentication;
using FluentValidation;

namespace AspDotNetCore_WebAPIs.Validator.UserValidator
{
    public class UserRegisterDtoValidators : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidators()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("First Name Required")
                .MaximumLength(20).WithMessage("First Name Must be 20 Charecter ")
                .Matches("^[a-zA-Z]+$").WithMessage("First Name Only contain Aplhabate");
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Last Name Required")
                .MaximumLength(20).WithMessage("Last Name Must be 20 Character")
                .Matches("^[a-zA-Z]+$").WithMessage("Last Name Contains Only Alphabate ");
            RuleFor(u => u.Contact)
                .NotEmpty().WithMessage("Contact Required")
                .Matches("^[0-9]+$").WithMessage("Contact Must be Digits")
                .Length(11).WithMessage("Contact length Must be 11 Digits ");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email Required")
                .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Username Required");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password Required");
                //.MinimumLength(6).WithMessage("Password Minimum Length is 6 Character")
                //.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                //.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                //.Matches("[0-9]").WithMessage("Password must contain at least one digit")
                //.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

        }
    }
}
