using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letrex
{
    //http://www.dreamsincode.com/blog/2010/02/25/trie-uma-estrutura-de-alta-performance-de-pesquisa/

    class ArvoreTrie
    {
        public Dictionary<char, ArvoreTrie> filhas;
        public bool final;

        public ArvoreTrie() { }

        public ArvoreTrie(string palavra)
        {
            this.filhas = new Dictionary<char, ArvoreTrie>();
            this.final = false;
            this.Inserir(palavra);
        }

        public void Inserir(string palavra) // Exemplo: macaco
        {
            if (palavra.Length > 0) 
            {
                if (!this.filhas.ContainsKey(palavra[0])) 
                {
                    ArvoreTrie newTrie = new ArvoreTrie(this.GetSufixo(palavra));
                    this.filhas.Add(palavra[0], newTrie);
                }
                else 
                    this.filhas[palavra[0]].Inserir(this.GetSufixo(palavra)); 
            }
            else
                this.final = true;
        }

        public bool Contem(string palavra)
        {
            if (palavra.Length == 0)
                return this.final;
            else if (this.filhas.ContainsKey(palavra[0]))
                return this.filhas[palavra[0]].Contem(this.GetSufixo(palavra));
            else
                return false;
        }

        private string GetSufixo(string palavra)
        {
            if (palavra.Length > 1)
                return palavra.Substring(1);
            else
                return "";
        }
    }
}
