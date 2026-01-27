using EstruturaDeDados.Cap1_Intro.Pratica;
using System;


//Cap 1 -Entendedo qual a estrutura de dados e sua importância
namespace EstruturaDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Criando uma fila de atendimento para um petshop ordenando sem prioridade
            Cap1Pratica.CriarNovoAtendimentoFilaOrdenado();
            //Criando uma fila de atendimento para um petshop com prioridade
            Cap1Pratica.CriarNovoAtendimentoFilaPrioritaria();
            //Utilizando um array não ordenado uma bag(saco)
            Cap1Pratica.CriarBagAtendimentoNaoOrdenado();
        }
    }
}
