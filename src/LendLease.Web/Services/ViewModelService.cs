using LendLease.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace LendLease.Web.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly IUrlHelper _urlHelper;

        public ViewModelService(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                CustomerCountTile = new TileViewModel
                {
                    Title = "Customers",
                    Value = 10,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-users",
                    Url = _urlHelper.Action("Index", "Customer")
                },
                ScheduledPaymentCountTile = new TileViewModel
                {
                    Title = "Scheduled Payments",
                    Value = 100,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-calendar",
                    Url = _urlHelper.Action("Index", "Customer")
                },
                PaymentRecievedCountTile = new TileViewModel
                {
                    Title = "Payments Recieved",
                    Value = 75,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-book",
                    Url = _urlHelper.Action("Index", "Customer")
                },
                PaymentOverdueCountTile = new TileViewModel
                {
                    Title = "Payments Overdue",
                    Value = 25,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-warning",
                    Url = _urlHelper.Action("Index", "Customer")
                }
            };
        }
    }
}