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

        public IActionResult MobileCombustion()
        {
            return View();
        }

        public IActionResult FixedCombustionNaturalGas()
        {
            return View();
        }

        public IActionResult FixedCombustionDiesel()
        {
            return View();
        }

        public IActionResult FixedCombustionGasoline()
        {
            return View();
        }

        public IActionResult FixedCombustionLPG()
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

        public IActionResult MobileCombustionDiesel()
        {
            return View();
        }

        public IActionResult MobileCombustionGasoline()
        {
            return View();
        }

        public IActionResult MobileCombustionLPG()
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

        public IActionResult Test(int id)
        {
            return View();
        }
    }
} 