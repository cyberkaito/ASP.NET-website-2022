using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueBlotRecords.Controllers
{
    public class BandsController : Controller
    {
        // GET: BandsController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Accept()
        {
            return View();
        }
        public IActionResult TheCure()
        {
            return View();
        }
        public IActionResult ACDC()
        {
            return View();
        }
        public IActionResult Motorhead()
        {
            return View();
        }
        // GET: BandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BandsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BandsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
