using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letrex
{
    /// 
    ///  C    A    R
    ///  |    |    | 
    /// A R  C R  C  A
    /// | |  | |  |  |
    /// R A  R C  A  C
    ///---------------------- 
    ///utilizando DFS: CAR-CRA  ACR-ARC  RCA-RAC
    public class node
    {
        public char value;
        public List<node> filhos = new List<node>();
        public node child;
    }

    class TodasAsCombinacoes
    {
        public List<string> todasCombinacoes = new List<string>();
        private List<node> tree = new List<node>();
        private int tamanho = 0;

        public TodasAsCombinacoes(string palavra)
        {
            tamanho = palavra.Length;
            int i = 0;
            /// cria uma arvore para cada letra da palavra
            string p = "";
            
            ///Evita arvores  com iniciai repetidas
            foreach (char c in palavra)
            {
                if (!p.ToLowerInvariant().Contains(c))
                    p += c;
            }
            Console.WriteLine(p);
            foreach (char c in palavra)
            {
                node a = new node();
                a.value = c;
                a.child = new node();
                makeTree(palavra.Remove(i,1),  ref a.child);
                i++;
                tree.Add(a);
            }

            // Uma arvore para cada letra da palavra
            // Percorre todas as arvores criando todas as combinacoes possiveis
            // preenchendo a lista this.todasCombiancoes
            foreach (node t in tree) 
                this.dsf(t, 0, "");

            //foreach (string x in this.todasCombinacoes)
            //     Console.WriteLine(x);
            //Console.WriteLine("Número de Combinações: {0}", this.todasCombinacoes.Count);
        
        }

        public void makeTree(string palavra, ref node no)
        {
            if (palavra.Length == 0)
                return;

            int i = 0;
            node o;
            for (int j = 0; j < palavra.Length; j++)
            {
                o = new node();
                no.filhos.Add(o);
                no.filhos[i].value = palavra[j];
                no.filhos[i].child = new node();
                makeTree(palavra.Remove(i, 1), ref no.filhos[i].child);
                i++;
            }

        }

        //depth search first para percorrer e gerar as combinacoes
        public void dsf(node no, int lv, string p)
        {
            //tamanho = numero de niveis da arvore
            if (lv > this.tamanho)
                return;
            if (lv > 0)
                foreach (node filho in no.filhos)
                {
                    //Adiona a nova combianacao conforme vai descendo a arvore
                    todasCombinacoes.Add(p + filho.value.ToString());
                    lv++;
                    dsf(filho.child, lv, p + filho.value.ToString());
                }
            else if (lv == 0) // inicializa a variavel p com a raiz da arvore
            {
                p = no.value.ToString();
                lv++;
                dsf(no.child, lv, p);
            }
        }
    }
}
