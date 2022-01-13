using GestaoEscolar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GestaoEscolar.Controllers
{
    public class DisciplinaController : Controller
    {
        [HttpGet]
        public IActionResult Index(int idAluno, string nomeAluno)
        {
           
            ViewBag.idAluno = idAluno;
            ViewBag.nomeAluno = nomeAluno;

            List<Disciplina> Disciplinas = Disciplina.listarDisciplinasPeloAluno(idAluno);

            return View(Disciplinas);
        }

        [HttpPost]
        public IActionResult Index(int idAluno, int idDisciplina, string nomeAluno)
        {
            string exclusao = Disciplina.excluirDisciplina(idAluno, idDisciplina);
            ViewBag.nomeAluno = nomeAluno;
            List<Disciplina> Disciplinas = Disciplina.listarDisciplinasPeloAluno(idAluno);
            
            return View(Disciplinas);
        }

        public IActionResult disciplinas()
        {
            List<Disciplina> Disciplinas = Disciplina.listarDisciplinas();
            return View(Disciplinas);
        }

        public IActionResult cadastrarDisciplina()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastrarDisciplina(string Nome, string Semestre, string Curso)
        {
            string sucesso = Disciplina.cadastrarDisciplina(Nome, Semestre, Curso); 

            ViewBag.sucesso = sucesso;
            return View();
        }
    }
}
