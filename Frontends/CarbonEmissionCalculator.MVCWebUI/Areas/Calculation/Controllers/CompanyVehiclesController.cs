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
    public class CompanyVehiclesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly CompanyService _companyService;

        public CompanyVehiclesController(IUnitOfWork unitOfWork, ICustomMapper customMapper, CompanyService companyService)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            IList<CompanyVehiclesCalculationGroup> values = await _unitOfWork.GetReadRepository<CompanyVehiclesCalculationGroup>().GetAllAsync(include: x=> x.Include(x=>x.Rows).Include(x=>x.Company));
            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var group = await _unitOfWork.GetReadRepository<CompanyVehiclesCalculationGroup>().GetAsync(x => x.Id == id, include: x => x.Include(x => x.Rows));
            return View(group);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyService.GetCompanyListForDropdownAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CompanyVehiclesCreateViewModel model)
        {
            var group = new CompanyVehiclesCalculationGroup
            {
                FirmName = model.FirmName,
                CompanyId = model.CompanyId,
                CreatedAt = DateTime.Now,
                Rows = new List<CompanyVehiclesCalculation>()
            };
            await _unitOfWork.GetWriteRepository<CompanyVehiclesCalculationGroup>().AddAsync(group);
            await _unitOfWork.SaveAsync();

            double totalCO2e = 0;
            double totalCO2eTon = 0;
            if (model.Rows != null)
            {
                foreach (var row in model.Rows)
                {
                    totalCO2e += row.TotalCO2e;
                    totalCO2eTon += row.TotalCO2eTon;
                    var entity = new CompanyVehiclesCalculation
                    {
                        GroupId = group.Id,
                        FirmName = model.FirmName,
                        VehicleType = row.VehicleType,
                        FuelType = row.FuelType,
                        Distance = row.Distance,
                        EmissionFactorCO2 = row.EmissionFactorCO2,
                        EmissionFactorCH4 = row.EmissionFactorCH4,
                        EmissionFactorN2O = row.EmissionFactorN2O,
                        EmissionCO2 = row.EmissionCO2,
                        EmissionCH4 = row.EmissionCH4,
                        EmissionN2O = row.EmissionN2O,
                        TotalCO2e = row.TotalCO2e,
                        TotalCO2eTon = row.TotalCO2eTon
                    };
                    await _unitOfWork.GetWriteRepository<CompanyVehiclesCalculation>().AddAsync(entity);
                }
                group.TotalCO2e = totalCO2e;
                group.TotalCO2eTon = totalCO2eTon;
                await _unitOfWork.SaveAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<CompanyVehiclesCalculationGroup>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
