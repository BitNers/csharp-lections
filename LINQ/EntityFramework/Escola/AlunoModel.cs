using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.EntityFramework.Escola
{
    [Table("Aluno")]
    internal class AlunoModel
    {
        [Key]
        public int AlunoId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }

        public List<MateriaModel>? Materias { get; set; }

    }
}
