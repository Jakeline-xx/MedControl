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

        public async Task<IActionResult> Index()
        {
            var departamentos = await _departamentoRepository.ObterTodos();

            var departamentoViewModels = departamentos.Select(departamento => (DepartamentoViewModel)departamento).ToList();

            return View(departamentoViewModels);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var departamento = await _departamentoRepository.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }
            DepartamentoViewModel departamentoViewModel = departamento;
            return View(departamentoViewModel);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(DepartamentoViewModel departamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                Departamento departamento = departamentoViewModel;
                await _departamentoRepository.Adicionar(departamento);
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
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();
            }
            var departamento = await _departamentoRepository.ObterPorId(id);

            if (departamento == null)
            {
                return NotFound();
            }

            DepartamentoViewModel departamentoViewModel = departamento;

            return View(departamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var departamentoFuncionarios = await _departamentoRepository.ObterDepartamentoFuncionarios(id);

            if (departamentoFuncionarios.Funcionarios.Count > 0)
            {
                var mensagem = "Não é possível excluir o departamento, pois existem funcionários vinculados";
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("Excluir", new { id });
            }

            await _departamentoRepository.Remover(id);
            return RedirectToAction("Index");
        }
    }

}