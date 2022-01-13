using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace GestaoEscolar.Models
{
    public class Disciplina
    {
        [Key]
        public int IdDisciplina { get; set; }
        public int? IdAluno { get; set; }
        public string Nome { get; set; }
        public string Semestre { get; set; }
        public string Curso { get; set; }
        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Disciplina(int iddisciplina, int idaluno, string nome, string semestre, string curso)
        {
            IdDisciplina = iddisciplina;
            IdAluno = idaluno;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
            Alunos = Aluno.listarAlunosPelaDisciplina(iddisciplina);
        }

        public Disciplina(int iddisciplina, string nome, string semestre, string curso)
        {
            IdDisciplina = iddisciplina;
            Nome = nome;
            Semestre = semestre;
            Curso = curso;
            Alunos = Aluno.listarAlunosPelaDisciplina(iddisciplina);
        }

        public static List<Disciplina> listarDisciplinasPeloAluno(int idAluno)
        {
            List<Disciplina> Disciplinas = new List<Disciplina>();

            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string select = "select * from Disciplinas inner join AlunoDisciplinas on Disciplinas.IdDisciplina = AlunoDisciplinas.IdDisciplina Where AlunoDisciplinas.IdAluno =" + idAluno;
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            while (sqlRead.Read())
            {
                Disciplinas.Add(new Disciplina(int.Parse(sqlRead["IdDisciplina"].ToString()),
                                               idAluno,
                                               sqlRead["Nome"].ToString(),
                                               sqlRead["Semestre"].ToString(),
                                               sqlRead["Curso"].ToString()));
            }
            return Disciplinas;
        }

        public static List<Disciplina> listarDisciplinas()
        {
            List<Disciplina> Disciplinas = new List<Disciplina>();

            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string select = "select * from Disciplinas";
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            while (sqlRead.Read())
            {
                Disciplinas.Add(new Disciplina(int.Parse(sqlRead["IdDisciplina"].ToString()),
                                               sqlRead["Nome"].ToString(),
                                               sqlRead["Semestre"].ToString(),
                                               sqlRead["Curso"].ToString()));
            }
            return Disciplinas;
        }


        public static string cadastrarDisciplina(string nome, string semestre, string curso)
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string insert = string.Format("Insert into Disciplinas (Nome,Semestre,Curso) VALUES ('{0}', '{1}', '{2}')", nome, semestre, curso);
            SqlCommand selectCommand = new SqlCommand(insert, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }

        public static string excluirDisciplina(int idAluno, int idDisciplina)
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string delete = string.Format("delete from AlunoDisciplinas where IdAluno = {0} and IdDisciplina = {1}", idAluno, idDisciplina);
            SqlCommand selectCommand = new SqlCommand(delete, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }
    }
}
