﻿using CarbonEmissionCalculator.Application.Interfaces.AutoMapper;
using CarbonEmissionCalculator.Application.Interfaces.UnitOfWorks;
using CarbonEmissionCalculator.Domain.Entities;
using CarbonEmissionCalculator.MVCWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Areas.Calculation.Controllers
{
    [Area("Calculation")]
    public class MobileOnRoadDieselController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;
        private readonly CompanyService _companyService;

        public MobileOnRoadDieselController(IUnitOfWork unitOfWork, ICustomMapper customMapper, CompanyService companyService)
        {
            _unitOfWork = unitOfWork;
            _customMapper = customMapper;
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()   
        {
            IList<MobileOnRoadDieselCalculation> values = await _unitOfWork.GetReadRepository<MobileOnRoadDieselCalculation>().GetAllAsync(include: v => v.Include(v => v.Company));

            return View(values);
        }
        public async Task<IActionResult> Detail(int id)
        {
            MobileOnRoadDieselCalculation value = await _unitOfWork.GetReadRepository<MobileOnRoadDieselCalculation>().GetAsync(x => x.Id == id, include: x => x.Include(x => x.Company));

            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyService.GetCompanyListForDropdownAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MobileOnRoadDieselCalculation calc)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadDieselCalculation>().AddAsync(calc);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.GetWriteRepository<MobileOnRoadDieselCalculation>().HardDeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
