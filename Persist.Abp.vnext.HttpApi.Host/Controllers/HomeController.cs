﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Persist.Abp.vnext.HttpApi.Host.Controllers
{
    public class HomeController : AbpController
    {
        public IActionResult Index()
        {
               return Redirect("~/swagger");
        }
    }
}
