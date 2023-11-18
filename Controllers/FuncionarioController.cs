using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
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
        public async Task<IActionResult> Criar(Funcionario funcionario)
        {
            await _funcionarioRepository.Adicionar(funcionario);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(Guid id)
        {
            var funcionario = _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Funcionario funcionario)
        {
            await _funcionarioRepository.Atualizar(funcionario);
            return RedirectToAction("Index");
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