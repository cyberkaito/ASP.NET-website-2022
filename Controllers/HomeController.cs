using BlueBlotRecords.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BlueBlotRecords.Controllers
{
    
    public class HomeController : Controller
    {
        private BlueBlotRecordsContext db;
        public HomeController(BlueBlotRecordsContext context)
        {
            db = context;
        }
        public IActionResult SignIn()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            cart.items.Add(db.Services.Find(ID));
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return RedirectToAction("Services", "Home");
        } 
        public IActionResult RemoveFromCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.Get("Cart"));
            cart.items.RemoveAt(ID);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return RedirectToAction("Cart", "Home");
        }
        public IActionResult RemoveAllFromCart()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.Get("Cart"));
            cart.items.Clear();
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));
            return RedirectToAction("Cart", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Band band = await db.Bands.FirstOrDefaultAsync(u => u.Mail == model.Login && u.PasswordBand == model.Password);
                if(band != null)
                {
                    HttpContext.Session.SetString("AuthUser",model.Login);
                    await Authenticate(model.Login);
                    await Task.Delay(2000);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин или пароль");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "AuthCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            BandCard bandCard = new BandCard()
            {
                band = db.Bands.ToListAsync().Result,
                genre = db.Genres.ToListAsync().Result,
                subGenre = db.SubGenres.ToListAsync().Result,
                bandArea = db.BandAreas.ToListAsync().Result
            };
            return View(bandCard);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Band band)
        {
            db.Bands.Add(band);
            await db.SaveChangesAsync();
            if(await db.Bands.FirstOrDefaultAsync(u => u.Mail == band.Mail && u.PasswordBand == band.PasswordBand) != null){
                HttpContext.Session.SetString("AuthUser", band.Mail);
                await Authenticate(band.Mail);
            }
            await Task.Delay(2000);
            return RedirectToAction("Index");
        }
        public ActionResult JoinIn()
        {
            return View();
        }
        public IActionResult Profile()
        {
            var profile = new Band();
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                var user = HttpContext.Session.GetString("AuthUser");
                profile = db.Bands.First(x => x.Mail == user);
            }
            return View(profile);
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Cart()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }
        public IActionResult Services()
        {
            return View(db.Services.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}