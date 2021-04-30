using FluentValidation;

namespace Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().LessThan(999);
            RuleFor(x => x.Email).NotEmpty(); //доп условия
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty(); //доп условия
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}