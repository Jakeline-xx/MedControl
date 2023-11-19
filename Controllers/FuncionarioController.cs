using MedControl.Data.Repositories;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedControl.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IUnidadeTrabalhoRepository _unidadeTrabalhoRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository,
                                    IDepartamentoRepository departamentoRepository,
                                    IUnidadeTrabalhoRepository unidadeTrabalhoRepository,
                                    ITransacaoRepository transacaoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _departamentoRepository = departamentoRepository;
            _unidadeTrabalhoRepository = unidadeTrabalhoRepository;
            _transacaoRepository = transacaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioRepository.ObterTodos();

            var funcionarioViewModels = funcionarios.Select(funcionario => (FuncionarioViewModel)funcionario).ToList();

            return View(funcionarioViewModels);
        }


        public async Task<IActionResult> Detalhes(Guid id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            var departamento = await _departamentoRepository.ObterPorId(funcionario.IdDepartamento);

            var unidadeTrabalho = await _unidadeTrabalhoRepository.ObterPorId(funcionario.IdUnidadeTrabalho);

            var detalhesViewModel = new FuncionarioDetalhesViewModel
            {
                Funcionario = funcionario,
                NomeDepartamento = departamento?.Nome,
                NomeUnidadeTrabalho = unidadeTrabalho?.Nome
            };

            return View(detalhesViewModel);
        }




        public async Task<IActionResult> Criar()
        {
            var departamentos = await _departamentoRepository.ObterTodos();

            var unidadesTrabalho = await _unidadeTrabalhoRepository.ObterTodos();

            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Nome");
            ViewBag.UnidadesTrabalho = new SelectList(unidadesTrabalho, "Id", "Nome");

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

            FuncionarioViewModel viewModel = funcionario;

            var departamentos = await _departamentoRepository.ObterTodos();

            var unidadesTrabalho = await _unidadeTrabalhoRepository.ObterTodos();

            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Nome", viewModel.IdDepartamento);
            ViewBag.UnidadesTrabalho = new SelectList(unidadesTrabalho, "Id", "Nome", viewModel.IdUnidadeTrabalho);


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

        public async Task<IActionResult> Excluir(Guid id)
        {
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"].ToString();
            }
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            FuncionarioViewModel funcionarioViewModel = funcionario;

            return View(funcionarioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(Guid id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
                return NotFound();

            var transacoes = await _transacaoRepository.Buscar(transacao => transacao.IdFuncionario == id);
            if (transacoes.Any())
            {
                var mensagem = $"Não é possível excluir o funcionario {funcionario.Nome}, pois existem transações vinculadas";
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("Excluir", new { id });
            }

            await _funcionarioRepository.Remover(id);

            return RedirectToAction("Index");
        }

    }
}