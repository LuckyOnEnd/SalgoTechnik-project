using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SalgoTechnik.Application.Interfaces;
using SalgoTechnik.Application.Services;

namespace SalgoTechnik.MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _projectService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> SortAllAsync(string Type, string LegalRelationship, string ProjectLocation, string ProjectLanguage)
        {
            var result = await _projectService.SortHelper(Type, LegalRelationship, ProjectLocation, ProjectLanguage);
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
