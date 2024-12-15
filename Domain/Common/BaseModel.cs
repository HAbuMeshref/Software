
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Domain.Common
{
    public class BaseModel
    {
        //[Required]
        [Column("CREATION_USER")]
        public string CreationUser { get; set; }

        [Column("CREATION_DATE")]
        public string CreationDate { get; set; }

        [Column("MODIFICATION_USER")]
        public string? ModificationUser { get; set; }

        [Column("MODIFICATION_DATE")]
        public string? ModificationDate { get; set; }

        public int Id { get; set; }
    }
}
