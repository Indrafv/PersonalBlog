using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ArticlesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Posts()
        {
            List<Articles> Articles = await _appDbContext.Articles.ToListAsync();
            return View(Articles);
        }

        public IActionResult New()
        {
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            List<Articles> Posts = await _appDbContext.Articles.ToListAsync();
            return View(Posts);
        }
    }
}
