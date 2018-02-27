using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArtareaNew.Models
{
    public class RegisterModel
    {
        [Display(Name = "სახელი")]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი სახელი")]
        public string Username { get; set; }

        [Display(Name = "ელ-ფოსტა")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი ელ.ფოსტა")]
        [StringLength(50, ErrorMessage = "ჩაწერილი ელ.ფოსტა არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "გთხოვთ ჩაწეროთ სწორედ ელ.ფოსტის მისამართ")]
        [EmailAddress(ErrorMessage = "ელ.ფოსტის ფორმატი არასწორია")]
        public string Email { get; set; }

        [Display(Name = "პაროლი")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "გთხოვთ, ჩაწერეთ თქვენი პაროლი")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 6 სიმბოლოსგან და მაქსიმუმ 30 სიმბოლოსგან")]
        public string Password { get; set; }



        [Display(Name = "გაიმეორე პაროლი")]
        [Compare("Password", ErrorMessage = "პაროლები არ ემთხვევა")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "პაროლი უნდა შედგებოდეს მინიმუმ 6 სიმბოლოსგან და მაქსიმუმ 30 სიმბოლოსგან")]
        [Required(ErrorMessage = "გთხოვთ, გაიმეორეთ თქვენი პაროლი")]
        public string RepeatPassword { get; set; }
       

       
    }
}