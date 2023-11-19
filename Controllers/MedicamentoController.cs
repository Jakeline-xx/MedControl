using Microsoft.AspNetCore.Mvc;
using MedControl.Models;
using MedControl.ViewModels;
using MedControl.Data.Repositories.Abstractions;
using System.Text.Json;


namespace MedControl.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly IMedicamentoRepository _medicamentoRepository;

        public MedicamentoController(IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
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
                MedicamentoViewModel viewModel = JsonSerializer.Deserialize<MedicamentoViewModel>(viewModelJson);

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
                TempData["ViewModel"] = JsonSerializer.Serialize(medicamentoViewModel);
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

            await _medicamentoRepository.Remover(id);

            return RedirectToAction("Index");
        }
    }
}
