using Microsoft.AspNetCore.Mvc;
using Models;
using technova_ecommerce.Models.Entities;

namespace technova_ecommerce.Controllers
{
    
    public class AuthController : Controller
    {
        private DatabaseContext _db;

        public AuthController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(u => u.UserName == user.UserName))
                {
                    var loggedInUser = _db.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName));
                  if(BCrypt.Net.BCrypt.Verify(user.hashed_password,loggedInUser.hashed_password))
                        return RedirectToAction("Index", "Home");


                    //user.hashed_password = BCrypt.Net.BCrypt.HashPassword(user.hashed_password);
                    //if (_db.Users.Any(u => u.hashed_password.Equals(user.hashed_password)))
                    //    return RedirectToAction("Index", "Home");
                    else
                        ViewBag.ErrorMessage = "Incorrect Password";
                }

               else
                        {

                            ViewBag.ErrorMessage = "Incorrect User Name";
                            return View(user);
                        }

            }
         
            //user.hashed_password=BCrypt.Net.Bcrypt.hashed_password
            //user.hashed_password = BCrypt.Net.BCrypt.HashPassword(user.hashed_password);
            //_db.Users.Add(user);
            //await _db.SaveChangesAsync();
            //return RedirectToAction("Login", "Auth");


            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(u => u.UserName == user.UserName))
                {
                    ViewBag.ErrorMessage = " User Name already exist! please try another user name";
                    return View(user);
                }
                else {
                    user.hashed_password = BCrypt.Net.BCrypt.HashPassword(user.hashed_password);
                    _db.Users.Add(user);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Login", "Auth");
                }

            }
            //user.hashed_password=BCrypt.Net.Bcrypt.hashed_password
            return View(user);


        }

    }
}
