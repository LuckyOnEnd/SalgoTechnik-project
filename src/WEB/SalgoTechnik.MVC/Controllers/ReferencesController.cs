using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SalgoTechnik.Application.Interfaces;

namespace SalgoTechnik.MVC.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly IReferenceService _referenceService;

        public ReferencesController(IReferenceService projectService)
        {
            _referenceService = projectService;
        }
        
        public async Task<IActionResult> ReferencesAsync()
        {
            var result = await _referenceService.GetAllAsync();
            return View(result);
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
