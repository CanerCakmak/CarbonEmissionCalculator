using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.ViewComponents.LayoutViewComponents
{
    public class _SidebarLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
