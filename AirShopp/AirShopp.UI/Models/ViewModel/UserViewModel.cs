using AirShopp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirShopp.UI.Models.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberPwd { get; set; }
        public bool Gender { get; set; }
        public string CustomerName { get; set; }
        public string TelephoneNo { get; set; }
        public string QuestionA { get; set; }
        public string AnswerA { get; set; }
        public string QuestionB { get; set; }
        public string AnswerB { get; set; }

        public Customer toCustomer()
        {
            return new Customer()
            {
                Account = this.UserName,
                Password = this.Password,
                CustomerName = this.CustomerName,
                TelephoneNo = this.TelephoneNo,
                QuestionA = this.QuestionA,
                QuestionB = this.QuestionB,
                AnswerA = this.AnswerA,
                AnswerB = this.AnswerB,
                Gender = this.Gender,
                LastSignInTime = DateTime.Now,
            };
        }
    }
}