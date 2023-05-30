namespace Corbae.BLL.Enums
{
    public static class OrderStatusEnum
    {
        public enum Status
        {
            Created = 1,
            AwatingPayment = 2,
            Paid = 3,
            InAssembly = 4,
            Sent = 5,
            Delivered = 6,
            Accepted = 7,
            Canceled = 8
        }
    }
}
