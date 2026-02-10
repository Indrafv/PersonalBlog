using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PersonalBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        

        
    }
}
