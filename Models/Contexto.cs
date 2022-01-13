using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//minha versão sobre o metodo
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; initial Catalog=GestaoEscolar; User ID=sa;password=@D9y3v6w4@; Integrated Security=True");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(chaveComposta => new { chaveComposta.IdAluno, chaveComposta.IdDisciplina});
        }
    }
}
