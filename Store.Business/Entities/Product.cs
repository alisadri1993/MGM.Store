namespace Store.Business.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string imageId { get; set; }

    }
}