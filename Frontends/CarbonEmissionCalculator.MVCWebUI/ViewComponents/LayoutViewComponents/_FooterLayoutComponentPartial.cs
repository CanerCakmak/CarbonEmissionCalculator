using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.ViewComponents.LayoutViewComponents
{
    public class _FooterLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
