using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoGama.Models
{

    [Table("tb_pedidos")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("id_cliente", TypeName = "varchar(100)")]
        public string IdCliente { get; set; }

        [Column("carro", TypeName = "varchar(100)")]
        public string Carro { get; set; }

        [Column("data_locacao", TypeName = "DateTime")]
        public DateTime DataLocacao { get; set; }

        [Column("data_entrega", TypeName = "DateTime")]
        public DateTime DataEntrega{ get; set; }

    }
}
