using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnketMerkezi.UI.Models.Managers
{
    public static class DateManager
    {
        public static string FormatDate(DateTime dateTime)
        {
            return dateTime.ToString("dddd, MMMM dd");
        }
    }
}
