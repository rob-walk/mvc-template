using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Mvc.Common.Service;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace Mvc.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly IAppService AppService;

        protected ControllerBase(IAppService appService)
        {
            AppService = appService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Environment = AppService.Configuration.Environment;
            ViewBag.Version = AppService.Configuration.Version;
            ViewBag.VersionFormatted = "v" + AppService.Configuration.Version;

            base.OnActionExecuting(filterContext);
        }

        public IEnumerable<string> GetModelErrors(ModelStateDictionary dictionary)
        {
            return (from modelState in dictionary.Values from error in modelState.Errors select error.ErrorMessage).ToList();
        }
    }
}