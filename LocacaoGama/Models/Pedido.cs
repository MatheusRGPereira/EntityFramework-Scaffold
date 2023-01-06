using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocacaoGama.Models
{
    [Table("tb_pedidos")]
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        public int ClienteId { get; set; } = default!;
        public Cliente? Cliente { get; set; }

        public int CarroId { get; set; } = default!;
        public Carro? Carro { get; set; }



        public DateTime DataLocacao { get; set; } = default!;
        public DateTime DataEntrega { get; set; } = default!;
    }
}
