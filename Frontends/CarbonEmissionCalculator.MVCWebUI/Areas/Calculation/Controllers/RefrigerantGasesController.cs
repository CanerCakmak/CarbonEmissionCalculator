using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using CarbonEmissionCalculator.MVCWebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class RefrigerantGasesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public RefrigerantGasesController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
        }
        public async Task<IActionResult> Index()
        {
            IList<RefrigerantGasesCalculationGroup> values = await _unitOfWork.GetReadRepository<RefrigerantGasesCalculationGroup>().GetAllAsync(include: x=> x.Include(x=> x.Rows));

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var group = await _unitOfWork.GetReadRepository<RefrigerantGasesCalculationGroup>().GetAsync(x => x.Id == id, include: x => x.Include(x=> x.Rows));
            return View(group);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RefrigerantGasesCreateViewModel model)
        {
            var group = new RefrigerantGasesCalculationGroup
            {
                FirmName = model.FirmName,
                CreatedAt = DateTime.Now,
                Rows = new List<RefrigerantGasesCalculation>()
            };
            await _unitOfWork.GetWriteRepository<RefrigerantGasesCalculationGroup>().AddAsync(group);
            await _unitOfWork.SaveAsync();

            double totalCO2e = 0;
            double totalCO2eTon = 0;
            if (model.Rows != null)
            {
                foreach (var row in model.Rows)
                {
                    totalCO2e += row.KgCO2e;
                    totalCO2eTon += row.TonCO2e;
                    var entity = new RefrigerantGasesCalculation
                    {
                        GroupId = group.Id,
                        FirmName = model.FirmName,
                        RefrigerantType = row.EquipmentType,
                        RefrigerantAmount = row.Amount,
                        GWPFactor = row.EmissionFactor,
                        LeakageRate = row.LeakPercentage,
                        TotalLeakage = row.LeakAmount,
                        TotalCO2e = row.KgCO2e,
                        TotalCO2eTon = row.TonCO2e
                    };
                    await _unitOfWork.GetWriteRepository<RefrigerantGasesCalculation>().AddAsync(entity);
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
            await _unitOfWork.GetWriteRepository<RefrigerantGasesCalculationGroup>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
