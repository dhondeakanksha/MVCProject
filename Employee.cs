using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace MVCProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
 
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey("Designation")]
        public int DesignationIdRef { get; set; }

        public virtual Designation Designation { get; set; }

        [Required]
        [ForeignKey("DesignationGrade")]
        public int GradeIdRef { get; set; }

        public virtual DesignationGrade Grade { get; set; }
    }
}
