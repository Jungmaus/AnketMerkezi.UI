using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AnketMerkezi.Business.Services;
using System.Security.Claims;
using AnketMerkezi.Business.RedisService;

namespace AnketMerkezi.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public ServiceProvider Service;
        public RedisServiceProvider RedisService;

        public BaseController()
        {
            this.Service = new ServiceProvider();
            this.RedisService = new RedisServiceProvider();
        }

        public string GetWebUserID()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
                return claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            else
                return "";
        }

    }
}