using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class MobileOnRoadGasolineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public MobileOnRoadGasolineController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IList<MobileOnRoadGasolineCalculation> values = await _unitOfWork.GetReadRepository<MobileOnRoadGasolineCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            MobileOnRoadGasolineCalculation value = await _unitOfWork.GetReadRepository<MobileOnRoadGasolineCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MobileOnRoadGasolineCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadGasolineCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadGasolineCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("IndexAsync");
        }
    }
}
