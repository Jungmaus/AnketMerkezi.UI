using AnketMerkezi.UI.Models.Managers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.VMs.Survey
{
    public class SurveyAdd
    {
        public SurveyAdd()
        {
                
        }

        public SurveyAdd(int a)
        {
            this.DrpContentDataType = DropdownManager.SurveyContentDataTypeDropdownList();
        }

        [Required(ErrorMessage = "Anket adı alanı gereklidir."), MaxLength(45, ErrorMessage = "Anket adı en fazla 45 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir."), MaxLength(300, ErrorMessage = "Açıklama en fazla 300 karakter olabilir.")]
        public string Description { get; set; }

        public List<SurveyAddContent> SurveyAddContents { get; set; }

        public List<SelectListItem> DrpContentDataType { get; set; }
    }
    
    public class SurveyAddContent
    {
        [Required(ErrorMessage = "Başlık alanı gereklidir."), MaxLength(45, ErrorMessage = "Başlık alanı en fazla 45 karakter olabilir.")]
        public string Title { get; set; }

        public int DataType { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
        public bool IsRequired { get; set; }
    }

}
