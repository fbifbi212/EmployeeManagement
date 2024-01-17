using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
    }
}
