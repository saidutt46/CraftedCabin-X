namespace Core.ViewrRequests
{
    public class AddProductInventoryModel
	{
        public required int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}