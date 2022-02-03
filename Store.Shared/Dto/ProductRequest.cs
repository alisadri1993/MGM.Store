using System.ComponentModel.DataAnnotations;

namespace Store.Shared.Dto
{
    public class ProductRequest
    {
        public string name { get; set; }

        [Range(10,50,ErrorMessage ="در بازه قابل قبول نیست")]
        public int limit { get; set; }

        [Range(0,int.MaxValue,ErrorMessage ="منفی نباشد")]
        public int offset { get; set; }
    }
}
