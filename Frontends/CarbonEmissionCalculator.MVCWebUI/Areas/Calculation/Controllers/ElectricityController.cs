using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.MVCWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class ElectricityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public ElectricityController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Create()
        {
            
            return View();
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
