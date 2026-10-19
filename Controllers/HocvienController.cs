using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplicationHinh.Models;

namespace WebApplicationHinh.Controllers
{
    public class HocvienController : Controller
    {
        private readonly HinhanhContext db = new HinhanhContext();
        private IHostEnvironment webHost;
        public HocvienController(IHostEnvironment host)
        {
            this.webHost = host;
        }
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
        public async Task<IActionResult> selectImg(IFormFile img, string mshv)
        {
            Hocvien? hv = await db.Hocviens.FindAsync(mshv);
            if (hv != null)
            {
                if (img != null)
                {
                    FileInfo fInfo=new FileInfo(img.FileName);
                    hv.Hinh = hv.Mshv + fInfo.Extension;
                    string link = webHost.ContentRootPath + @"\wwwroot\resource\" + hv.Hinh;
                    FileStream fStream = new FileStream(link,FileMode.Create);
                    await img.CopyToAsync(fStream);
                    fStream.Close();
                    db.Hocviens.Update(hv);
                    await db.SaveChangesAsync();
                }
                return View("detail",hv);
            }
            return RedirectToAction("Index");
        }
    }
}
