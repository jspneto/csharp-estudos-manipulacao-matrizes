namespace Projeto.Src.IO;

static class MatrizInputs
{
    public static Matriz CriarMatriz()
    {
        Console.Write("> Entre com o número de linhas (M) da matriz: ");
        int m = int.Parse(Console.ReadLine()!);
        
        while(!Matriz.IndiceValido(m))
        {
            Console.Write("  O número de linhas deve ser maior do que zero. Digite novamente: ");
            m = int.Parse(Console.ReadLine()!);
        }        
        
        Console.Write("> Entre com o número de colunas (N) da matriz: ");
        int n = int.Parse(Console.ReadLine()!);

        while(!Matriz.IndiceValido(n))
        {
            Console.Write("  O número de colunas deve ser maior do que zero. Digite novamente: ");
            n = int.Parse(Console.ReadLine()!);
        }

        Matriz mat = new(m,n);

        return mat;
    }
}