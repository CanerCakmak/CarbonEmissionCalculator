using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.Repositories;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using CarbonEmissionCalculator.MVCWebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class CarbonContainingMaterialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public CarbonContainingMaterialController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _unitOfWork.GetReadRepository<CarbonContainingMaterialCalculationGroup>()
                .GetAllAsync(include: q => q.Include(g => g.Rows));
            return View(groups);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var group = await _unitOfWork.GetReadRepository<CarbonContainingMaterialCalculationGroup>()
                .GetAsync(x => x.Id == id, include: q => q.Include(g => g.Rows));
            return View(group);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CarbonContainingMaterialCreateViewModel { Rows = new List<CarbonContainingMaterialRow>() });
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarbonContainingMaterialCreateViewModel model)
        {
            var group = new CarbonContainingMaterialCalculationGroup
            {
                FirmName = model.FirmName,
                CreatedAt = DateTime.Now,
                Rows = new List<CarbonContainingMaterialCalculationRow>()
            };
            await _unitOfWork.GetWriteRepository<CarbonContainingMaterialCalculationGroup>().AddAsync(group);
            await _unitOfWork.SaveAsync();

            double grandTotalKg = 0;
            double grandTotalTon = 0;
            if (model.Rows != null)
            {
                foreach (var row in model.Rows)
                {
                    grandTotalKg += row.TotalEmissionKg;
                    grandTotalTon += row.TotalEmissionTon;
                    var entity = new CarbonContainingMaterialCalculationRow
                    {
                        GroupId = group.Id,
                        RawMaterialActivity = row.RawMaterialActivity,
                        RawMaterialCarbon = row.RawMaterialCarbon,
                        RawMaterialCarbonAmount = row.RawMaterialCarbonAmount,
                        FinalProductActivity = row.FinalProductActivity,
                        FinalProductCarbon = row.FinalProductCarbon,
                        FinalProductCarbonAmount = row.FinalProductCarbonAmount,
                        TotalCarbon = row.TotalCarbon,
                        ConversionFactor = row.ConversionFactor,
                        TotalEmissionKg = row.TotalEmissionKg,
                        TotalEmissionTon = row.TotalEmissionTon,
                        FirmName = model.FirmName
                    };
                    await _unitOfWork.GetWriteRepository<CarbonContainingMaterialCalculationRow>().AddAsync(entity);
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
            await _unitOfWork.GetWriteRepository<CarbonContainingMaterialCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
