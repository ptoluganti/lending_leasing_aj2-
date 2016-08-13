using LendLease.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LendLease.Web.Controllers.Web
{
    public class PartialController : Controller
    {
        private readonly IViewModelService _viewModelService;

        public PartialController(IViewModelService viewModelService)
        {
            this._viewModelService = viewModelService;
        }
        // GET: /<controller>/
        public IActionResult Message() => PartialView(_viewModelService.GetDashboardViewModel());
        public IActionResult Displaytemplate() => PartialView();
    }
}