﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirShopp.Domain
{
    public class Customer
    {
        public Customer()
        {
            RegisterDate = DateTime.Now;
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }
        public long Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string TelephoneNo { get; set; }
        public string QuestionA { get; set; }
        public string AnswerA { get; set; }
        public string QuestionB { get; set; }
        public string AnswerB { get; set; }
        public bool Gender { get; set; }
        public int CustomerScore { get; set; }
        public string LastSignInIpAddr { get; set; }
        public DateTime LastSignInTime { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
