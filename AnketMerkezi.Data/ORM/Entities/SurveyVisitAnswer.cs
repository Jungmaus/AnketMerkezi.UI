using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class SurveyVisitAnswer : BaseEntity
    {
        public string Content { get; set; }

        public int SurveyVisitID { get; set; }
        public int SurveyContentID { get; set; }

        [ForeignKey("SurveyVisitID")]
        public virtual SurveyVisit SurveyVisit { get; set; }

        [ForeignKey("SurveyContentID")]
        public virtual SurveyContent SurveyContent { get; set; }
    }
}
