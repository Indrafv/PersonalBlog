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
        public async Task<IActionResult> Articles()
        {
            List<Articles> Articles = await _appDbContext.Articles.ToListAsync();
            return View(Articles);
        }
    }
}
