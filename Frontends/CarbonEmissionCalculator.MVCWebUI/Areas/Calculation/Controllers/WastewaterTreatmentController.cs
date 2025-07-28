using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using CarbonEmissionCalculator.MVCWebUI.Models;
using CarbonEmissionCalculator.MVCWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class WastewaterTreatmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly CompanyService _companyService;

        public WastewaterTreatmentController(IUnitOfWork unitOfWork, ICustomMapper customMapper, CompanyService companyService)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _unitOfWork.GetReadRepository<WastewaterTreatmentCalculationGroup>()
                .GetAllAsync(include: q => q.Include(g => g.Rows).Include(x => x.Company));
            return View(groups);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var group = await _unitOfWork.GetReadRepository<WastewaterTreatmentCalculationGroup>()
                .GetAsync(x => x.Id == id, include: q => q.Include(g => g.Rows));
            return View(group);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyService.GetCompanyListForDropdownAsync();
            return View(new WastewaterTreatmentCreateViewModel { Rows = new List<WastewaterTreatmentRow>() });
        }
        [HttpPost]
        public async Task<IActionResult> Create(WastewaterTreatmentCreateViewModel model)
        {
            var group = new WastewaterTreatmentCalculationGroup
            {
                FirmName = model.FirmName,
                CompanyId = model.CompanyId,
                Rows = new List<WastewaterTreatmentCalculationRow>()
            };
            await _unitOfWork.GetWriteRepository<WastewaterTreatmentCalculationGroup>().AddAsync(group);
            await _unitOfWork.SaveAsync();

            double grandTotalKg = 0;
            double grandTotalTon = 0;
            if (model.Rows != null)
            {
                foreach (var row in model.Rows)
                {
                    grandTotalKg += row.KgCO2e;
                    grandTotalTon += row.TonCO2e;
                    var entity = new WastewaterTreatmentCalculationRow
                    {
                        GroupId = group.Id,
                        WastewaterType = row.WastewaterType,
                        Amount = row.Amount,
                        Unit = row.Unit,
                        EmissionFactor = row.EmissionFactor,
                        KgCO2e = row.KgCO2e,
                        TonCO2e = row.TonCO2e,
                        FirmName = model.FirmName
                    };
                    await _unitOfWork.GetWriteRepository<WastewaterTreatmentCalculationRow>().AddAsync(entity);
                }
                group.GrandTotalKg = grandTotalKg;
                group.GrandTotalTon = grandTotalTon;
                await _unitOfWork.SaveAsync();
            }
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
