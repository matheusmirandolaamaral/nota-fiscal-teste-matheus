using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nota_fiscal_teste.Model
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("quantity", TypeName = "bigint")]
        public long Quantity { get; set; }
    }
}
