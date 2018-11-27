using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnketMerkezi.Data.ORM.Entities
{
    public class SurveyContent : BaseEntity
    {
        public SurveyContent()
        {
            this.SurveyVisitAnswers = new List<SurveyVisitAnswer>();
        }

        public string Title { get; set; }
        public int DataType { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
        public bool IsRequired { get; set; }

        public int SurveyID { get; set; }

        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        public virtual List<SurveyVisitAnswer> SurveyVisitAnswers { get; set; }
    }
}
