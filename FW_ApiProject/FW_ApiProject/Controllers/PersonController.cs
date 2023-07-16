using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using FW_ApiProject.Models;

namespace FW_ApiProject.Controllers;
public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.Name)
        .NotEmpty()
        .WithMessage("Staff person name is required.")
        .Length(5, 100)
        .WithMessage("Staff person name must be between 5 and 100 characters.");

        RuleFor(person => person.LastName)
       .NotEmpty()
       .WithMessage("Staff person lastname is required.")
       .Length(5, 100)
       .WithMessage("Staff person lastname must be between 5 and 100 characters.");

        RuleFor(person => person.Phone)
       .NotEmpty()
       .WithMessage("Staff person phone number is requied.")
       .Matches(@"^\d{10}$")
       .WithMessage("Staff person phone number must be a valid 10-digit phone number.");

        RuleFor(person => person.AccessLevel)
       .InclusiveBetween(1, 5)
       .WithMessage("Staff person access level must be between 1 and 5.");

        RuleFor(person => person.Status)
       .Must(person => person == "Junior" || person == "Mid" || person == "Senior")
       .WithMessage("Valid values: Junior, Mid, Senior");

        RuleFor(person => person.Salary)
       .NotEmpty()
       .WithMessage("Staff person salary is required.")
       .InclusiveBetween(5000, 50000)
       .WithMessage("Staff person salary must be between 5000 and 50000.")
       .Must((person, salary) => IsValidSalary(person.AccessLevel, salary)).WithMessage("Salary is not valid for the given access level.");
    }
    private bool IsValidSalary(int accessLevel, decimal salary)
    {
        switch(accessLevel)
        {
            case 1:
                return salary <= 2500;
            case 2:
                return salary <= 3500;
            case 3:
                return salary <= 4500;
            default:
                return false;
        }
    }
}


[ApiController]
[Route("fw/api/[controller]")]
public class PersonController:ControllerBase
{
    private readonly IValidator<Person> _personValidator;
    public PersonController(IValidator<Person> personValidator)
{
    _personValidator = personValidator;
}
[HttpPost]
public IActionResult Post([FromBody] Person person)
{
    FluentValidation.Results.ValidationResult validationResult = _personValidator.Validate(person);
    if(!validationResult.IsValid)
{
    foreach(ValidationFailure failure in validationResult.Errors)
    {
        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
    }
    return BadRequest(ModelState);
}
return Ok();
}            

}

    

