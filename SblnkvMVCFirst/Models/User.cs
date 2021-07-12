using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SblnkvMVCFirst.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Никнейм")]
        [MaxLength(250)]
        [Required (ErrorMessage=" Где никнейм?")]
        public string NickName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = " Где пароль?")]
        public string Password { get; set; }

        [Display(Name = "Имя")]
        public string Name {get;set;}

        [Display(Name = "О себе")]
        public string About { get; set; }

 
    }
}
