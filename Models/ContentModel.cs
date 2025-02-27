using SabayNew.Dal;
using System.ComponentModel.DataAnnotations;

namespace SabayNew.Models
{
    public class ContentModel
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }

        public string? Tiltle { get; set; }

        public string? ImageUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public CategoryModel categoryModel { get; set; }
        public UserLoginModel userLoginModel { get; set; }

    }
}
