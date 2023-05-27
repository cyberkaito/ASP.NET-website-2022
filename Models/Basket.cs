namespace BlueBlotRecords.Models
{
    public class Basket
    {
        public List<Band> band { get; set; }
        public List<Service> service { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
