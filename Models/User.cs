// namespace UserManagementAPI.Models
// {
//     public class User
//     {
//         public int Id { get; set; }
//         public string Name { get; set; } = "";
//         public string Email { get; set; } = "";
//         public int Age { get; set; }
//     }
// }

using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }
    }
}