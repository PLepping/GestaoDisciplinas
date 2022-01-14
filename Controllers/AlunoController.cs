using GestaoEscolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestaoEscolar.Controllers
{
    public class AlunoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Aluno> Alunos = Aluno.listarAlunos();
            
            return View(Alunos);
        }



        [HttpPost]
        public IActionResult Index(int idAluno, int idDisciplina, string nomeAluno)
        {
            //string exclusao = Aluno.excluirAluno(idAluno);
            //ViewBag.nomeAluno = nomeAluno;
            List<Aluno> Alunos = Aluno.listarAlunosPelaDisciplina(idAluno);

            return View(Alunos);
        }

        public IActionResult alunos()
        {
            List<Aluno> Alunos = Aluno.listarAlunos();
            return View(Alunos);
        }

       /* public IActionResult cadastrarAluno()
        {
            return View();
        }*/

        /*
        [HttpPost]
        public IActionResult cadastrarAluno(string Nome, string RA, string DtNascimento)
        {
            //string sucesso = Aluno.cadastrarAluno(Nome, RA, DtNascimento);

            ViewBag.sucesso = sucesso;
            return View();
        }*/
    }
}
