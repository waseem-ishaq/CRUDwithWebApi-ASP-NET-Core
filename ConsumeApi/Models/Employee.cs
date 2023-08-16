using System.ComponentModel.DataAnnotations;
using FluentValidation;
namespace ConsumeApi.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            Include(new EmployeeSimpleValidator());
            Include(new EmployeeSimpleValidator());
        }
    }
    public class EmployeeSimpleValidator : AbstractValidator<Employee>
    {
        public EmployeeSimpleValidator()
        {
            RuleFor(u => u.id).NotNull();
            RuleFor(u => u.name).NotNull().NotEmpty();
            RuleFor(u => u.age).NotNull().NotEmpty();
            RuleFor(u => u.gender).NotNull().NotEmpty();
        }

    }
    public class EmployeeComplexValidator : AbstractValidator<Employee>
    {
        public EmployeeComplexValidator()
        {
            RuleFor(u => u.name).Length(4, 60).WithMessage("Name length must be between 4 and 60 Characters");
            RuleFor(u => u.age).InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60");
            RuleFor(u => u.gender).Length(4,6).WithMessage("Gender must be Male or Female");
        }

    }
}
