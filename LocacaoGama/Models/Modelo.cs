using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoGama.Models
{

    [Table("tb_modelos")]
    public class Modelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("nome", TypeName = "varchar(100)")]
        public string Nome { get; set; } = default!;

        public int MarcaId { get; set; } = default!;
        public Marca? Marca { get; set; }

    }
}
