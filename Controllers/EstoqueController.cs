// EstoqueController.cs
using Microsoft.AspNetCore.Mvc;
using MedControl.Models;
using MedControl.ViewModels;
using MedControl.Data.Repositories.Abstractions;

namespace MedControl.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueController(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueRepository.ObterEstoqueMedicamentos();

            var estoqueViewModel = estoques.Select(estoque => (EstoqueViewModel)estoque).ToList();

            return View(estoqueViewModel);
        }
    }
}
