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
        private readonly IMedicamentoRepository _medicamentoRepository;

        public EstoqueController(IEstoqueRepository estoqueRepository,
                                 IMedicamentoRepository medicamentoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _medicamentoRepository = medicamentoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueRepository.ObterEstoqueMedicamentos();

            var estoqueViewModel = estoques.Select(estoque => (EstoqueViewModel)estoque).ToList();

            return View(estoqueViewModel);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var estoque = await _estoqueRepository.ObterPorId(id);

            if (estoque == null)
            {
                return NotFound();
            }

            EstoqueViewModel estoqueViewModel = estoque;

            return View(estoqueViewModel);
        }
    }
}
