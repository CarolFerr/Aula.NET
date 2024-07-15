using Microsoft.EntityFrameworkCore;
using UniMovie.Models;

namespace UniMovie.Data;
// essa classe herda as caracteristicas de DbContext
public class UnimovieContext : DbContext 
{
	public UnimovieContext (DbContextOptions<UnimovieContext> options)
	: base(options)
	{
	}
	
	//criação da tabela referente aos filmes
	public DbSet<Filme> Filmes {get; set;} = null!;
}