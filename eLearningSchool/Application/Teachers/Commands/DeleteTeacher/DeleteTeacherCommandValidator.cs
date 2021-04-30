using FluentValidation;

namespace Application.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().LessThan(999);
        }
    }
}