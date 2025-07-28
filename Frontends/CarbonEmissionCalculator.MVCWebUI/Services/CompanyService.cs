using CarbonEmissionCalculator.Persistence.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarbonEmissionCalculator.MVCWebUI.Services
{
    public class CompanyService
    {
        private readonly AppDbContext _context; // Veritabanı bağlantınız

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetCompanyListForDropdownAsync()
        {
            // Veritabanından firma listesini asenkron olarak alın
            // .ToListAsync() EF Core'da asenkron çalışır
            var companies = await _context.Companies
                                          .OrderBy(c => c.Name) // İsme göre sırala
                                          .Select(c => new SelectListItem
                                          {
                                              Value = c.Id.ToString(), // Seçilen değer (firmanın ID'si)
                                              Text = c.Name // Kullanıcıya gösterilecek isim
                                          })
                                          .ToListAsync();

            return companies;
        }
    }
}
