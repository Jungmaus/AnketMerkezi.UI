using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class SupportRequestMessage : BaseEntity
    {
        public SupportRequestMessage()
        {
            this.SupportRequestDocuments = new List<SupportRequestMessageDocument>();
        }

        public string Content { get; set; }

        public int SupportRequestID { get; set; }
        public int WebUserID { get; set; }

        [ForeignKey("WebUserID")]
        public virtual User User { get; set; }

        [ForeignKey("SupportRequestID")]
        public virtual SupportRequest SupportRequest { get; set; }

        public virtual List<SupportRequestMessageDocument> SupportRequestDocuments { get; set; }
    }
}
