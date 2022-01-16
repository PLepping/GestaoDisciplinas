using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;


namespace GestaoEscolar.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public int RA { get; set; }
        public DateTime DtNascimento { get; set; }

        public virtual ICollection<Disciplina> AlunoDisciplinas { get; set; }
        
        public Aluno(int idAluno, string nome, int ra, DateTime dtNascimento)
        {
            IdAluno = idAluno;
            Nome = nome;
            RA = ra;
            DtNascimento = dtNascimento;
        }

        public Aluno()
        {

        }

        public static List<Aluno> listarAlunos()
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string select = "Select * from Alunos";
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            List<Aluno> Alunos = new List<Aluno>();
            while (sqlRead.Read())
            {
                Alunos.Add(new Aluno(int.Parse(sqlRead["IdAluno"].ToString()),
                                     sqlRead["Nome"].ToString(),
                                     int.Parse(sqlRead["RA"].ToString()),
                                     Convert.ToDateTime(sqlRead["DtNascimento"].ToString())));
            }
            return Alunos;
            minhaConexao.Close();
        }

        public static List<Aluno> listarAlunosPelaDisciplina(int idDisciplina)
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string select = "select * from Alunos inner join AlunoDisciplinas on Alunos.IdAluno = AlunoDisciplinas.IdAluno where AlunoDisciplinas.IdDisciplina = "+ idDisciplina;
            SqlCommand selectCommand = new SqlCommand(select, minhaConexao);
            SqlDataReader sqlRead = selectCommand.ExecuteReader();

            List<Aluno> Alunos = new List<Aluno>();
            while (sqlRead.Read())
            {
                Alunos.Add(new Aluno(int.Parse(sqlRead["IdAluno"].ToString()),
                                     sqlRead["Nome"].ToString(),
                                     int.Parse(sqlRead["RA"].ToString()),
                                     Convert.ToDateTime(sqlRead["DtNascimento"].ToString())));
            }
            return Alunos;
            minhaConexao.Close();
        }

       /* public static string cadastrarAluno(string nome, string ra, string dtNascimento)
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string insert = string.Format("Insert into Alunos (Nome,RA,DtNascimento) VALUES ('{0}', '{1}', '{2}')", nome, ra, dtNascimento);
            SqlCommand selectCommand = new SqlCommand(insert, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }

        public static string excluirAluno(int idAluno)
        {
            SqlConnection minhaConexao = new SqlConnection("Data Source = localhost; initial Catalog = GestaoEscolar; User ID = sa; password = @D9y3v6w4@; Integrated Security = True");
            minhaConexao.Open();

            string delete = string.Format("delete from Alunos where IdAluno = {0} ", idAluno);
            SqlCommand selectCommand = new SqlCommand(delete, minhaConexao);
            selectCommand.ExecuteNonQuery();

            return "Sucesso";
        }*/
    }
}
