using System.ComponentModel.DataAnnotations; 

namespace Imobiliaria.Models;

public class Imoveis
{
    public int Id {get; set;} 
    public int Numero {get; set;}
    public decimal Valor {get; set;}
    public string Endereco {get; set;}
    public string Bairro {get; set;}
    public string Tipo {get; set;}

    // Relacionamentos
        // Collections do Imoveis
        // Coleção de contratos
        public virtual ICollection<Contrato> Contratos {get; set;}
}

    

