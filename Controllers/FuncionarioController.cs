using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedControl.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();
            return View(funcionarios);
        }

        public IActionResult Detalhes(Guid id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = funcionarioViewModel;
                await _funcionarioRepository.Adicionar(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);
        }


        public async Task<IActionResult> Editar(Guid id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            var viewModel = new FuncionarioViewModel
            {
                Nome = funcionario.Nome,
                Cargo = funcionario.Cargo,
                Identificacao = funcionario.Identificacao,
                Telefone = funcionario.Telefone
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                Funcionario funcionario = funcionarioViewModel;
                await _funcionarioRepository.Atualizar(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);
        }

        public IActionResult Excluir(Guid id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            await _funcionarioRepository.Remover(id);
            return RedirectToAction("Index");
        }

    }
}