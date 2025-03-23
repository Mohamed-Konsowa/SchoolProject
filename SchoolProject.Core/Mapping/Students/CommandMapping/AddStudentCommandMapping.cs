using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMaping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(sour => sour.DepartmentId));
        }
    }
}
