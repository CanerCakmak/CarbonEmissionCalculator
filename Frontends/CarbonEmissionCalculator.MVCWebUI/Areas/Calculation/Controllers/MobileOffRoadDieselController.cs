using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using CarbonEmissionCalculator.MVCWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class MobileOffRoadDieselController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly CompanyService _companyService;

        public MobileOffRoadDieselController(IUnitOfWork unitOfWork, ICustomMapper customMapper, CompanyService companyService)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            IList<MobileOffRoadDieselCalculation> values = await _unitOfWork.GetReadRepository<MobileOffRoadDieselCalculation>().GetAllAsync(include: v => v.Include(v => v.Company));

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            MobileOffRoadDieselCalculation value = await _unitOfWork.GetReadRepository<MobileOffRoadDieselCalculation>().GetAsync(x => x.Id == id);

            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyService.GetCompanyListForDropdownAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MobileOffRoadDieselCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<MobileOffRoadDieselCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<MobileOffRoadDieselCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
