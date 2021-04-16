using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Persist.Abp.vnext.Controllers
{
    public class LoginController : AbpController
    {
        public IActionResult Index()
        {
            return Content("Hello World");
        }
    }
}
