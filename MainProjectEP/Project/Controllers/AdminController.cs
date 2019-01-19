using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        //static ApplicationDbContext context = new ApplicationDbContext();
        //ApplicationManager manager = new ApplicationManager(new UserStore<ApplicationUser>(context));
        //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult AdminPage()
        {
            return View(UserManager.Users.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(string email)
        {
            var user = UserManager.FindByEmail(email);
            UserManager.Delete(user);
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model, string name)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Login = model.Login };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    if (name == "admin")
                    {
                        UserManager.AddToRole(user.Id, "admin");
                        UserManager.AddToRole(user.Id, "editor");
                    }
                    else
                    {
                        UserManager.AddToRole(user.Id, "editor");
                    }

                    return RedirectToAction("AdminPage", "Admin");
                }
                AddErrors(result);
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateUser(string name)
        {
            var userToDel = UserManager.FindByName(name);
            UserManager.Delete(userToDel);
            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateUser(RegisterViewModel model, string name)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Login = model.Login };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    if (name == "admin")
                    {
                        UserManager.AddToRole(user.Id, "admin");
                        UserManager.AddToRole(user.Id, "editor");
                    }
                    else
                    {
                        UserManager.AddToRole(user.Id, "editor");
                    }

                    return RedirectToAction("AdminPage", "Admin");
                }
                AddErrors(result);
            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
