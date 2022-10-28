
using System.ComponentModel.DataAnnotations.Schema;

namespace Sazman.DataModels.Models
{
    public class BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
