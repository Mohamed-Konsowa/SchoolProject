
namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
        //public GetStudentPaginatedListResponse(int id, string name, string address, string deptName)
        //{
        //    StudID = id;
        //    Name = name;
        //    Address = address;
        //    DepartmentName = deptName;
        //}
    }
}
