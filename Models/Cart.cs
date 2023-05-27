namespace BlueBlotRecords.Models
{
    public class Cart{
        public List<Service> items { get; set; }
        public Cart()
        {
            items = new List<Service>(); 
        }
        
        public decimal finalPrice
        {
            get
            {
                decimal sum = 0;
                foreach (Service item in items)
                {
                    sum += item.Price;
                }
                return sum;
            }
        }
    }
}
