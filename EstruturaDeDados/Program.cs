using EstruturaDeDados.Cap1_Intro.Pratica;
using System;



namespace EstruturaDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CAP1 - INTRODUÇÃO ÀS ESTRUTURAS DE DADOS
            //Utilizando uma fila de atendimento para um petshop ordenando sem prioridade
            Cap1Pratica.CriarNovoAtendimentoFilaOrdenado();
            //Utilizando uma fila de atendimento para um petshop com prioridade
            Cap1Pratica.CriarNovoAtendimentoFilaPrioritaria();
            //Utilizando uma fila não ordenada uma bag(saco) para um petshop
            Cap1Pratica.CriarBagAtendimentoNaoOrdenado();
            #endregion

            #region CAP2 - ARRAYS ESTATICOS
            #endregion
        }
    }
}
