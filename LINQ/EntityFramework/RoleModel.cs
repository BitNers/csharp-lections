using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ.EntityFramework
{
    [Table("Roles")]
    internal class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
