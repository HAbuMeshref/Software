using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Domain.Common
{
    public class ResponseResult<T> : IResponseResult<T>
    {
        public List<string> Errors { get; set; }
        public ResultStatus Status { get; set; }
        public T Data { get; set; }
        public long TotalRecords { get; set; }
        public List<object>? ExtraData { get; set; }
    }
}
