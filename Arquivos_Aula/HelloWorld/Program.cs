namespace HelloWorld; //nome do projeto o equivalente em java a package
class Program
{
    static void Main(string[] args)
    {
        int numeroAnterior = 0;
        int numeroAtual = 1;
        int fibonacci;

        for (int i = 0; i < 10; i++)
        {
            fibonacci = numeroAnterior + numeroAtual; 
            Console.WriteLine(fibonacci);
            numeroAnterior = numeroAtual;
            numeroAtual = fibonacci;
        }
        
        
    }
}
