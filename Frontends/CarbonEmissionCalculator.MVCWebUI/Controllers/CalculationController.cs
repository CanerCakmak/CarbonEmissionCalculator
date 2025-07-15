using Microsoft.AspNetCore.Mvc;
using CarbonEmissionCalculator.MVCWebUI.Models;
using System;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Controllers
{
    public class CalculationController : Controller
    {
        public IActionResult FixedCombustion()
        {
            return View();
        }

        public IActionResult FixedCombustionSummary()
        {
            // Örnek veri - Bu kısım daha sonra veritabanından gelecek şekilde güncellenebilir
            var summaryList = new List<FixedCombustionSummaryViewModel>
            {
                new FixedCombustionSummaryViewModel
                {
                    FuelType = "Doğalgaz",
                    ConsumptionAmount = 1000,
                    CO2Emission = 2000,
                    CH4Emission = 30,
                    N2OEmission = 15,
                    TotalCO2e = 2500,
                    CalculationDate = DateTime.Now
                },
                new FixedCombustionSummaryViewModel
                {
                    FuelType = "Dizel",
                    ConsumptionAmount = 500,
                    CO2Emission = 1500,
                    CH4Emission = 20,
                    N2OEmission = 10,
                    TotalCO2e = 1800,
                    CalculationDate = DateTime.Now
                }
            };

            return View(summaryList);
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

        public IActionResult MobileCombustionSummary()
        {
            // Örnek veri - Bu kısım daha sonra veritabanından gelecek şekilde güncellenebilir
            var summaryList = new List<FixedCombustionSummaryViewModel>
            {
                new FixedCombustionSummaryViewModel
                {
                    FuelType = "Dizel",
                    ConsumptionAmount = 800,
                    CO2Emission = 1800,
                    CH4Emission = 25,
                    N2OEmission = 12,
                    TotalCO2e = 2200,
                    CalculationDate = DateTime.Now
                },
                new FixedCombustionSummaryViewModel
                {
                    FuelType = "Benzin",
                    ConsumptionAmount = 600,
                    CO2Emission = 1400,
                    CH4Emission = 18,
                    N2OEmission = 8,
                    TotalCO2e = 1600,
                    CalculationDate = DateTime.Now
                }
            };

            return View(summaryList);
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