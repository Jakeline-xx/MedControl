using MedControl.Data.Repositories.Abstractions;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

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
            var estoques = await _estoqueRepository.ObterEstoqueMedicamentos();

            var estoqueViewModel = estoques.Select(estoque => (EstoqueViewModel)estoque).ToList();

            return View(estoqueViewModel);
        }
        // ...

        public async Task<IActionResult> ExportarExcel()
        {
            var estoques = await _estoqueRepository.ObterEstoqueMedicamentos();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("EstoqueMedicamentos");

                worksheet.Cells["A1"].Value = "Nome";
                worksheet.Cells["B1"].Value = "Quantidade Disponivel";

                for (int i = 0; i < estoques.Count; i++)
                {
                    worksheet.Cells[$"A{i + 2}"].Value = estoques[i].Medicamento.Nome;
                    worksheet.Cells[$"B{i + 2}"].Value = estoques[i].QuantidadeDisponivel;
                }

                var stream = new MemoryStream(package.GetAsByteArray());

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EstoqueMedicamentos.xlsx");
            }
        }

    }
}
