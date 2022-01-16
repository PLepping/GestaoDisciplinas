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
            Contexto db = new Contexto();
            /*db.Disciplinas.Add(new Disciplina()
            {
                Nome = "Estruturas de Dados III",
                Semestre = Semestre,
                Curso = "BCC"
            }); 
            db.SaveChanges();*/

            /*var disciplinas = db.Disciplinas.ToList();
            var disciplina = disciplinas.Where(x => x.IdDisciplina == 20).FirstOrDefault();
            disciplina.Nome = "novoNome";
            db.SaveChanges();
            db.Disciplinas.Remove(disciplina);
            db.SaveChanges();*/

            var disciplina = db.Disciplinas.Where(x => x.IdDisciplina == 19).FirstOrDefault();

            var aluno = db.Alunos.Where((x) => x.IdAluno == 5).FirstOrDefault();
            var alunoDisciplina = new AlunoDisciplina()
            {
                IdAluno = aluno.IdAluno,
                Aluno = aluno,
                Disciplina =disciplina,
                IdDisciplina = disciplina.IdDisciplina
            };
            disciplina.AlunoDisciplinas.Add(alunoDisciplina);
            db.SaveChanges();


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
