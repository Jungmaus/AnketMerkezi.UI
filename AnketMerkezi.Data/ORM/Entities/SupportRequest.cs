using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public  class SupportRequest : BaseEntity
    {
        public SupportRequest()
        {
            this.SupportRequestMessages = new List<SupportRequestMessage>();
        }

        public string Title { get; set; }
        public int SubjectType { get; set; }
        public int Status { get; set; }

        public int CreaterWebUserID { get; set; }

        [ForeignKey("CreaterWebUserID")]
        public virtual User User { get; set; }

        public virtual List<SupportRequestMessage> SupportRequestMessages { get; set; }
    }
}
