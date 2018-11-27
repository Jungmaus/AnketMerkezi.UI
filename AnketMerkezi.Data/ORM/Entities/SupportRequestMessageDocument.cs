using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class SupportRequestMessageDocument : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int SupportRequestMessageID { get; set; }

        [ForeignKey("SupportRequestMessageID")]
        public virtual SupportRequestMessage SupportRequestMessage { get; set; }
    }
}
