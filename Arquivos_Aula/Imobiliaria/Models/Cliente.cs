using System;
using System.ComponentModel.DataAnnotations; //decoretors
using System.ComponentModel.DataAnnotations.Schema; 

namespace Imobiliaria.Models
{
    public class Cliente
    {
        public int Id {get; set;} //declaração sem a necessidade de criar um método

        //validação para o nome
        [StringLength(100,MinimumLength = 3)]
        [Required] //nome agora e um atributo requerido
        public string Nome {get; set;} = null!;

        [StringLength(12,MinimumLength = 12)]
        [Required]
        public string Cpf {get; set;} = null!;

        //[DataType(DataType.Date)]
        //[Display(Name="Data de Nascimento")]
        //public DateTime DataNascimento {get; set;}

        [Required]
        public string Email {get; set;} = null!;

        // Relacionamentos
        // Collections do Cliente
        // Coleção de contratos
        public virtual ICollection<Contrato> Contratos{get; set;}
    }

}
