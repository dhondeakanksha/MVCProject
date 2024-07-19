using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Designation
    {
        [Key]
        public int DesignationIdRef { get; set; }

        [Required]
        public string ? DesignationName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
