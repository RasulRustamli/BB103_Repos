using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BB103_Pronia.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser()
            {
                Name = registerVm.Name,
                Surname = registerVm.Surname,
                UserName = registerVm.Username,
                Email = registerVm.Email,

            };

            IdentityResult results=await _userManager.CreateAsync(user,registerVm.Password);
            if(!results.Succeeded)
            {
                foreach(var error in results.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            await _userManager.AddToRoleAsync(user,UserRole.Member.ToString());
            await _signInManager.SignInAsync(user, false);
           

            return RedirectToAction(nameof(Index), "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm,string? ReturnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var existUser = await _userManager.FindByNameAsync(loginVm.UsernameOrEmail);
            if(existUser == null)
            {
                existUser = await _userManager.FindByEmailAsync(loginVm.UsernameOrEmail);
                if(existUser==null)
                {
                    ModelState.AddModelError(String.Empty, "Username ve ya Password Sefdir");
                    return View();
                }
            }
            var signInCheck = _signInManager.CheckPasswordSignInAsync(existUser, loginVm.Password, true).Result;
            if (signInCheck.IsLockedOut)
            {
                ModelState.AddModelError("", "biraz sonra yeniden cehd edin");
                return View();
            }
            if (!signInCheck.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username ve ya Password Sefdir");
                return View();
            }
            await _signInManager.SignInAsync(existUser, loginVm.RememberMe);
            if(ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction(nameof(Index),"Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
           foreach(var role in Enum.GetValues(typeof(UserRole)))
            {
                if(!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = role.ToString(),
                    });
                }
            }

            return RedirectToAction(nameof(Index), "home");
        }
    }
}
