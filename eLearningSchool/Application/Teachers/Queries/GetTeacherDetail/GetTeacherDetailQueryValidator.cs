using FluentValidation;

namespace Application.Teachers.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQueryValidator : AbstractValidator<GetTeacherDetailQuery>
    {
        public GetTeacherDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().LessThan(999); //изменить возможно
        }
    }
}