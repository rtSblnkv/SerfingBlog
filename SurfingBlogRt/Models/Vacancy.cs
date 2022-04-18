using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfingBlogRt.Models
{
    [Table("Vacancy")]
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Название*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Компания*")]
        public string Company { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Регион*")]
        public string Region { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Город*")]
        public string City { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(100, ErrorMessage = "Максимальная длина 100 символов")]
        [Display(Name = "Адрес*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [Display(Name = "Телефон*")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [Display(Name = "Эл.Почта*")]
        public string Email { get; set; }

        [MaxLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        [Display(Name = "Обязанности")]
        public string Obeys { get; set; }

        [MaxLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        [Display(Name = "Требования")]
        public string Requirements{ get; set; }

        [MaxLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        [Display(Name = "Условия")]
        public string Conditions { get; set; }
    }
}
