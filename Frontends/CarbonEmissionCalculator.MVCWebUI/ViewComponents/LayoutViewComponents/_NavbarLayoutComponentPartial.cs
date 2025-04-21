using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.ViewComponents.LayoutViewComponents
{
    public class _NavbarLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
