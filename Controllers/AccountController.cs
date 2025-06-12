using GymApp.Models;
using GymApp.Repository.Interfaces;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GymApp.Controllers
{
    public class AccountController : Controller
    {
        GymManagementContext2 con;
        ITraineeRepository trainee;
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public AccountController(ITraineeRepository repo, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,GymManagementContext2 c)
        {
            trainee = repo;
            con = c;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Signup()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            SignupViewModel model = new SignupViewModel();
            SetListItemsValues(ref model);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser exist = await userManager.FindByEmailAsync(userFromReq.Email);
                if (exist != null)
                {
                    ModelState.AddModelError("Email", "Email already registered");
                    SetListItemsValues(ref userFromReq);
                    return View("Signup", userFromReq);
                }

                ApplicationUser user = new ApplicationUser()
                {
                    Email = userFromReq.Email,
                    UserName = userFromReq.Email,
                    PasswordHash = userFromReq.Password,
                    DisplayName = userFromReq.FullName

                };

                IdentityResult res = await userManager.CreateAsync(user, userFromReq.Password);
                if (res.Succeeded)
                {

                    Trainee t = new Trainee()
                    {

                        FullName = userFromReq.FullName,
                        Phone = userFromReq.Phone,
                        Email = userFromReq.Email,
                        Gender = userFromReq.Gender.ToString(),
                        MembershipTypeID = userFromReq.MembershipType,
                        CoachID = userFromReq.CoachID,
                        DietPlanID = userFromReq.DietPlan,
                        ClassID = userFromReq.ClassID,
                        JoinDate = DateOnly.FromDateTime(DateTime.Today),
                        DOB = userFromReq.DOB,

                    };
                    trainee.Add(t);
                    IdentityResult role = await userManager.AddToRoleAsync(user, "Trainee");
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("Displayname", userFromReq.FullName));
                    await signInManager.SignInWithClaimsAsync(user, false, claims);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in res.Errors)
                    ModelState.AddModelError("", item.Description);
            }

            SetListItemsValues(ref userFromReq);
            return View(userFromReq);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userDB = await userManager.FindByEmailAsync(userFromReq.Email);
                if (userDB != null)
                {

                    bool ok = await userManager.CheckPasswordAsync(userDB, userFromReq.Password);
                    if (ok)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Displayname", userDB.DisplayName));
                        await signInManager.SignInWithClaimsAsync(userDB, userFromReq.RememberMe, claims);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Invalid credentials");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public void SetListItemsValues(ref SignupViewModel userFromReq )
        {
            userFromReq.GenderOptions = new List<SelectListItem> {
                new SelectListItem { Value = "M", Text = "Male" },
    new SelectListItem { Value = "F", Text = "Female" }
                };
            userFromReq.MembershipTypes = con.MembershipTypes.Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Name.ToString()
                    }
                    ).ToList();

            userFromReq.DietPlanTypes = con.DietPlans.Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Title.ToString()
                    }
                    ).ToList();
            userFromReq.Classes = con.Classes.Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.Name.ToString()
                    }
                    ).ToList();
            userFromReq.Coaches = con.Coaches.Select(
                    m => new SelectListItem
                    {
                        Value = m.ID.ToString(),
                        Text = m.FullName.ToString()
                    }
                    ).ToList();
        }

    }
}
