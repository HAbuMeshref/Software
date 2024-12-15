namespace InventoryManagement.Domain.Enums
{
    public static class ResourceObject
    {
        public static readonly string Messages = "Messages";

    }
 
    public enum ResultStatus
    {
        Failed = 0,
        Success = 1,
        SuccessWithRedirect = 2,
        SuccessWithWarning = 3,
    }
 
}
