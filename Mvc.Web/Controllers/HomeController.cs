using System;
using System.Web.Mvc;
using Mvc.Common.Service;

namespace Mvc.Web.Controllers
{
    [RoutePrefix("")]
    public class HomeController : ControllerBase
    {
        public HomeController(IAppService appService) : 
            base(appService)
        {
        }

        [Route("")]
        public ActionResult Index()
        {
            throw new Exception("Test");
            return View();
        }
    }
}