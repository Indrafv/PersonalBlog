using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Posts(int id)
        {
            Articles? Articles = await _appDbContext.Articles.FirstOrDefaultAsync(a => a.ArticleId == id);
            if(Articles == null)
            {
                return NotFound();
            }
            return View(Articles);
        }
        [HttpGet]
        [Authorize]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> New(Articles article)
        {
            
            await _appDbContext.Articles.AddAsync(article);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Posts), new {id = article.ArticleId});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            Articles article = await _appDbContext.Articles.FirstAsync(a => a.ArticleId ==id);
            return View(article);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Articles article)
        {

            _appDbContext.Articles.Update(article);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Posts), new { id = article.ArticleId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Articles article = await _appDbContext.Articles.FirstAsync(a => a.ArticleId == id);
            _appDbContext.Articles.Remove(article);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Admin));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Admin()
        {
            List<Articles> Posts = await _appDbContext.Articles.ToListAsync();
            return View(Posts);
        }
    }
}
