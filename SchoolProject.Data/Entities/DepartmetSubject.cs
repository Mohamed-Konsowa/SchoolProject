using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities
{
    public class DepartmetSubject : GeneralLocalizableEntity
    {
        [Key]
        public int DID { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }

        [ForeignKey("SubID")]
        public virtual Subject? Subject { get; set; }
    }
}
