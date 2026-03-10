namespace Projeto.Src;

class Matriz
{
    public int M { get; private set; }
    public int N { get; private set; }
    private readonly int[,] _matriz;

    public Matriz(int m, int n)
    {
        M = IndiceValido(m) ? m : 1;
        N = IndiceValido(n) ? n : 1;
        _matriz = new int[M,N];
    }

    private bool[] VizinhosExistem(int[] posicao)
    {
        bool esquerda = (posicao[1] - 1) >= 0;
        bool acima = (posicao[0] - 1) >= 0;
        bool direita = (posicao[1] + 1) < N;
        bool abaixo = (posicao[0] + 1) < M;

        return [esquerda, acima, direita, abaixo];
    }

    private int?[] ColetarVizinhos(int[] posicao)
    {
        int?[] vizinhos = new int?[4];
        bool[] vizinhosExistem = VizinhosExistem(posicao);

        vizinhos[0] = vizinhosExistem[0] ? _matriz[posicao[0], posicao[1] - 1] : null;
        vizinhos[1] = vizinhosExistem[1] ? _matriz[posicao[0] - 1, posicao[1]] : null;
        vizinhos[2] = vizinhosExistem[2] ? _matriz[posicao[0], posicao[1] + 1] : null;
        vizinhos[3] = vizinhosExistem[3] ? _matriz[posicao[0] + 1, posicao[1]] : null;
        
        return vizinhos;
    }

    public static bool IndiceValido(int indice)
    {
        return indice > 0;
    }

    public bool NumeroExiste(int numero)
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (numero == _matriz[i,j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void InserirNumero(int m, int n, int numero)
    {
        if (m >= 0 && m < M && n >= 0 && n < N)
        {
            _matriz[m,n] = numero;
        }
    }

    public void ImprimirMatriz()
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"{_matriz[i,j],5:D4}");
            }

            Console.WriteLine();
        }
    }

    public List<int[]> GerarListaPosicoes(int numero)
    {
        
        List<int[]> lista = [];

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (_matriz[i,j] == numero)
                {
                    lista.Add([i, j]);
                }
            }
        }

        return lista;
    }

    public List<int?[]> GerarListaVizinhos(List<int[]> posicoes)
    {
        List<int?[]> listaVizinhos = [];

        for (int i = 0; i < posicoes.Count; i++)
        {
            listaVizinhos.Add(ColetarVizinhos(posicoes[i]));
        }

        return listaVizinhos;
    }
}