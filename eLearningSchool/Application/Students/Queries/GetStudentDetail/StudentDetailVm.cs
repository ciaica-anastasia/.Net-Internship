using System;
using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Students.Queries.GetStudentDetail
{
    public class StudentDetailVm : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int? StudentOverallStatusId { get; set; }

        public virtual List<StudentCourseRelationDto> Relations { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.StudentId))
                .ForMember(d => d.Relations, opts => opts.MapFrom(s => s.StudentCourseRelations));
        }
    }
}