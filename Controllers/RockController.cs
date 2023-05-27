using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueBlotRecords.Controllers
{
    public class RockController : Controller
    {
        // GET: Rock
        public ActionResult HardRock()
        {
            return View();
        }
        public ActionResult SoftRock()
        {
            return View();
        }
        public ActionResult Psychedelic()
        {
            return View();
        }
        public ActionResult Stoner()
        {
            return View();
        }
        public ActionResult Gothic()
        {
            return View();
        }
        public ActionResult Progressive()
        {
            return View();
        }
        public ActionResult Alternative()
        {
            return View();
        }
        // GET: Rock/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rock/Create
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

        // GET: Rock/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rock/Edit/5
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

        // GET: Rock/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rock/Delete/5
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
