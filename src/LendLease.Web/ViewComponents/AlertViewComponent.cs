using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LendLease.Web.ViewComponents
{
    public class AlertViewComponent: ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
            var viewModel = new List<string>();

           
            return View(viewModel);
        }
    }
}
