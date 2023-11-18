using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedControl.Controllers
{
    public class UnidadeTrabalhoController : Controller
    {
        private readonly IUnidadeTrabalhoRepository _unidadeTrabalhoRepository;

        public UnidadeTrabalhoController(IUnidadeTrabalhoRepository unidadeTrabalhoRepository)
        {
            _unidadeTrabalhoRepository = unidadeTrabalhoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var unidadesTrabalho = await _unidadeTrabalhoRepository.ObterTodos();
            return View(unidadesTrabalho);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var unidadeTrabalho = await _unidadeTrabalhoRepository.ObterPorId(id);

            if (unidadeTrabalho == null)
            {
                return NotFound();
            }

            return View(unidadeTrabalho);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UnidadeTrabalhoViewModel unidadeTrabalhoViewModel)
        {
            if (ModelState.IsValid)
            {
                UnidadeTrabalho unidadeTrabalho = unidadeTrabalhoViewModel;
                await _unidadeTrabalhoRepository.Adicionar(unidadeTrabalho);
                return RedirectToAction("Index");
            }

            return View(unidadeTrabalhoViewModel);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var unidadeTrabalho = await _unidadeTrabalhoRepository.ObterPorId(id);

            if (unidadeTrabalho == null)
            {
                return NotFound();
            }

            var viewModel = new UnidadeTrabalhoViewModel
            {
                Nome = unidadeTrabalho.Nome,
                Logradouro = unidadeTrabalho.Logradouro
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UnidadeTrabalhoViewModel unidadeTrabalhoViewModel)
        {
            if (ModelState.IsValid)
            {
                UnidadeTrabalho unidadeTrabalho = unidadeTrabalhoViewModel;
                await _unidadeTrabalhoRepository.Atualizar(unidadeTrabalho);
                return RedirectToAction("Index");
            }

            return View(unidadeTrabalhoViewModel);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            var unidadeTrabalho = await _unidadeTrabalhoRepository.ObterPorId(id);

            if (unidadeTrabalho == null)
            {
                return NotFound();
            }

            return View(unidadeTrabalho);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            await _unidadeTrabalhoRepository.Remover(id);
            return RedirectToAction("Index");
        }
    }


}