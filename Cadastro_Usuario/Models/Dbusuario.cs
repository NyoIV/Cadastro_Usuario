using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Usuario.Models
{
    [Table("usuario", Schema = "public")]
    public class Dbusuario
    {
        [Key]

        public int id { get; set; }
        public string nome { get; set; }
        public string email  { get; set; }
        public DateTime? datanascimento {get; set; }
        public char sexo { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string cep   { get; set; }
        public string cidade   { get; set; }
        public string estado { get; set; }
        public string mensagem { get; set; }


      
    }
}
