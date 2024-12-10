using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.SedraPro.Models.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public string Name { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public string Family { get; set; } = null!;
        [Display(Name = "سن")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public int Age { get; set; }
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public string Gender { get; set; }
        [Display(Name = "انتخاب تصویر")]
        public IFormFile? Img { get; set; }

        public string? ImageUrl { get; set; }

    }
}
