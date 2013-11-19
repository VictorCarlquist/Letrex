using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Letrex
{
    public partial class FormNovoJogo : Form
    {
        private string StringConexao = "Data Source=.\\SQLEXPRESS; Database=LOPAII; Integrated Security=SSPI;";
        public string CodDoJogador = "0";
        public string NomeDoJogador = "";
        public string LevelJogador = "0";
        public string PontuacaoJogador = "0";

        public FormNovoJogo()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TentaRecuperarJogador();
            if (this.NomeDoJogador == "")
                CadastraNovoJogador();
        }

        private void TentaRecuperarJogador()
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                try
                {
                    Conexao.Open();
                    SqlCommand comando = new SqlCommand("SELECT cod_jogador, nome_jogador, level_jogador, pontuacao_jogador FROM " +
                        "jogadores WHERE nome_jogador=@nome_jogador", Conexao);
                    comando.Parameters.Add(new SqlParameter("@nome_jogador", this.txtbNome.Text));
                    SqlDataReader dt_reader = comando.ExecuteReader(CommandBehavior.SingleRow);
                    if (dt_reader.Read())
                    {
                        CodDoJogador = dt_reader[0].ToString();
                        NomeDoJogador = dt_reader[1].ToString();
                        LevelJogador = dt_reader[2].ToString();
                        PontuacaoJogador = dt_reader[3].ToString();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Ooops, algo deu errado (TentaRecuperarJogador): {0}", erro.Message);
                }
                finally
                {
                    Conexao.Close();
                    this.Close();
                }
            }
        }

        private void CadastraNovoJogador()
        {
            if (this.txtbNome.Text == "")
                return;

            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                try
                {
                    Conexao.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO jogadores(nome_jogador) " +
                        "VALUES (@nome_jogador)", Conexao);
                    comando.Parameters.Add(new SqlParameter("@nome_jogador", this.txtbNome.Text));
                    comando.ExecuteNonQuery();
                    this.NomeDoJogador = this.txtbNome.Text;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Ooops, algo deu errado (CadastraNovoJogador): {0}", erro.Message);
                }
                finally
                {
                    Conexao.Close();
                    this.Close();
                }
            }        
        }

        private void FormNovoJogo_Load(object sender, EventArgs e)
        {

        }
    }
}
