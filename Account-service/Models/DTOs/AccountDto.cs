﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace account_service.Models
{
    public class AccountDto
    {
        public string accountId { get; set; }
        public double balance { get; set; }
        public DateTime createdAt { get; set; }
        public string currency { get; set; }
        public string accountType { get; set; }
        public Customer customer { get; set; }
    }
}
