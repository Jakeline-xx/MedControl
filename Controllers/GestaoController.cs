
using MedControl.Data.Repositories.Abstractions;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedControl.Controllers
{
    public class GestaoController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMedicamentoRepository _medicamentoRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IUnidadeTrabalhoRepository _unidadeTrabalhoRepository;
        public GestaoController(IFuncionarioRepository funcionarioRepository,
                                IDepartamentoRepository departamentoRepository,
                                IMedicamentoRepository medicamentoRepository,
                                ITransacaoRepository transacaoRepository,
                                IUnidadeTrabalhoRepository unidadeTrabalhoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _departamentoRepository = departamentoRepository;
            _medicamentoRepository = medicamentoRepository;
            _transacaoRepository = transacaoRepository;
            _unidadeTrabalhoRepository = unidadeTrabalhoRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new RelatorioAnaliticoViewModel
            {
                QtdDepartamentos = _departamentoRepository.ContarRegistros(),
                QtdFuncionarios = _funcionarioRepository.ContarRegistros(),
                QtdMedicamentos = _medicamentoRepository.ContarRegistros(),
                QtdTransacoes = _transacaoRepository.ContarRegistros(),
                QtdUnidadeTrabalho = _unidadeTrabalhoRepository.ContarRegistros()
            };
            return View(viewModel);
        }

    }
}