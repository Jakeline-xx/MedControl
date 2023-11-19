using Microsoft.AspNetCore.Mvc;
using MedControl.Models;
using MedControl.ViewModels;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedControl.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMedicamentoRepository _medicamentoRepository;

        public TransacaoController(ITransacaoRepository transacaoRepository,
                                   IFuncionarioRepository funcionarioRepository,
                                   IMedicamentoRepository medicamentoRepository)
        {
            _transacaoRepository = transacaoRepository;
            _funcionarioRepository = funcionarioRepository;
            _medicamentoRepository = medicamentoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var transacoes = await _transacaoRepository.ObterTodos();

            var transacaoViewModels = transacoes.Select(transacao => (TransacaoViewModel)transacao).ToList();

            return View(transacaoViewModels);
        }

        public async Task<IActionResult> Criar()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();

            ViewBag.Funcionarios = new SelectList(funcionarios, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid)
                return View(transacaoViewModel);

            Transacao transacao = transacaoViewModel;
            transacao.DataTransacao = DateTime.Now;

            await _transacaoRepository.Adicionar(transacao);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            TransacaoViewModel transacaoViewModel = transacao;

            return View(transacaoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid)
                return View(transacaoViewModel);

            Transacao transacao = transacaoViewModel;

            await _transacaoRepository.Atualizar(transacao);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            TransacaoViewModel transacaoViewModel = transacao;

            return View(transacaoViewModel);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            var transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            TransacaoViewModel transacaoViewModel = transacao;

            return View(transacaoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var transacao = await _transacaoRepository.ObterPorId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            await _transacaoRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
