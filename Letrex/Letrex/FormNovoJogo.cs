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
        public string NomeDoJogador = "";
        public int LevelJogador = 0;

        private string StringConexao = "Data Source=.\\SQLEXPRESS; Database=LOPAII; Integrated Security=SSPI;";

        public FormNovoJogo()
        {
            InitializeComponent();
        }

        private void FormNovoJogo_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conexao = new SqlConnection(StringConexao))
            {
                Conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT nome_usuario, level_usuario FROM " +
                    "usuarios WHERE nome_usuario=@nome_usuario", Conexao);
                comando.Parameters.Add(new SqlParameter("@nome_usuario", this.txtbNome.Text));
                SqlDataReader dt_reader = comando.ExecuteReader(CommandBehavior.SingleRow);

                try
                {
                    dt_reader.Read();
                    NomeDoJogador = dt_reader[0].ToString();
                    LevelJogador = int.Parse (dt_reader[1].ToString());
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Ooops, algo deu errado: {0}", erro.Message);
                }
                finally
                {
                    Conexao.Close();
                    this.Close();
                }
            }
        }
    }
}
