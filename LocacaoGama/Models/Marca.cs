using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoGama.Models
{

    [Table("tb_marcas")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column("nome", TypeName = "varchar(100)")]
        public string? Nome { get; set; }

    }
}
