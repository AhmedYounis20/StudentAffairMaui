
using FluentValidation;
using System.Text.RegularExpressions;

namespace StudentAffairMaui;

public class TeacherValidator : BaseSettingValidator<Student>
{
    public TeacherValidator()
    {
        RuleFor(e => e.Birthdate).NotEmpty().WithMessage("Please Enter your birthdate");
        RuleFor(e => e.Phone).NotEmpty().WithMessage("Please Enter your Phone like:0101-234-2344.");
        RuleFor(e => e.Phone).Matches(new Regex("^[0-9]{11}$"));
        RuleFor(e => e.Birthdate).GreaterThan(new DateTime(1960));
    }
}
