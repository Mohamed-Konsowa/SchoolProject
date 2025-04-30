using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            SupervisedInstructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int DID {  get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? Department { get; set; }


        [InverseProperty("Manager")]
        public Department? DepartmentManaged { get; set; }

        public int? SuperVisorId { get; set; }

        [ForeignKey(nameof(SuperVisorId))]
        [InverseProperty(nameof(SupervisedInstructors))]
        public Instructor? SuperVisor { get; set; }


        [InverseProperty(nameof(SuperVisor))]
        public virtual ICollection<Instructor> SupervisedInstructors { get; set; }


        [InverseProperty("Instructor")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
