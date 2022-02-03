namespace Store.Business.Entities
{
    public class Product
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public int price { get; set; }

    }
}