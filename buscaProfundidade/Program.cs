using System.Threading.Tasks.Dataflow;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace buscaProfundidade
{
    class Grafo
    {
        private int numVertices;
        private List<Tuple<int,int>> arestas;
        private string [] cor;
        private int [] d; //Tempo de descoberta
        private int [] f; //Tempo de finalização
        private List <List<int>> listaAdjacencia;

        private int contador = 0;

        public Grafo(int numVertices, int numArestas)
        {
            this.numVertices = numVertices;
            arestas = new List<Tuple<int,int>>();
            this.cor = new string[numVertices];
            this.contador = 0;
            this.d = new int[numVertices];
            this.f = new int[numVertices];
            listaAdjacencia = new List <List<int>>();
            for(int i=0;i<numVertices;i++)
                 listaAdjacencia.Add(new List<int>());
        }

        public void adicionarAresta(int origem, int destino)
        {
            //Adiciona a aresta
            arestas.Add(new Tuple<int,int>(origem, destino));
            //Atualiza a lista de adjacência
            listaAdjacencia[origem].Add(destino);
        }

        public void dfs()
        {
            for( int i=0; i<numVertices; i++)
               cor[i] = "Branco";
            contador++;
            for(int i=0;i<numVertices; i++)
                if(cor[i]=="Branco")
                    dfsVisita(i);
        }

        public void dfsVisita(int i)
        {
            cor[i] = "Cinza";
            contador+=1;
            d[i] = contador; //Marca o tempo de descoberta do vértice

            foreach(int vizinho in listaAdjacencia[i])
                if(cor[vizinho]=="Branco")
                      dfsVisita(vizinho);

            cor[i] = "Preto"; //Marcar como finalizado
            contador+=1;
            f[i] = contador; //Marca o tempo de finalização
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
