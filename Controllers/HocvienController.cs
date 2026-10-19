using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplicationHinh.Models;

namespace WebApplicationHinh.Controllers
{
    public class HocvienController : Controller
    {
        private readonly HinhanhContext db = new HinhanhContext();
        public async Task<IActionResult> Index()
        {
            List<Hocvien> ds = await db.Hocviens.ToListAsync();
            return View(ds);
        }
        
        public async Task<IActionResult> detail(string id)
        {
            Hocvien? hv = await db.Hocviens.FindAsync(id);
            if (hv != null)
            {
                return View(hv);
            }
            return RedirectToAction("Index");
        }
    }
}
