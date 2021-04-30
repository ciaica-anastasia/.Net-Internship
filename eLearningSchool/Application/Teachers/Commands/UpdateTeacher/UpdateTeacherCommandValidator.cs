using FluentValidation;

namespace Application.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().LessThan(999);
            RuleFor(x => x.Email).NotEmpty(); //доп условия regexp
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty(); //доп условия regexp
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}