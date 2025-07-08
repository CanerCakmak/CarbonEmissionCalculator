using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class FixedCombustionDieselController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public FixedCombustionDieselController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public async Task<IActionResult> Index()
        {
            IList<FixedCombustionDieselCalculation> values = await _unitOfWork.GetReadRepository<FixedCombustionDieselCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            FixedCombustionDieselCalculation value = await _unitOfWork.GetReadRepository<FixedCombustionDieselCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FixedCombustionDieselCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<FixedCombustionDieselCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<FixedCombustionDieselCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }
    }
}
