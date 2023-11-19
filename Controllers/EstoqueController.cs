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
            var estoques = await _estoqueRepository.ObterTodos();

            var estoqueViewModel = estoques.Select(estoque => (EstoqueViewModel)estoque).ToList();

            return View(estoqueViewModel);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(EstoqueViewModel estoqueViewModel)
        {
            if (ModelState.IsValid)
            {
                Estoque estoque = estoqueViewModel;

                await _estoqueRepository.Adicionar(estoque);

                return RedirectToAction("Index");
            }

            return View(estoqueViewModel);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var estoque = await _estoqueRepository.ObterPorId(id);

            if (estoque == null)
            {
                return NotFound();
            }

            EstoqueViewModel estoqueViewModel = estoque;

            return View(estoqueViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EstoqueViewModel estoqueViewModel)
        {
            if (ModelState.IsValid)
            {
                Estoque estoque = estoqueViewModel;

                await _estoqueRepository.Atualizar(estoque);

                return RedirectToAction("Index");
            }

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

        public async Task<IActionResult> Excluir(Guid id)
        {
            var estoque = await _estoqueRepository.ObterPorId(id);

            if (estoque == null)
            {
                return NotFound();
            }

            EstoqueViewModel estoqueViewModel = estoque;

            return View(estoqueViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var estoque = await _estoqueRepository.ObterPorId(id);

            if (estoque == null)
            {
                return NotFound();
            }

            await _estoqueRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
