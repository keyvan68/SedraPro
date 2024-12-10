using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.SedraPro.Models.ViewModels
{
    public class UserDeailViewModel
    {
        [Display(Name = "سن")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public int Age { get; set; }
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "{0} اجباری است.")]
        public string Gender { get; set; }
    }
}
