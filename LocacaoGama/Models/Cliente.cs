using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocacaoGama.Models
{

    [Table("tb_clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column("email", TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column("telefone", TypeName = "varchar(100)")]
        public string Telefone { get; set; }

        [Column("endereco", TypeName = "varchar(100)")]
        public string Endereco { get; set; }

    }
}
