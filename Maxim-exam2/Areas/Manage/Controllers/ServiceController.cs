using Maxim_exam2.DAL;
using Maxim_exam2.Models;
using Maxim_exam2.Utilities;
using Maxim_exam2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Maxim_exam2.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class ServiceController : Controller
	{
		readonly AppDbContext _context;
		readonly IWebHostEnvironment _env;


		public ServiceController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		public IActionResult Index()
		{
			return View(_context.Services.ToList());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(CreateServiceVM serviceVM)
		{
			if (!ModelState.IsValid) BadRequest();
			string result = serviceVM.Image.CheckValidate("assets/", 900);
			if (result.Length > 0)
			{
				ModelState.AddModelError("Image", result);
			}
			Service service = new Service
			{
				Name = serviceVM.Name,
				Description = serviceVM.Description,
				ImageUrl = serviceVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img"))
			};
			_context.Services.Add(service);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));

		}
		public IActionResult Update(int? id)
		{
			if (id == null) BadRequest();
			Service service = _context.Services.Find(id);
			if (service == null) NotFound();
			UpdateServiceVM serviceVM = new UpdateServiceVM
			{
				Name = service.Name,
				Description = service.Description,
				ImageUrl = service.ImageUrl
			};
			return View(serviceVM);
		}
		[HttpPost]
		public IActionResult Update(int? id, UpdateServiceVM serviceVM)
		{
			if (id == null || id == 0||serviceVM== null) BadRequest();
			if(ModelState.IsValid) BadRequest();
			Service service = _context.Services.Find(id);
			if (service != null) NotFound();
			if (serviceVM.Image != null)
			{
				string result = serviceVM.Image.CheckValidate("image/", 900);
				if (result.Length > 0)
				{
					ModelState.AddModelError("Image", result);
				}
				service.ImageUrl.DeleteFile(_env.WebRootPath, "assets/img");
				serviceVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img"));
			}
			service.Name = serviceVM.Name;
			service.Description = serviceVM.Description;
			if (serviceVM.ImageUrl != null)
			{
				service.ImageUrl = serviceVM.Image.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img"));
			}
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
		public IActionResult Delete(int? id)
		{
			if(id==null) BadRequest();
			Service service=_context.Services.Find(id);
			if (service!=null) NotFound();
			service.ImageUrl.DeleteFile(_env.WebRootPath, "assets/img");
			_context.Services.Remove(service);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
