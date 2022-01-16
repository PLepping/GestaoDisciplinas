using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar.Models
{
    public class AlunoDisciplina
    {
        
        //public int IdAlunoDisciplina { get; set; }
        [ForeignKey("Aluno")]
        public int IdAluno { get; set; }
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("Disciplina")]
        public int IdDisciplina { get; set; }
        public  virtual Disciplina Disciplina { get; set; }


        public AlunoDisciplina()
        {

        }
    }

    
}
