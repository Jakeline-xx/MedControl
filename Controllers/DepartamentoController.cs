using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedControl.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public IActionResult Index()
        {
            var departamentos = _departamentoRepository.ObterTodos();
            return View(departamentos);
        }

        public IActionResult Detalhes(Guid id)
        {
            var departamento = _departamentoRepository.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(DepartamentoViewModel departamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                Departamento departamento = departamentoViewModel;
                _departamentoRepository.Adicionar(departamento);
                return RedirectToAction("Index");
            }

            return View(departamentoViewModel);
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var departamento = await _departamentoRepository.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            var viewModel = new DepartamentoViewModel
            {
                Nome = departamento.Nome,
                Descricao = departamento.Descricao
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(DepartamentoViewModel departamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                Departamento departamento = departamentoViewModel;
                await _departamentoRepository.Atualizar(departamento);
                return RedirectToAction("Index");
            }

            return View(departamentoViewModel);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            var departamento = await _departamentoRepository.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(Guid id)
        {
            _departamentoRepository.Remover(id);
            return RedirectToAction("Index");
        }
    }

}