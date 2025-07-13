using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
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

        public async Task<IActionResult> Index()
        {
            IList<ElectricityCalculation> values = await _unitOfWork.GetReadRepository<ElectricityCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ElectricityCalculation value = await _unitOfWork.GetReadRepository<ElectricityCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ElectricityCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<ElectricityCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<ElectricityCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
