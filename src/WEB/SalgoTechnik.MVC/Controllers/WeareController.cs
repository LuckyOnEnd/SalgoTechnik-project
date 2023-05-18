using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SalgoTechnik.MVC.Controllers
{
    public class WeareController : Controller
    {
        public IActionResult Page()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
