using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueBlotRecords.Controllers
{
    public class MetalController : Controller
    {
        // GET: MetalController
        public ActionResult Heavy()
        {
            return View();
        }
        public ActionResult Power()
        {
            return View();
        }
        public ActionResult Metalcore()
        {
            return View();
        }
        public ActionResult Doom()
        {
            return View();
        }
        public ActionResult Death()
        {
            return View();
        }
        public ActionResult Gothic()
        {
            return View();
        }
        public ActionResult Black()
        {
            return View();
        }
        public ActionResult Nu()
        {
            return View();
        }
        public ActionResult Speed()
        {
            return View();
        }
        public ActionResult Trash()
        {
            return View();
        }
        public ActionResult Symphonic()
        {
            return View();
        }
        // GET: MetalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MetalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetalController/Create
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

        // GET: MetalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MetalController/Edit/5
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

        // GET: MetalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MetalController/Delete/5
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
