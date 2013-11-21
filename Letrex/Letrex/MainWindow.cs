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
        private string codDoJogador = "";

        // Nome do Jogador recuperado do Banco de Dados
        private string nomeJogador  = "";

        // Level do Jogador selecionado no Banco de Dados
        private int levelJogador = 0;

        // Pontuação atual do Jogador recuperado do Banco de Dados
        private int pontuacaoJogador = 0;

        // Tabela contendo as letras da palavra sorteada
        private TableLayoutPanel tabelaBotaoLetras = new TableLayoutPanel();

        // Tabela contendo a palavra construída
        private TableLayoutPanel tabelaBotaoPalavraMontada = new TableLayoutPanel();

        // Tempo restante, por padrão, no Level 1, o tempo é 60 segundos,
        private int tempoRestante = 60;

        // Lista de todas as palavras já construídas durante o level
        private List<string> palavrasMontadas = new List<string>();

        // Lista de todas as palavras válidas durante o level
        private List<string> palavrasValidas = new List<string>();

        // Árvore para a pesquisa das palavras possíveis
        private ArvoreTrie arvoreTrie = new ArvoreTrie();

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

            this.tabelaBotaoLetras.Size = new System.Drawing.Size(500, 55);
            this.tabelaBotaoLetras.Location = new System.Drawing.Point(12, 16);
            this.tabelaBotaoLetras.AutoSize = true;
            this.tabelaBotaoLetras.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.tabelaBotaoPalavraMontada.Size = new System.Drawing.Size(500, 55);
            this.tabelaBotaoPalavraMontada.Location = new System.Drawing.Point(12, 16);
            this.tabelaBotaoPalavraMontada.AutoSize = true;
            this.tabelaBotaoPalavraMontada.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.gbxPalavraSorteada.Controls.Add(this.tabelaBotaoLetras);
            this.gbxPalavraMontada.Controls.Add(this.tabelaBotaoPalavraMontada);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            PegaVerbetes();
        }

        private void MainWindow_Closed(object sender, FormClosedEventArgs e)
        {
            ArmazenaPontuacao();
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
                conn.Open();
                using (dataSet = new DataSet())
                using (dataAdpterVerbetes = new SqlDataAdapter(
                    "SELECT cod_verbete, verbete FROM Verbetes;", conn))
                dataAdpterVerbetes.Fill(dataSet, "Verbetes");
            }
        }

        /**
         * AcaoComecarNovoJogo()
         * 
         * Inicia uma nova partida. Quando essa ação é selecionada no menu Arquivo 
         * ou através do atalho 'Ctrl+N'
         * Abre um formulário para cadastrar um novo jogador, 
         * caso nenhum nome seja informado, as informações da partida não serão salvas.
         * 
         */
        private void AcaoComecarNovoJogo(object sender, EventArgs e)
        {
            FormNovoJogo novoJogoForm = new FormNovoJogo();
            novoJogoForm.ShowDialog();

            this.codDoJogador = novoJogoForm.CodDoJogador;
            this.nomeJogador = novoJogoForm.NomeDoJogador;
            this.levelJogador = int.Parse(novoJogoForm.LevelJogador);
            this.pontuacaoJogador = int.Parse(novoJogoForm.PontuacaoJogador);
            this.lblNumPontos.Text = this.pontuacaoJogador.ToString();

            ConfiguraLevel();
        }

        /**
         * ConfiguraLevel()
         * 
         * Configura a TabelaDeLetras, TabelaDeConstrucao e calcula todas as cobinações
         * possíveis
         */
        private void ConfiguraLevel()
        {
            this.tabelaBotaoLetras.Controls.Clear();
            this.tabelaBotaoPalavraMontada.Controls.Clear();

            string palavraSorteada = SorteiaPalavra();

            // Cria os botões
            foreach (char c in palavraSorteada)
                tabelaBotaoLetras.Controls.Add(GeraBotao(c));

            // Gera todas as combinações, checa as palavras que existem e as armazena 
            // na lista de palavras válidas.
            TodasAsCombinacoes tc = new TodasAsCombinacoes(palavraSorteada);
            foreach (string s in tc.todasCombinacoes)
                if (arvoreTrie.Contem(s))
                    this.palavrasValidas.Add(s);

            setupControls(palavraSorteada.Length, this.palavrasValidas.Count);
        }

        private void setupControls(int tamPalavraSorteada, int qtdPalavrasPossiveis)
        {
            // 
            this.tabelaBotaoLetras.ColumnCount = tamPalavraSorteada;
            this.tabelaBotaoPalavraMontada.ColumnCount = tamPalavraSorteada;

            // Temporizador
            this.Temporizador.Enabled = true;
            this.tempoRestante = 60;
            this.lblNumTempo.ForeColor = Color.Red;
            this.lblNumTempo.Text = this.tempoRestante.ToString();

            // Habilitando controles
            this.gbxPalavraMontada.Enabled = true;
            this.gbxPalavraSorteada.Enabled = true;
            this.tlpInformacoes.Enabled = true;
            this.btnDesistir.Enabled = true;

            // Avança um level
            this.lblNumLevel.Text = this.levelJogador++.ToString();

            this.palavrasMontadas.Clear();
            this.lblNumCombinacoesEncontradas.Text = this.palavrasMontadas.Count.ToString();
            this.lblNumCombinacoesPossiveis.Text = qtdPalavrasPossiveis.ToString();

            HabilitaBotaoVerificar();
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
            DataRow[] result = dt.Select("cod_verbete=" + rand.Next(1, 135888).ToString());
            return result[0]["Verbete"].ToString();
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

            if (tabelaBotaoLetras.Controls.Contains(botao))
            {
                tabelaBotaoPalavraMontada.Controls.Add(botao);
                tabelaBotaoLetras.Controls.Remove(botao);
            }
            else if (tabelaBotaoPalavraMontada.Controls.Contains(botao))
            {
                tabelaBotaoPalavraMontada.Controls.Remove(botao);
                tabelaBotaoLetras.Controls.Add(botao);
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
            if (tabelaBotaoPalavraMontada.Controls.Count > 1)
                btnVerificar.Enabled = true;
            if (tabelaBotaoPalavraMontada.Controls.Count < 2)
                btnVerificar.Enabled = false;
        }

        /**
         * VerificaPalavraMontada()
         * 
         * Ação disparada quando o evento Click é executado sobre o botão Verificar.
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
        private void VerificaPalavraMontada(object sender, EventArgs e)
        {
            string palavra = PegaPalavraMontada();

            // Se a palavra não existir, subtrai um ponto do jogador.
            if (!this.palavrasValidas.Contains(palavra))
                this.pontuacaoJogador -= 1;

            // Se a palavra já tiver sido montada, 
            // subtrai 10 pontos do jogador.
            if (!palavrasMontadas.Contains(palavra))
                this.pontuacaoJogador -= 10;
              
            // Se a palavra montada for válida, 
            // soma 10 pontos à pontuação do jogador.
            if (this.palavrasValidas.Contains(palavra))
            {
                this.pontuacaoJogador += 10;
                this.tempoRestante = 60;
                palavrasMontadas.Add(palavra);
                this.lblNumCombinacoesEncontradas.Text = this.palavrasMontadas.Count.ToString();
            }

            // Atualiza o label que informa a pontuação.
            this.lblNumPontos.Text = this.pontuacaoJogador.ToString();

            // Verifica se deve mudar de Level.
            if (this.lblNumCombinacoesEncontradas.Text == this.lblNumCombinacoesPossiveis.Text)
                ConfiguraLevel();
        }


        /**
         * PegaPalavraMontada()
         * 
         * Retorna uma string contendo a palavra montada.
         */
        private string PegaPalavraMontada()
        {
            string palavra = "";
            foreach (Button b in this.tabelaBotaoPalavraMontada.Controls)
                palavra += b.Text;

            return palavra;
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tempoRestante--;
            lblNumTempo.Text = tempoRestante.ToString() + " Segundos";

            // Tempo esgotado, finaliza jogo.
            if (this.tempoRestante == 0)
                FinalizaJogo();
        }

        /**
         * FinalizaJogo()
         * 
         */
        private void FinalizaJogo()
        {
            lblNumTempo.Text = "Tempo esgotado!";

            this.tempoRestante = 60;
                
            this.Temporizador.Enabled = false;
            this.btnVerificar.Enabled = false;
            this.palavrasMontadas.Clear();

            gbxPalavraMontada.Enabled = false;
            gbxPalavraSorteada.Enabled = false;

            tlpInformacoes.Enabled = false;
            btnDesistir.Enabled = false;

            ArmazenaPontuacao();
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

                        dataSet.Tables["Jogadores"].Select("cod_jogador=" + this.codDoJogador.ToString())
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
            arvoreTrie.filhas = new Dictionary<char, ArvoreTrie>();
            arvoreTrie.final = false;

            using (SqlConnection Conexao = new SqlConnection(str_conexao))
            {
                try
                {
                    Conexao.Open();
                    SqlCommand comando = new SqlCommand("SELECT verbete FROM verbetes", Conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                        arvoreTrie.Inserir(dr["verbete"].ToString());
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
            FinalizaJogo();
        }

        /**
         * 
         * 
         */
        private void MudaLevel()
        {

        }
    }
}
