using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class SurveyVisit : BaseEntity
    {
        public SurveyVisit()
        {
            this.SurveyVisitAnswers = new List<SurveyVisitAnswer>();
        }

        public string IpAdress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public int DeviceType { get; set; }

        public int SurveyID { get; set; }

        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        public virtual List<SurveyVisitAnswer> SurveyVisitAnswers { get; set; }
    }
}
