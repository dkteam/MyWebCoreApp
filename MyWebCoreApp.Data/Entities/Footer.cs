using MyWebCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebCoreApp.Data.Entities
{
    [Table("Footers")]
    public class Footer : DomainEntity<int>
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { set; get; }
    }
}