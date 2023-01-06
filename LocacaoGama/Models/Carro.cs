using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoGama.Models
{

    [Table("tb_carros")]
    public class Carro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nome", TypeName = "varchar(50)")]
        public string Nome { get; set; }

        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }

        public int ModeloId { get; set; }
        public Modelo? Modelo { get; set; }


    }
}
