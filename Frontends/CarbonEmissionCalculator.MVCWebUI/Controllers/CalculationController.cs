using Microsoft.AspNetCore.Mvc;
using CarbonEmissionCalculator.MVCWebUI.Models;

namespace CarbonEmissionCalculator.MVCWebUI.Controllers
{
    public class CalculationController : Controller
    {
        public IActionResult FixedCombustion()
        {
            return View();
        }

        // Mobil Yanma Ana Sayfası
        public IActionResult MobileCombustion()
        {
            return View();
        }

        // On-Road Araçlar Ana Sayfası
        public IActionResult MobileOnRoad()
        {
            return View();
        }

        // Off-Road Araçlar Ana Sayfası
        public IActionResult MobileOffRoad()
        {
            return View();
        }




        [HttpGet]
        public IActionResult Electricity()
        {
            var model = new ElectricityViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Electricity(ElectricityViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate total emission
                model.TotalEmission = model.ConsumptionAmount * model.EmissionFactor;
            }
            return View(model);
        }
    }
} 