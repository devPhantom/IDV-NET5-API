using System;
using System.Collections.Generic;

namespace frontWeb.Models.ViewModel
{
    public class AccountModel
    {
        public AccountModel()
        {
            OrderList = new List<Order>();
        }

        public User User { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
