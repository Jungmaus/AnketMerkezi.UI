using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnketMerkezi.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        public IActionResult Index() => View();

    }
}