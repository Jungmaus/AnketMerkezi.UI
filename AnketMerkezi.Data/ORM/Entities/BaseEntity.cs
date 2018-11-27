using System;
using System.Collections.Generic;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddDate { get; set; }
    }
}
