using System;
using System.ComponentModel.DataAnnotations; //decoretors
using System.ComponentModel.DataAnnotations.Schema; 

namespace Imobiliaria.Models;

public class Contrato
{
    // Atributos
    public int Id { get; set; }
    public int ClienteId  { get; set; }
    public int ImoveisId { get; set; }

    [Display(Name="Data de Assinatura")]
    [DataType(DataType.Date)]
    public DateTime DataAssinatura { get; set; }

    [DataType(DataType.Currency)]
    public double Valor { get; set; }

    // Relacionamentos
    public virtual Cliente Cliente { get; set; }
    public virtual Imoveis Imoveis{ get; set; }
}
