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

        public async Task<IActionResult> IndexAsync()
        {
            IList<FixedCombustionNaturalGasCalculation> values = await _unitOfWork.GetReadRepository<FixedCombustionNaturalGasCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            FixedCombustionNaturalGasCalculation value = await _unitOfWork.GetReadRepository<FixedCombustionNaturalGasCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FixedCombustionNaturalGasCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<FixedCombustionNaturalGasCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<FixedCombustionNaturalGasCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }
    }
}
