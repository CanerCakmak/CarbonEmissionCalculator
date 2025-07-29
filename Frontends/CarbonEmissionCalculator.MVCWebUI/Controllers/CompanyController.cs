using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.MVCWebUI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, ICustomMapper customMapper, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _unitOfWork.GetReadRepository<Company>().GetAllAsync();

            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _unitOfWork.GetWriteRepository<Company>().AddAsync(company);
            _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<Company>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ExportExcel(int id)
        {

            var carbonContainingMaterialCalculationGroup = await _unitOfWork.GetReadRepository<CarbonContainingMaterialCalculationGroup>().GetAsync(x => x.CompanyId == id);
            var companyVehiclesCalculationGroup = await _unitOfWork.GetReadRepository<CompanyVehiclesCalculationGroup>().GetAsync(x => x.CompanyId == id, include: x => x.Include(x => x.Rows));
            var electricityCalculation = await _unitOfWork.GetReadRepository<ElectricityCalculation>().GetAsync(x => x.CompanyId == id);
            var fixedCombustionDieselCalculation = await _unitOfWork.GetReadRepository<FixedCombustionDieselCalculation>().GetAsync(x => x.CompanyId == id);
            var fixedCombustionGasolineCalculation = await _unitOfWork.GetReadRepository<FixedCombustionGasolineCalculation>().GetAsync(x => x.CompanyId == id);
            var fixedCombustionLPGCalculation = await _unitOfWork.GetReadRepository<FixedCombustionLPGCalculation>().GetAsync(x => x.CompanyId == id);
            var fixedCombustionNaturalGasCalculation = await _unitOfWork.GetReadRepository<FixedCombustionNaturalGasCalculation>().GetAsync(x => x.CompanyId == id);
            var mobileOffRoadDieselCalculation = await _unitOfWork.GetReadRepository<MobileOffRoadDieselCalculation>().GetAsync(x => x.CompanyId == id);
            var mobileOffRoadGasolineCalculation = await _unitOfWork.GetReadRepository<MobileOffRoadGasolineCalculation>().GetAsync(x => x.CompanyId == id);
            var mobileOnRoadDieselCalculation = await _unitOfWork.GetReadRepository<MobileOnRoadDieselCalculation>().GetAsync(x => x.CompanyId == id);
            var mobileOnRoadGasolineCalculation = await _unitOfWork.GetReadRepository<MobileOnRoadGasolineCalculation>().GetAsync(x => x.CompanyId == id);
            var mobileOnRoadLPGCalculation = await _unitOfWork.GetReadRepository<MobileOnRoadLPGCalculation>().GetAsync(x => x.CompanyId == id);
            var refrigerantGasesCalculationGroup = await _unitOfWork.GetReadRepository<RefrigerantGasesCalculationGroup>().GetAsync(x => x.CompanyId == id);
            var wastewaterTreatmentCalculationGroup = await _unitOfWork.GetReadRepository<WastewaterTreatmentCalculationGroup>().GetAsync(x => x.CompanyId == id);

            double companyvehiclesTotalco2 = 0;
            double companyvehiclesTotalch4 = 0;
            double companyvehiclesTotaln2o = 0;

            if (companyVehiclesCalculationGroup != null && companyVehiclesCalculationGroup.Rows != null)
            {
                foreach (var item in companyVehiclesCalculationGroup.Rows)
                {
                    companyvehiclesTotalco2 += item.EmissionCO2;
                    companyvehiclesTotalch4 += item.EmissionCH4;
                    companyvehiclesTotaln2o += item.EmissionN2O;
                }
            }


            var templatePath = Path.Combine(_hostingEnvironment.WebRootPath, "Templates", "EmisyonRaporuSablon.xlsx");

            if (!System.IO.File.Exists(templatePath))
            {

                return Content("Excel þablon dosyasý bulunamadý! Lütfen 'wwwroot/Templates/EmisyonRaporuSablon.xlsx' yolunda dosyanýn olduðundan emin olun.");
            }

            using (var templateStream = new MemoryStream())
            {
                // Þablon dosyasýný belleðe kopyala
                using (var fileStream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(templateStream);
                }
                templateStream.Position = 0; // Kopyalama sonrasý stream'in baþýna dön

                // Workbook'u bu templateStream üzerinden açýyoruz
                using (var workbook = new XLWorkbook(templateStream))
                {
                    var worksheet = workbook.Worksheet("Toplam Sera Gazý Emisyonlarý");

                    if (worksheet == null)
                    {
                        return Content("Excel þablonunda 'Total of GHG Emissions' adýnda bir sayfa bulunamadý. Lütfen sayfa adýný kontrol edin.");
                    }

                    // Sabit Yanma Kaynaklarý Toplamlarý (Fixed Combustion)
                    double FixedTotalco2eton =
                        (fixedCombustionNaturalGasCalculation?.TotalCO2eTon ?? 0) +
                        (fixedCombustionLPGCalculation?.TotalCO2eTon ?? 0) +
                        (fixedCombustionGasolineCalculation?.TotalCO2eTon ?? 0) +
                        (fixedCombustionDieselCalculation?.TotalCO2eTon ?? 0);

                    double Fixedco2eton =
                        (fixedCombustionNaturalGasCalculation?.TotalCO2 ?? 0) +
                        (fixedCombustionLPGCalculation?.TotalCO2 ?? 0) +
                        (fixedCombustionGasolineCalculation?.TotalCO2 ?? 0) +
                        (fixedCombustionDieselCalculation?.TotalCO2 ?? 0);

                    double FixedCH4eton =
                        (fixedCombustionNaturalGasCalculation?.TotalCH4 ?? 0) +
                        (fixedCombustionLPGCalculation?.TotalCH4 ?? 0) +
                        (fixedCombustionGasolineCalculation?.TotalCH4 ?? 0) +
                        (fixedCombustionDieselCalculation?.TotalCH4 ?? 0);

                    double FixedN2Oeton =
                        (fixedCombustionNaturalGasCalculation?.TotalN2O ?? 0) +
                        (fixedCombustionLPGCalculation?.TotalN2O ?? 0) +
                        (fixedCombustionGasolineCalculation?.TotalN2O ?? 0) +
                        (fixedCombustionDieselCalculation?.TotalN2O ?? 0);

                    worksheet.Cell("D3").Value = FixedTotalco2eton;
                    worksheet.Cell("E3").Value = Fixedco2eton;
                    worksheet.Cell("F3").Value = FixedCH4eton;
                    worksheet.Cell("G3").Value = FixedN2Oeton;

                    // Mobil Yanma Kaynaklarý Toplamlarý (Mobile Combustion)
                    double MobileTotalCo2eton =
                        (mobileOffRoadDieselCalculation?.TotalCO2eTon ?? 0) +
                        (mobileOffRoadGasolineCalculation?.TotalCO2eTon ?? 0) +
                        (mobileOnRoadDieselCalculation?.TotalCO2eTon ?? 0) +
                        (mobileOnRoadGasolineCalculation?.TotalCO2eTon ?? 0) +
                        (mobileOnRoadLPGCalculation?.TotalCO2e ?? 0) +
                        (companyVehiclesCalculationGroup?.TotalCO2eTon ?? 0);

                    double MobileTotalCo2 =
                        (mobileOffRoadDieselCalculation?.TotalCO2 ?? 0) +
                        (mobileOffRoadGasolineCalculation?.TotalCO2 ?? 0) +
                        (mobileOnRoadDieselCalculation?.TotalCO2 ?? 0) +
                        (mobileOnRoadGasolineCalculation?.TotalCO2 ?? 0) +
                        (mobileOnRoadLPGCalculation?.TotalCO2 ?? 0) +
                        companyvehiclesTotalco2;

                    double MobileTotalCH4 =
                        (mobileOffRoadDieselCalculation?.TotalCH4 ?? 0) +
                        (mobileOffRoadGasolineCalculation?.TotalCH4 ?? 0) +
                        (mobileOnRoadDieselCalculation?.TotalCH4 ?? 0) +
                        (mobileOnRoadGasolineCalculation?.TotalCH4 ?? 0) +
                        (mobileOnRoadLPGCalculation?.TotalCH4 ?? 0) +
                        companyvehiclesTotalch4;

                    double MobileTotalN2O =
                        (mobileOffRoadDieselCalculation?.TotalN2O ?? 0) +
                        (mobileOffRoadGasolineCalculation?.TotalN2O ?? 0) +
                        (mobileOnRoadDieselCalculation?.TotalN2O ?? 0) +
                        (mobileOnRoadGasolineCalculation?.TotalN2O ?? 0) +
                        (mobileOnRoadLPGCalculation?.TotalN2O ?? 0) +
                        companyvehiclesTotaln2o;

                    worksheet.Cell("D4").Value = MobileTotalCo2eton;
                    worksheet.Cell("E4").Value = MobileTotalCo2 / 1000;
                    worksheet.Cell("F4").Value = MobileTotalCH4 / 1000;
                    worksheet.Cell("G4").Value = MobileTotalN2O / 1000;

                    worksheet.Cell("D5").Value = refrigerantGasesCalculationGroup?.TotalCO2eTon ?? 0;
                    worksheet.Cell("D6").Value = wastewaterTreatmentCalculationGroup?.GrandTotalTon ?? 0;
                    worksheet.Cell("D7").Value = carbonContainingMaterialCalculationGroup?.GrandTotalTon ?? 0;
                    worksheet.Cell("D8").Value = electricityCalculation?.TotalEmission ?? 0;

                    worksheet.ColumnsUsed().AdjustToContents();

                    // DÜZELTME: Workbook'u kaydetmek için yeni bir MemoryStream kullanýyoruz
                    var outputStream = new MemoryStream();
                    workbook.SaveAs(outputStream);
                    outputStream.Position = 0; // Stream'in baþlangýcýna dön

                    // Framework'e stream'i gönder ve onun yönetmesine izin ver.
                    return File(outputStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"EmisyonRaporu_Sirke_{id}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx");
                }
            }
        }
    }
}