using System.ComponentModel;

namespace ParOuImpar;
class Program
{
    static void Main(string[] args)
    {
        List<int> pares = new List<int>();
        List<int> impares = new List<int>();
        
        for(int numero = 0; numero <= 100; numero++)
        {
            if (numero % 2 == 0)
            {
                pares.Add(numero);
                //Console.WriteLine($"O numero {numero} é par");
            }
            else
            {
                impares.Add(numero);
                //Console.WriteLine($"O numero {numero} é ímpar");
            }
        }
        Console.WriteLine("Valores Pares: " + string.Join(", ", pares));
        Console.WriteLine("Valores Impares: " + string.Join(", ", impares));
    }
    
}
