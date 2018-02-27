using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtareaNew.Models
{
    public class LoginModel
    {

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ელ.ფოსტა")]
        [EmailAddress(ErrorMessage = "ელ.ფოსტის ფორმატი არასწორია")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პაროლი")]
        public string Password { get; set; }
    }
}