using BudgetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static NuGet.Packaging.PackagingConstants;

namespace BudgetApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private readonly ILogger<HomeController> logger;
        private readonly string _targetFilePath;
        public AccountController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr, ILogger<HomeController> l, IWebHostEnvironment webHostEnv)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            logger = l;
            _targetFilePath = webHostEnv.WebRootPath + "/" + FileHelpers.UPLOAD_FOLDER;  // Files folder in wwwRoot
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Username };
                // Temporary assignment of user's real name (screen name?)
                user.Name = user.UserName; // TODO: Add a field to the registration form for real name
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginVM { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");   
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /************* File Upload Action Methods ***********/

        private readonly long _fileSizeLimit = 2097162; // 2,097,162
        private readonly string[] _permittedExtensions = { ".jpg", ".png", ".jpeg" };
        public string Result { get; private set; }
      
/*        private readonly string _serverFilePath = "\\img\\";
*/
        public async Task<ViewResult> Index(AppUser model)
        {
            AppUser user = await userManager.GetUserAsync(User);
            if (user.ProfilePicture == "empty" || user.ProfilePicture == null)
            {
                if (model.ProfilePicture == "empty" || model.ProfilePicture == null)
                {
                    model.ProfilePicture = "\\img\\default.png";
                }
            } else
            {
                model.ProfilePicture = "\\img\\" + user.ProfilePicture;
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            AccountVM model = new();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(AccountVM model)
        {
            IFormFile formFile = model.Image;
            string fileExtensionType = formFile.ContentType.Remove(0, 5).Replace("/", ".");
            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";

                return View();
            }

            var formFileContent =
                await FileHelpers.ProcessFormFile<AccountVM>(
                    formFile, ModelState, _permittedExtensions,
                    _fileSizeLimit);

            if (!ModelState.IsValid)
            {
                Result = "Please correct the form.";
                return View();
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            var trustedFileNameForFileStorage = Path.GetRandomFileName(); 

            trustedFileNameForFileStorage = trustedFileNameForFileStorage
                .Remove((trustedFileNameForFileStorage
                .Count() - 5), 4) + fileExtensionType;
            var filePath = Path.Combine(
                _targetFilePath, trustedFileNameForFileStorage);

            //adding filepath to the user
            var user = await userManager.GetUserAsync(User);
            


            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems. 
            // For more information, see the topic that accompanies 
            // this sample.

            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with a FormFile, use the following
                // instead:
                //await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            if (user != null)
            {
                user.ProfilePicture = trustedFileNameForFileStorage;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index", user);
            }


            return RedirectToAction("Index");
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}
