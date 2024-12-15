using System.Text.Json.Serialization;

namespace InventoryManagement.Domain.Common
{
    public class SelectItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? label { get; set; }
        public string? value { get; set; }
 
    }
}
