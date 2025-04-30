using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // .None
        public int DID { get; set; }
        [StringLength(500)]
        public string? DNameAr { get; set; }
        [StringLength(200)]
        public string? DNameEn { get; set; }
        public int? InsManagerId { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManagerId))]
        [InverseProperty("DepartmentManaged")]
        public Instructor? Manager { get; set; }
    }
}
