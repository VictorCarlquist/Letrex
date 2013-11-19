using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Letrex
{
    public partial class MainWindow : Form
    {
        // String de conexão para o Banco de Dados
        private string str_conexao = "Data Source=.\\SQLEXPRESS; Database=LOPAII; Integrated Security=SSPI;";

        // DataSet
        private DataSet dataSet;

        // DataAdpter para a tabela Verbetes
        private SqlDataAdapter dataAdpterVerbetes;

        // DataAdapter para a tabela Jogadores
        private SqlDataAdapter dataAdapterJogadores;

        // Código do Jogador recuperado do Banco de Dados
        private string codDOJogador = "";

        // Nome do Jogador recuperado do Banco de Dados
        private string nomeJogador  = "";

        // Level do Jogador selecionado no Banco de Dados
        private int levelJogador = 0;

        // Pontuação atual do Jogador recuperado do Banco de Dados
        private int pontuacaoJogador = 0;

        // Armazena a palavra que foi sorteada no Banco de Dados
        private string palavraSorteada = "";

        // Tabela contendo as letras da palavra sorteada
        private TableLayoutPanel tabelaDeLetras = new TableLayoutPanel();

        // Tabela contendo a palavra construída
        private TableLayoutPanel tabelaDeConstrucao = new TableLayoutPanel();

        // Tempo restante, por padrão, no Level 1, o tempo é 60 segundos
        private int tempoRestante = 60;

        // Lista com todas as palavras já construídas
        private List<string> listaPalavrasMontadas = new List<string>();

        // Lista com todas as palavras possíveis de serem construídas
        private List<string> listaPalavrasPossiveis = new List<string>();

        // Árvore para a pesquisa das palavras possíveis
        private ArvoreTrie myTrie = new ArvoreTrie();

        /**
         * MainWindow()
         * 
         * Inicializa dos componentes utilizados 
         * Popula a Árvore Trie com todas as palvras do Banco Banco de Dados
         * 
         */
        public MainWindow()
        {
            InitializeComponent();
            PopulaArvoreTrie();
        }

        /**
         * PegaDados()
         * 
         * Preenche o DataSet com os dados da tabela Verbetes.
         * 
         */
        private void PegaVerbetes()
        {
            using (SqlConnection conn = new SqlConnection(str_conexao))
            {
                string query = "SELECT cod_verbete, verbete FROM Verbetes;";
                conn.Open();
                using (dataSet = new DataSet())
                {
                    using (dataAdpterVerbetes = new SqlDataAdapter(query, conn))
                    {
                        dataAdpterVerbetes.Fill(dataSet, "Verbetes");
                    }
                }
            }
        }

        /**
         * AcaoComecarNovoJogo()
         * 
         * Inicia uma nova partida quando é selecionada essa ação no menu Arquivo 
         * ou através do atalho 'Ctrl+N'
         * Abre um formulário para cadastrar um novo jogador, 
         * caso nenhum nome seja informado, as informações da partida não serão salvas.
         * 
         */
        private void AcaoComecarNovoJogo(object sender, EventArgs e)
        {
            FormNovoJogo novoJogoForm = new FormNovoJogo();
            novoJogoForm.ShowDialog();

            this.codDOJogador = novoJogoForm.CodDoJogador;
            this.nomeJogador = novoJogoForm.NomeDoJogador;
            this.levelJogador = int.Parse(novoJogoForm.LevelJogador);
            this.pontuacaoJogador = int.Parse(novoJogoForm.PontuacaoJogador);

            this.lblNumPontos.Text = this.pontuacaoJogador.ToString();
            this.lblNumLevel.Text = this.levelJogador.ToString();

            btnDesistir.Enabled = true;

            ConfiguraRodada();
        }

        /**
         * SorteiaPalavra
         * 
         * Retorna um string contendo a palavra sorteada no Banco de Dados.
         * Todas as letras são convertidas em letras maiúsculas.
         */
        private string SorteiaPalavra()
        {
            Random rand = new Random();
            DataTable dt = dataSet.Tables["Verbetes"];
            DataRow[] result = dt.Select("cod_verbete=" + rand.Next(1, 312210).ToString());
            return result[0]["Verbete"].ToString();
        }

        /**
         * ConfiguraRodada()
         * 
         * Configura a TabelaDeLetras, TabelaDeConstrucao e calcula todas as cobinações
         * possíveis
         */
        private void ConfiguraRodada()
        {
            this.palavraSorteada = SorteiaPalavra();

            this.tabelaDeLetras.Controls.Clear();
            this.tabelaDeLetras.Size = new System.Drawing.Size(500, 55);
            this.tabelaDeLetras.Location = new System.Drawing.Point(12, 16);
            this.tabelaDeLetras.AutoSize = true;
            this.tabelaDeLetras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tabelaDeLetras.ColumnCount = palavraSorteada.Length;
            this.gbxPalavraSorteada.Controls.Add(tabelaDeLetras);

            this.tabelaDeConstrucao.Controls.Clear();
            this.tabelaDeConstrucao.Size = new System.Drawing.Size(500, 55);
            this.tabelaDeConstrucao.Location = new System.Drawing.Point(12, 16);
            this.tabelaDeConstrucao.AutoSize = true;
            this.tabelaDeConstrucao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tabelaDeConstrucao.ColumnCount = palavraSorteada.Length;
            this.gbxPalavraMontada.Controls.Add(tabelaDeConstrucao);

            foreach (char c in this.palavraSorteada)
                tabelaDeLetras.Controls.Add(GeraBotao(c));

            // Temporizador
            this.tempoRestante = 60;
            this.Temporizador.Enabled = true;

            // GroupBox
            gbxPalavraMontada.Enabled = true;
            gbxPalavraSorteada.Enabled = true;
            
            // TableLayoutPanel
            tlpInformacoes.Enabled = true;

            // Cor do Label Tempo
            lblNumTempo.ForeColor = Color.Red;

            HabilitaBotaoVerificar();
            listaPalavrasMontadas.Clear();
            listaPalavrasPossiveis.Clear();

            // GAMBIARRA TOTAL! TEMOS QUE RESOLVER O PROBLEMA DE LENTIDÃO E CONSUMO
            // EXAGERADO DE MEMÓRIA QUANDO A PALAVRA É MUITO GRANDE.
            // A POLÍTICA AQUI É CALCULAR SOMENTE A COMBINAÇÃO DE PALAVRAS POSSÍVEIS 
            // PARA OS PRIMEIROS 8 CARACTERES DA PALAVRA, CASO A PALAVRA TENHA MAIS DE 
            // 8 CARACTERES.
            string gambiarra;
            if (this.palavraSorteada.Length > 3)
                gambiarra = this.palavraSorteada.Substring(0, 3);
            else
                gambiarra = this.palavraSorteada;

            TodasAsCombinacoes tc = new TodasAsCombinacoes(gambiarra);

            foreach (string s in tc.todasCombinacoes)
                if (myTrie.Contem(s))
                    listaPalavrasPossiveis.Add(s);

            lblNumCombinacoesPossiveis.Text = listaPalavrasPossiveis.Count.ToString();
            lblNumCombinacoesEncontradas.Text = "0";
        }

        /**
         * GeraBotao()
         * 
         * Retorna um botão configurado, inclusive com seu evento de click.
         * 
         */
        private Button GeraBotao(char buttonText)
        {
            Button b = new Button();
            b.Name = buttonText.ToString();
            b.Text = buttonText.ToString();
            b.Size = new System.Drawing.Size(60, 43);
            b.Click += new System.EventHandler(this.LetraClicada);
            return b;
        }

        /**
         * LetraClicada()
         * 
         * Ação disparada quando o evento Click é executado sobre algum botão dentro 
         * da TabelaDeLetras ou da TabelaDeConstrução
         * 
         */
        private void LetraClicada(object sender, EventArgs e)
        {
            Button botao = sender as Button;

            if (tabelaDeLetras.Controls.Contains(botao))
            {
                tabelaDeConstrucao.Controls.Add(botao);
                tabelaDeLetras.Controls.Remove(botao);
            }
            else if (tabelaDeConstrucao.Controls.Contains(botao))
            {
                tabelaDeConstrucao.Controls.Remove(botao);
                tabelaDeLetras.Controls.Add(botao);
            }
            HabilitaBotaoVerificar();
        }

        /**
         * HabilitaBotaoVerificar()
         * 
         * Habilita o botão Verificar que serve para verificar se a palavra construída existe.
         * Para ser habilitado, tem que haver mais de dois botões dentro da TabelaDeConstrucao.
         * 
         */
        private void HabilitaBotaoVerificar()
        {
            if (tabelaDeConstrucao.Controls.Count > 1)
                btnVerificar.Enabled = true;
            if (tabelaDeConstrucao.Controls.Count < 2)
                btnVerificar.Enabled = false;
        }

        /**
         * PegaPalavraMontada()
         * 
         * Retorna uma string contendo a palavra montada.
         */
        private string PegaPalavraMontada()
        {
            string palavra = "";
            foreach (Button b in this.tabelaDeConstrucao.Controls)
                palavra += b.Text;

            return palavra;
        }

        /**
         * VerificaPalavraMontada()
         * 
         * Ação disparada quando o evento Click é executado sobre o botão Verificar.
         * 
         */
        private void VerificaPalavraMontada(object sender, EventArgs e)
        {
            string palavra = PegaPalavraMontada();

            int result = dataSet.Tables["Verbetes"].Select("verbete='" + palavra + "'").Length;
            
            Pontuacao(palavra, result);
            MudaLevel();

            this.lblNumPontos.Text = this.pontuacaoJogador.ToString();
        }

        /**
         * Pontuacao(int palavra, int ret_consulta)
         * @palavra = Palavra montada e que foi consultada no Banco de Dados
         * @ret_consulta = Representa a quantidade de ocorrências da palavra consultada
         * 
         * Política de pontuação:
         * Se não existir a palavra, subtrai um ponto da PontuacaoJogador;
         * Se existir, verifica se a palavra já não foi montada anteriormente, 
         * caso tenha sido, subtrai 10 pontos da PontuacaoDoJogador.
         * Se a palavra ainda não tiver sido montada, soma 10 pontos na PontuacaoDoJogador.
         * A cada palavra montada e existente no banco de dados, retorna o 
         * TempoRestante para 60 segundos.
         * 
         */
        private void Pontuacao(string palavra, int ret_consulta)
        {
            if (ret_consulta == 0)
                this.pontuacaoJogador -= 1;

            if (ret_consulta > 0)
            {
                if (listaPalavrasMontadas.Contains(palavra))
                    this.pontuacaoJogador -= 10;
                else
                {
                    this.pontuacaoJogador += 10;
                    tempoRestante = 60;
                    listaPalavrasMontadas.Add(palavra);
                    lblNumCombinacoesEncontradas.Text = listaPalavrasMontadas.Count.ToString();
                }
            }        
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tempoRestante--;
            lblNumTempo.Text = tempoRestante.ToString() + " Segundos";

            FinalizaJogo();
        }

        /**
         * FinalizaJogo()
         * 
         * Caso o tempo se esgote, finaliza o jogo.
         */
        private void FinalizaJogo()
        {
            if (this.tempoRestante == 0)
            {
                lblNumTempo.Text = "Tempo esgotado!";

                this.tempoRestante = 60;
                
                this.Temporizador.Enabled = false;
                this.btnVerificar.Enabled = false;
                this.listaPalavrasMontadas.Clear();

                gbxPalavraMontada.Enabled = false;
                gbxPalavraSorteada.Enabled = false;

                tlpInformacoes.Enabled = false;
                btnDesistir.Enabled = false;

                ArmazenaPontuacao();
            }
        }

        /*
         * ArmazenaPontuacao()
         * 
         * Quando o tempo é esgotado ou quando o jogador desiste no meio da partida.
         * 
         */
        private void ArmazenaPontuacao()
        {
            using (SqlConnection conn = new SqlConnection(str_conexao))
            {
                conn.Open();
                using (dataAdapterJogadores = new SqlDataAdapter("SELECT * FROM Jogadores", conn))
                {
                    using (new SqlCommandBuilder(dataAdapterJogadores))
                    {
                        dataAdapterJogadores.Fill(dataSet, "Jogadores");

                        dataSet.Tables["Jogadores"].Select("cod_jogador=" + this.codDOJogador.ToString())
                            [0]["pontuacao_jogador"] = this.pontuacaoJogador.ToString();

                        dataAdapterJogadores.Update(dataSet.Tables["Jogadores"]);
                    }
                }
            }
        }

        /**
         * PopulaArvoreTrie()
         * 
         * Popula a Árvore Trie com todas as palavras do Banco de dados.
         */
        private void PopulaArvoreTrie()
        {
            myTrie.filhas = new Dictionary<char, ArvoreTrie>();
            myTrie.final = false;

            using (SqlConnection Conexao = new SqlConnection(str_conexao))
            {
                try
                {
                    Conexao.Open();
                    SqlCommand comando = new SqlCommand("SELECT verbete FROM verbetes", Conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                        myTrie.Inserir(dr[0].ToString());
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Ooops, algo deu errado (PopulaArvoreTrie): {0}", erro.Message);
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        /**
         * AcaoSairClicada()
         * 
         * Ação que ocorre quando é selecionada a opção Sair do menu Arquivo 
         * ou quando o jogador executa o atalho 'Ctrl+Q'
         * 
         */
        private void AcaoSairClicada(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * BotaoDesistirClicado()
         * 
         * Quando o jogador desiste do jogo, armazena a pontuação atual.
         * 
         */
        private void BotaoDesistirClicado(object sender, EventArgs e)
        {
            ArmazenaPontuacao();
        }

        /**
         * 
         * 
         */
        private void MudaLevel()
        {
            if (this.lblNumCombinacoesEncontradas.Text == this.lblNumCombinacoesPossiveis.Text)
            {
                this.lblNumLevel.Text = levelJogador++.ToString();
                ConfiguraRodada();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            PegaVerbetes();
        }

        private void MainWindow_Closed(object sender, FormClosedEventArgs e)
        {
            this.ArmazenaPontuacao();
        }
    }
}
