using System.ComponentModel.DataAnnotations;

namespace Store.Shared.Dto
{
    public class ProductDto
    {
        [Required(ErrorMessage ="فیلد نام ضروری است")]
        public string name { get; set; }

        [Range(10,100,ErrorMessage ="تعداد در بازه مورد نظر نیست")]
        public int qty { get; set; }

        [Range(0,int.MaxValue,ErrorMessage ="قیمت نمی تواند منفی باشد")]
        public int price { get; set; }

    }
}