using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCEFCore.Data;
using MVCEFCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            //var category = new Category
            //{
            //    Name = "Kategori1"
            //};

            //_applicationDbContext.Add(category);
            //_applicationDbContext.SaveChanges();


            //AsNoTracking ChangeTracker iptal eder. bu sayede performans sağlar.
            // _applicationDbContext.Categories.AsNoTracking().ToList(); // ToList yada Where öncesi
            // FirstOrDefault() Find için deteği yok.
            //var data = _applicationDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == "1");

            // AsQueryable veri tabanında filtreleme
            var p = _applicationDbContext.Products.Where(x => x.Name == "Product1").AsQueryable();
           

            // Entity State Detach olmuş oluyor. EntityState Attach çekmek gerekir.

            // EF Core Lazy Loading özelliği kapalı
            //var products = _applicationDbContext.Products.ToList();

            //var productsWithInclude = _applicationDbContext.Products
            //    .Include(x => x.Category)
            //    .Where(x=> x.Category.Name.Contains("a")).ToList();

            // select ile navigation propery erişebiliriz. production query
            //var productsWithSelect = _applicationDbContext.Products.Select(x => new
            //{

            //    CategoryName = x.Category.Name,
            //    Name = x.Name,
            //    Price = x.Price,
            //    Stock = x.Stock

            //}).ToList();



            var categories = _applicationDbContext.Categories
               .Include(x => x.Products)
               .ThenInclude(x => x.Files).Select(a=> a.Products).ToList();

            //var files = _applicationDbContext.Files.Where(x => x.Name == "a").AsQueryable();

            var productResults = _applicationDbContext.ProductCategoryViews.ToList();



            //var x = (from c in categories from f in c.Products from d in f.Files.w)

            // store proc içerisinde liste çağarılacak ise kullanırız. select
            //var name = new SqlParameter("@name", "Kategori11");
            //var books = _applicationDbContext.Categories
            //    .FromSqlRaw("EXEC CategoryInsert @name", name)
            //    .ToList();






            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
