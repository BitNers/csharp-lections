using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ.EntityFramework.Escola
{
    [Table("Materias")]
    internal class MateriaModel
    {
        [Key]
        public int MateriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        public List<AlunoModel>? Alunos { get; set; }

    }
}
