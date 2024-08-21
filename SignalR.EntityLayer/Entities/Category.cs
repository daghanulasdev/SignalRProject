namespace SignalR.EntityLayer.Entities
{
    public class Category
    { 
        //primary key değeri int olduğu için 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }
    }
}
