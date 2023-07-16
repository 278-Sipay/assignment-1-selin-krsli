# Assignment-1 Fluent Validation
## What is Fluent Validation?

* FluentValidation is a .NET library for validating objects using a fluent API. It allows you to define validation rules for your objects in a  simple and expressive way, using a syntax that reads like natural language.

## Appendix
* The validations in the Person class will be rearranged using the FluentValidation library. POST method attributes on the controller will be arranged to work with FluentValidation in place. Only 1 controller and 1 method will be delivered within the project.

 ``` C#
public class Person
{
    [DisplayName("Staff person name")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Name { get; set; }


    [DisplayName("Staff person lastname")]
    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Lastname { get; set; }


    [DisplayName("Staff person phone number")]
    [Required]
    [Phone]
    public string Phone { get; set; }


    [DisplayName("Staff person access level to system")]
    [Range(minimum: 1, maximum: 5)]
    [Required]
    public int AccessLevel { get; set; }



    [DisplayName("Staff person salary")]
    [Required]
    [Range(minimum: 5000, maximum: 50000)]
    [SalaryAttribute]
    public decimal Salary { get; set; }
}
```
## Project's content
* This project was created as an Asp.Net Core 6.0 Web Api project with Visual Studio 2022, and there is 1 controller and 1 model in the project.

## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

