using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarbonEmissionCalculator.MVCWebUI.Filters
{
    public class RequireCompanySelectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var selectedCompanyId = context.HttpContext.Session.GetInt32("SelectedCompanyId");
            
            if (!selectedCompanyId.HasValue)
            {
                // Firma seçili değilse Company/Index sayfasına yönlendir
                context.Result = new RedirectToActionResult("Index", "Company", new { returnUrl = context.HttpContext.Request.Path });
            }
        }
    }
} 