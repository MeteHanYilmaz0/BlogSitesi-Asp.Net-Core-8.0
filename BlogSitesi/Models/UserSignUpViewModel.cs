using System.ComponentModel.DataAnnotations;

namespace BlogSitesi.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad-Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz.")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }



        [Display(Name = "Şifre tekrarı")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen mail giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adı giriniz.")]
        public string Username { get; set; }

    }
}
