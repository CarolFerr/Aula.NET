using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;

namespace Imobiliaria.Controllers
{
    public class HelloWorldController : Controller
    {
        //Ação padrão
        public IActionResult Index() // retorna o resultado de uma ação e essa ação é o index
        {
            return View(); // retorno da minha ação index, abre um componente na minha camada de view
        }

        //Ação especifica
        public IActionResult Welcome(string nome, int idade=1)
        {
            // A informação vai para um dicionario de dados(ViewData)
            ViewData["Mensagem"] = "Ola " + nome;
            ViewData["Idade"] = idade;
            return View();
        }

        // Dados de um cadastro de um cliente
        public IActionResult Destaques(int numeroRegistro, string nome, string livro, string email, string genreBook)
        {
            ViewData["ID"] = "id: " + numeroRegistro;
            ViewData["Mensagem"] = "Nome: " + nome;
            ViewData["Livro"] = "Livro que está Lendo: " + livro;
            ViewData["E-mail"] = "E-mail para envio do E-BOOK: " + email;
            ViewData["GeneroLivro"] = "Genero Preferido de Livro: " + genreBook;
            return View();
        }
    }
}