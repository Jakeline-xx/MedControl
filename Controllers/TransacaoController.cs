using Microsoft.AspNetCore.Mvc;
using MedControl.Models;
using MedControl.ViewModels;
using MedControl.Data.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedControl.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IEstoqueRepository _estoqueRepository;

        public TransacaoController(ITransacaoRepository transacaoRepository,
                                   IFuncionarioRepository funcionarioRepository,
                                   IMedicamentoRepository medicamentoRepository,
                                   IEstoqueRepository estoqueRepository)
        {
            _transacaoRepository = transacaoRepository;
            _funcionarioRepository = funcionarioRepository;
            _medicamentoRepository = medicamentoRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IActionResult> Index()
        {
            var transacoes = await _transacaoRepository.ObterTransacaoEstoqueMedicamento();

            var transacaoViewModels = transacoes.Select(transacao => (TransacaoViewModel)transacao).ToList();

            return View(transacaoViewModels);
        }

        public async Task<IActionResult> Criar()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();
            var medicamentos = await _medicamentoRepository.ObterTodos();

            ViewBag.Funcionarios = new SelectList(funcionarios, "Id", "Nome");
            ViewBag.Medicamentos = new SelectList(medicamentos, "Id", "Nome");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid)
                return View(transacaoViewModel);

            Transacao transacao = transacaoViewModel;
            transacao.DataTransacao = DateTime.Now;

            var estoque = await _estoqueRepository.ObterEstoqueMedicamentos(transacaoViewModel.Estoque.Medicamento.Id);
            transacao.IdEstoque = estoque.Id;

            estoque.QuantidadeDisponivel += transacaoViewModel.Quantidade;

            await _estoqueRepository.Atualizar(estoque);

            await _transacaoRepository.Adicionar(transacao);

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
    }
}
