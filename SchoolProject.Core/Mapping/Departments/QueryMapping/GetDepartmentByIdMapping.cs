using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void AddGetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(g => g.Id, opt => opt.MapFrom(d => d.DID))
                .ForMember(g => g.Name, opt => opt.MapFrom(d => d.Localize( d.DNameAr, d.DNameEn)))
                .ForMember(g => g.ManagerName, opt => opt.MapFrom(d => d.Manager.Localize(d.Manager.NameAr, d.Manager.NameEn)))
                .ForMember(g => g.SubjectList, opt => opt.MapFrom(d => d.DepartmentSubjects))
                .ForMember(g => g.InstructorList, opt => opt.MapFrom(d => d.Instructors));
            
            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(sr => sr.Id, opt => opt.MapFrom(d => d.DID))
                .ForMember(sr => sr.Name, opt => opt.MapFrom(d => d.Localize(d.Subject.SubjectNameAr, d.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(sr => sr.Id, opt => opt.MapFrom(i => i.InsId))
                .ForMember(ir => ir.Name, opt => opt.MapFrom(i => i.Localize(i.NameAr, i.NameEn)));

        }
    }
}
