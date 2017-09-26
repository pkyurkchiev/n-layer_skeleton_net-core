namespace NTS.Website.Controllers.Shared
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}