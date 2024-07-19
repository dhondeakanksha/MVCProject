using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class DesignationGrade
    {
        [Key]
        public int GradeIdRef { get; set; }

        [Required]
        public string ? GradeName { get; set; }

        [ForeignKey("Designation")]
        public int DesignationIdRef { get; set; }
        public Designation ? Designation { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
