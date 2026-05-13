using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEc2.Models;
using MvcCorePostgresEc2.Repositories;

namespace MvcCorePostgresEc2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetDepartamentosAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await this.repo.FindDepartamentoAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.CreateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
