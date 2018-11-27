using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class Survey : BaseEntity
    {
        public Survey()
        {
            this.SurveyContents = new List<SurveyContent>();
            this.SurveyVisits = new List<SurveyVisit>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkCode { get; set; }
        public bool IsActive { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public virtual List<SurveyContent> SurveyContents { get; set; }
        public virtual List<SurveyVisit> SurveyVisits { get; set; }
    }
}
