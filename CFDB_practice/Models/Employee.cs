using System.ComponentModel.DataAnnotations;

namespace CFDB_practice.Models
{
    public class Employee
    {
         
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public int Id { get; set; }
        public virtual Department? Department { get; set; }
    
    }
}
