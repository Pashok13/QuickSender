using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using MessageSender.BLL.DTO;
using System.Security.Claims;
using MessageSender.BLL.Interfaces;
using MessageSender.BLL.Infrastructure;
using MessageSender.Models;

namespace MessageSender.Controllers
{
	public class AccountController : Controller
	{
		private IUserService UserService
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<IUserService>();
			}
		}

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
				ClaimsIdentity claim = await UserService.Authenticate(userDto);
				if (claim == null)
				{
					ModelState.AddModelError("", "Ivcorrect login or password");
				}
				else
				{
					AuthenticationManager.SignOut();
					AuthenticationManager.SignIn(new AuthenticationProperties
					{
						IsPersistent = true
					}, claim);
					return RedirectToAction("Index", "Home");
				}
			}
			return View(model);
		}

		public ActionResult Logout()
		{
			AuthenticationManager.SignOut();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				UserDTO userDto = new UserDTO
				{
					Email = model.Email,
					Password = model.Password,
					Name = model.Name,
					Phone = model.PhoneNumber
					//Role = "user"
				};
				OperationDetails operationDetails = await UserService.Create(userDto);
				if (operationDetails.Succedeed)
					return RedirectToAction("Index", "Home");
				else
					ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
			}
			return View(model);
		}

		//private async Task SetInitialDataAsync()
		//{
		//	await UserService.SetInitialData(new UserDTO
		//	{
		//		Email = "admin@mail.ru",
		//		Password = "admin",
		//		Name = "Pasha",
		//		Role = "admin",
		//	}, new List<string> { "user", "admin" });
		//}

	}
}