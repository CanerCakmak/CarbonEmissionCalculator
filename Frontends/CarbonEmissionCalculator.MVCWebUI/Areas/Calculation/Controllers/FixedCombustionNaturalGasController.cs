using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using CarbonEmissionCalculator.MVCWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class FixedCombustionNaturalGasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly CompanyService _companyService;

        public FixedCombustionNaturalGasController(IUnitOfWork unitOfWork, ICustomMapper customMapper, CompanyService companyService)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            IList<FixedCombustionNaturalGasCalculation> values = await _unitOfWork.GetReadRepository<FixedCombustionNaturalGasCalculation>().GetAllAsync(include:v=> v.Include(v=>v.Company));

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            FixedCombustionNaturalGasCalculation value = await _unitOfWork.GetReadRepository<FixedCombustionNaturalGasCalculation>().GetAsync(x => x.Id == id, include: x => x.Include(x => x.Company));

            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyService.GetCompanyListForDropdownAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FixedCombustionNaturalGasCalculation calc)
        {

            await _unitOfWork.GetWriteRepository<FixedCombustionNaturalGasCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<FixedCombustionNaturalGasCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
