using Core.Entities;
using COREationsTask.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Threading.Tasks;

namespace COREationsTask.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<TheUser> _userManager;
        private readonly SignInManager<TheUser> _signInManager;

        public AccountController(UserManager<TheUser> userManager,SignInManager<TheUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //Registration
        public IActionResult Registration()=> View(new RegisterDto());


        [HttpPost]
        public async Task<IActionResult> Registration( RegisterDto registeruser)
        {
            var user = await _userManager.FindByEmailAsync(registeruser.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registeruser);
            }
            if (ModelState.IsValid)
            {
                var newUser = new TheUser()
                {
                    FullName = registeruser.Fullname,
                    Email = registeruser.Email,
                    UserName=registeruser.Email
                   
                };
                var newUserResponse = await _userManager.CreateAsync(newUser, registeruser.Password);
                if (newUserResponse.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in newUserResponse.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return View(registeruser);

        }


      
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterDto newuser)
        {
            if (ModelState.IsValid)
            {
                var user = new TheUser();
                user.FullName = newuser.Fullname;
                user.Email = newuser.Email;

                var result = await _userManager.CreateAsync(user, newuser.Password);

                if (result.Succeeded)
                {
                    //Add Admin Role
                    await _userManager.AddToRoleAsync(user,"Admin");
                    //cookie
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View("Registration",newuser);
        }


        //Login 
        public IActionResult Login(string ReturnUrl = "~/Home/Index")
        {
            ViewData["RedirectToUrl"]=ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto logineduser, string ReturnUrl = "~/Home/Index")
        {
               if(!ModelState.IsValid) return View(logineduser);
           
                var user = await _userManager.FindByEmailAsync(logineduser.Email);

                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, logineduser.Password);

                    if(passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, logineduser.Password, false, false);

                        if (result.Succeeded)  return LocalRedirect(ReturnUrl);
                    }

                }

                 TempData["Error"] = "Invalid credentails , PLZ try again!";
                
               
            return View(logineduser);
        }


        //Logout

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
