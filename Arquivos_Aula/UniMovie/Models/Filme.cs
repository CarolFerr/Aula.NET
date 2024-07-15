namespace UniMovie.Models;

public class Filme
{
	public int Id {get; set;}
	public string? Titulo {get; set;}
	public string? Genero {get; set;}
	public int AnoLancamento {get; set;}
	public int Duracao {get; set;} // em minutos
	public string? Distribuidora {get; set;} //secret
		
}