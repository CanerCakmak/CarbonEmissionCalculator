using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class MobileOnRoadDieselController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public MobileOnRoadDieselController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public async Task<IActionResult> Index()   
        {
            IList<MobileOnRoadDieselCalculation> values = await _unitOfWork.GetReadRepository<MobileOnRoadDieselCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            MobileOnRoadDieselCalculation value = await _unitOfWork.GetReadRepository<MobileOnRoadDieselCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MobileOnRoadDieselCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadDieselCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadDieselCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
