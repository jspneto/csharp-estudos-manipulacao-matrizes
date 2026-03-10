using Projeto.Src;
using Projeto.Src.IO;

namespace Projeto;

static class ProgramExamples
{
    public static void SolucaoProblema()
    {
        Matriz matriz = MatrizInputs.CriarMatriz();

        Console.WriteLine();
        Console.WriteLine("> Digite os elementos da matriz:");
        
        for (int i = 0; i < matriz.M; i++)
        {
            for (int j = 0; j < matriz.N; j++)
            {
                Console.Write($"  - [{i},{j}]: ");
                int elemento = int.Parse(Console.ReadLine()!);
                matriz.InserirNumero(i, j, elemento);
            }
        }

        Console.WriteLine();
        matriz.ImprimirMatriz();
        Console.WriteLine();

        Console.Write("> Digite um número que pertença a matriz: ");
        int numero = int.Parse(Console.ReadLine()!);
        
        while (!matriz.NumeroExiste(numero))
        {
            Console.Write($"  O número {numero} não existe nessa matriz. Digite novamente: ");
            numero = int.Parse(Console.ReadLine()!);
        }
        
        List<int[]> posicaoVizinhos = matriz.GerarListaPosicoes(numero);
        List<int?[]> listaVizinhos = matriz.GerarListaVizinhos(posicaoVizinhos);

        Console.WriteLine();
        Console.WriteLine($"> O número {numero} aparece {posicaoVizinhos.Count} vez(es) nessa matriz.");
        
        for (int i = 0; i < posicaoVizinhos.Count; i++)
        {
            string? esq = (listaVizinhos[i][0] != null) ? listaVizinhos[i][0].ToString() : "Não Existe";
            string? acm = (listaVizinhos[i][1] != null) ? listaVizinhos[i][1].ToString() : "Não Existe";
            string? dir = (listaVizinhos[i][2] != null) ? listaVizinhos[i][2].ToString() : "Não Existe";
            string? abx = (listaVizinhos[i][3] != null) ? listaVizinhos[i][3].ToString() : "Não Existe";
            
            Console.WriteLine();
            Console.WriteLine($"  - Posição [{posicaoVizinhos[i][0]},{posicaoVizinhos[i][1]}]: ");
            Console.WriteLine($"    Esquerda: {esq}.");
            Console.WriteLine($"    Acima: {acm}.");
            Console.WriteLine($"    Direita: {dir}.");
            Console.WriteLine($"    Abaixo: {abx}.");
        }
    }
}