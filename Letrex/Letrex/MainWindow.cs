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
        private string StringConexao = "Data Source=.\\SQLEXPRESS; Catalog=LOPA2; Integrated Security=SSPI;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void acaoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comecarNovoJogo(object sender, EventArgs e)
        {
            if (!this.btnNovoJogo.IsDisposed)
                this.btnNovoJogo.Dispose();
            FormNovoJogo novoJogoForm = new FormNovoJogo();
            novoJogoForm.ShowDialog();

            MessageBox.Show(novoJogoForm.NomeDoJogador + "Level: " + novoJogoForm.LevelJogador.ToString());
        }
    }
}
