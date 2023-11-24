using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace MedControl.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ILogger<MedicamentoController> _logger;
        public MedicamentoController(IMedicamentoRepository medicamentoRepository,
                                     IEstoqueRepository estoqueRepository,
                                     ITransacaoRepository transacaoRepository,
                                     ILogger<MedicamentoController> logger)
        {
            _medicamentoRepository = medicamentoRepository;
            _estoqueRepository = estoqueRepository;
            _transacaoRepository = transacaoRepository;
            _logger = logger;
        }


        public async Task<Object> Teste()
        {
            try
            {
                return await _medicamentoRepository.ObterTodos();
            }
            catch (Exception e)
            {
                var exceptionJson = JsonConvert.SerializeObject(e);
                return exceptionJson;
            }
        }

        public async Task<IActionResult> Index()
        {
            var medicamentos = await _medicamentoRepository.ObterTodos();

            var medicamentoViewModel = medicamentos.Select(medicamento => (MedicamentoViewModel)medicamento).ToList();

            return View(medicamentoViewModel);
        }

        public IActionResult Criar()
        {
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();

                string viewModelJson = TempData["ViewModel"].ToString();
                MedicamentoViewModel viewModel = System.Text.Json.JsonSerializer.Deserialize<MedicamentoViewModel>(viewModelJson);

                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(MedicamentoViewModel medicamentoViewModel)
        {
            if (!ModelState.IsValid)
                return View(medicamentoViewModel);

            var medicamentoExistente = await _medicamentoRepository.Buscar(medicamento => medicamento.Nome == medicamentoViewModel.Nome);

            if (medicamentoExistente.Any())
            {
                var mensagem = "Não é possível criar medicamentos duplicados";
                TempData["Mensagem"] = mensagem;
                TempData["ViewModel"] = System.Text.Json.JsonSerializer.Serialize(medicamentoViewModel);
                return RedirectToAction("Criar");
            }


            Medicamento medicamento = medicamentoViewModel;

            medicamento.Estoque = new Estoque
            {
                IdMedicamento = medicamento.Id,
                QuantidadeDisponivel = 0
            };
            await _medicamentoRepository.Adicionar(medicamento);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var medicamento = await _medicamentoRepository.ObterPorId(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            MedicamentoViewModel medicamentoViewModel = medicamento;

            return View(medicamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MedicamentoViewModel medicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                Medicamento medicamento = medicamentoViewModel;

                await _medicamentoRepository.Atualizar(medicamento);

                return RedirectToAction("Index");
            }

            return View(medicamentoViewModel);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var medicamento = await _medicamentoRepository.ObterPorId(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            MedicamentoViewModel medicamentoViewModel = medicamento;

            return View(medicamentoViewModel);
        }

        public async Task<IActionResult> Excluir(Guid id)
        {
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();
            }
            var medicamento = await _medicamentoRepository.ObterPorId(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            MedicamentoViewModel medicamentoViewModel = medicamento;

            return View(medicamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var medicamento = await _medicamentoRepository.ObterPorId(id);

            if (medicamento == null)
            {
                return NotFound();
            }
            var estoqueMedicamento = await _medicamentoRepository.ObterMedicamentoEstoque(id);
            if (estoqueMedicamento.Estoque.QuantidadeDisponivel > 0)
            {
                var mensagem = $"Não é possível excluir o Medicamento {estoqueMedicamento.Nome}, pois existem quantidades disponvieis em estoque";
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("Excluir", new { id });
            }
            var transacoes = await _transacaoRepository.Buscar(t => t.IdEstoque == estoqueMedicamento.Estoque.Id);

            _transacaoRepository.RemoverMultiplos(transacoes);

            await _estoqueRepository.Remover(estoqueMedicamento.Estoque.Id);
            await _medicamentoRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
