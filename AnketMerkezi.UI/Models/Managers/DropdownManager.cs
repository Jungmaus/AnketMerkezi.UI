using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.Managers
{
    public static class DropdownManager
    {
        public static List<SelectListItem> SurveyContentDataTypeDropdownList()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Selected = true, Disabled = true, Text = "Seçiniz" }, new SelectListItem { Value = "0", Text = "Metin" }, new SelectListItem { Value = "1", Text = "Seçim Kutusu" }, new SelectListItem { Value = "2", Text = "Sayı-Tutar" } };
        }

    }
}
