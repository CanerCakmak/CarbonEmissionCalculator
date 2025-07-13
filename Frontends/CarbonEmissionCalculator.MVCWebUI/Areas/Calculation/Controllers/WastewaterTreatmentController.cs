using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class WastewaterTreatmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public WastewaterTreatmentController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public async Task<IActionResult> Index()
        {
            IList<WastewaterTreatmentCalculation> values = await _unitOfWork.GetReadRepository<WastewaterTreatmentCalculation>().GetAllAsync();

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            WastewaterTreatmentCalculation value = await _unitOfWork.GetReadRepository<WastewaterTreatmentCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WastewaterTreatmentCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<WastewaterTreatmentCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<WastewaterTreatmentCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
