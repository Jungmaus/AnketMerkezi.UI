using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.UserDetails = new List<UserDetail>();
            this.Surveys = new List<Survey>();
            this.SupportRequests = new List<SupportRequest>();
            this.UserOrders = new List<UserOrder>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int AccountType { get; set; }

        public virtual List<UserDetail> UserDetails { get; set; }
        public virtual List<Survey> Surveys { get; set; }
        public virtual List<SupportRequest> SupportRequests { get; set; }
        public virtual List<UserOrder> UserOrders { get; set; }
    }
}
