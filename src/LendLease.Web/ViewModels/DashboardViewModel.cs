namespace LendLease.Web.ViewModels
{
    public class DashboardViewModel
    { 
        public TileViewModel CustomerCountTile { get; set; }
        public TileViewModel ScheduledPaymentCountTile { get; set; }
        public TileViewModel PaymentRecievedCountTile { get; set; }
        public TileViewModel PaymentOverdueCountTile { get; set; }
    }
}
