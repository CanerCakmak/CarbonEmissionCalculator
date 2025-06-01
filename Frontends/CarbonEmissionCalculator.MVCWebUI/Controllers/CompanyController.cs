using CarbonEmissionCalculator.MVCWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarbonEmissionCalculator.MVCWebUI.Controllers
{
    public class CompanyController : Controller
    {
        private static List<Company> _companies = new List<Company>();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.Name))
            {
                ModelState.AddModelError("Name", "Firma adı zorunludur");
                return View(company);
            }

            company.Id = _nextId++;
            _companies.Add(company);
            
            // Firma seçildi olarak işaretle
            HttpContext.Session.SetInt32("SelectedCompanyId", company.Id);
            HttpContext.Session.SetString("SelectedCompanyName", company.Name);
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Select(int id)
        {
            var company = _companies.Find(c => c.Id == id);
            if (company != null)
            {
                HttpContext.Session.SetInt32("SelectedCompanyId", company.Id);
                HttpContext.Session.SetString("SelectedCompanyName", company.Name);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("SelectedCompanyId");
            HttpContext.Session.Remove("SelectedCompanyName");
            return RedirectToAction(nameof(Index));
        }
    }
} 