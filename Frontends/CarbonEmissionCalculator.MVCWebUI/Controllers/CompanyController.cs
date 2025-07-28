using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarbonEmissionCalculator.MVCWebUI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public CompanyController(IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
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

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(int id)
        {

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Clear()
        {

            return RedirectToAction(nameof(Index));
        }
    }
}