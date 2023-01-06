using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocacaoGama.Models
{
    [Table("tb_configuracoes")]
    public class Configuracao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; } = default!;

        public int diasDeLocacao { get; set; } = default!;
    }
}
