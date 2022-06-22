namespace EventBus.Messages.Events
{
    public class ProductAddedEvent : IntegrationBaseEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}