using System;
using System.Collections.Generic;

namespace buscaLargura
{
    class Grafo
    {
        private int numVertices;
        private List<Tuple<int,int>> arestas;
        private Cor [] cor;
        private int [] d; //Vai marcar a distância entre os vértices
        private int [] pi; //Marca os antecedentes dos vértices
        private List<List<int>> listaAdjacencia;
        Queue<int> filaVertices; //Fila para controle dos vértices a serem visitados
        enum Cor {Branco,Cinza,Preto};
        public Grafo(int numVertices, int numArestas)
        {
            this.numVertices = numVertices;
            arestas = new List<Tuple<int, int>>();
            this.cor = new Cor[numVertices];
            this.d = new int[numVertices];
            this.pi = new int[numVertices];
            listaAdjacencia = new List<List<int>>();
            for(int i=0;i<numVertices;i++)
                listaAdjacencia.Add(new List<int>());      
            filaVertices = new Queue<int>();      
        } 
        public void adicionarAresta(int origem, int destino)
        {
            arestas.Add(new Tuple<int, int>(origem,destino));
            listaAdjacencia[origem].Add(destino);
        }
        public void bfs(int s)
        {
            for(int i=0;i<numVertices;i++)
            {
                cor[i] = Cor.Branco;
                d[i] = int.MinValue;
                pi[i] = -1;
            }
            cor[s] = Cor.Cinza;
            d[s] = 0;
            pi[s] = -1;
            filaVertices = new Queue<int>();
            filaVertices.Enqueue(s);

            while (filaVertices.Count > 0)
            {
                int u = filaVertices.Dequeue(); 
                for(int i =0;i<listaAdjacencia[u].Count;i++)
                {
                    int v = listaAdjacencia[u][i];
                    if(cor[v]==Cor.Branco)
                    {
                        cor[v] = Cor.Cinza;
                        pi[v] =u;
                        d[v] = d[u] + 1;
                        filaVertices.Enqueue(v);
                    }
                }
                cor[u]=Cor.Preto;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
