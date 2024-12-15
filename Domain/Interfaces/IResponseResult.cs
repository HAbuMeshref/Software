using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Interfaces
{
    public interface IResponseResult<T>
    {
        List<string> Errors { get; set; }
        List<object>? ExtraData { get; set; }
        ResultStatus Status { get; set; }
        T Data { get; set; }
        long TotalRecords { get; set; }
    }
}
