using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.VMs.Survey
{
    public class SurveyIndexVM
    {
        public int ID { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int AnswerCount { get; set; }
        public DateTime AddDate { get; set; }
        public string AddDateText { get; set; }
        public bool IsActive { get; set; }
    }
}
