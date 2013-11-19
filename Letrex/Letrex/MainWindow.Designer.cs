namespace Letrex
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barraDeMenu = new System.Windows.Forms.MenuStrip();
            this.menuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoNovoJogo = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoPontuacao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxPalavraSorteada = new System.Windows.Forms.GroupBox();
            this.gbxPalavraMontada = new System.Windows.Forms.GroupBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.tlpInformacoes = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumLevel = new System.Windows.Forms.Label();
            this.lblNumPontos = new System.Windows.Forms.Label();
            this.lblNumTempo = new System.Windows.Forms.Label();
            this.lblNumCombinacoesEncontradas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPontos = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblNumCombinacoesPossiveis = new System.Windows.Forms.Label();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.btnDesistir = new System.Windows.Forms.Button();
            this.barraDeMenu.SuspendLayout();
            this.tlpInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraDeMenu
            // 
            this.barraDeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArquivo,
            this.menuVer,
            this.menuAjuda});
            this.barraDeMenu.Location = new System.Drawing.Point(0, 0);
            this.barraDeMenu.Name = "barraDeMenu";
            this.barraDeMenu.Size = new System.Drawing.Size(792, 24);
            this.barraDeMenu.TabIndex = 0;
            this.barraDeMenu.Text = "Barra de Menu";
            // 
            // menuArquivo
            // 
            this.menuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoNovoJogo,
            this.acaoSair});
            this.menuArquivo.Name = "menuArquivo";
            this.menuArquivo.Size = new System.Drawing.Size(56, 20);
            this.menuArquivo.Text = "&Arquivo";
            // 
            // acaoNovoJogo
            // 
            this.acaoNovoJogo.Name = "acaoNovoJogo";
            this.acaoNovoJogo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.acaoNovoJogo.Size = new System.Drawing.Size(187, 22);
            this.acaoNovoJogo.Text = "&Novo Jogo...";
            this.acaoNovoJogo.Click += new System.EventHandler(this.AcaoComecarNovoJogo);
            // 
            // acaoSair
            // 
            this.acaoSair.Name = "acaoSair";
            this.acaoSair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.acaoSair.Size = new System.Drawing.Size(187, 22);
            this.acaoSair.Text = "&Sair";
            this.acaoSair.Click += new System.EventHandler(this.AcaoSairClicada);
            // 
            // menuVer
            // 
            this.menuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoPontuacao});
            this.menuVer.Name = "menuVer";
            this.menuVer.Size = new System.Drawing.Size(35, 20);
            this.menuVer.Text = "&Ver";
            // 
            // acaoPontuacao
            // 
            this.acaoPontuacao.Name = "acaoPontuacao";
            this.acaoPontuacao.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.acaoPontuacao.Size = new System.Drawing.Size(186, 22);
            this.acaoPontuacao.Text = "&Pontuação...";
            // 
            // menuAjuda
            // 
            this.menuAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoSobre});
            this.menuAjuda.Name = "menuAjuda";
            this.menuAjuda.Size = new System.Drawing.Size(47, 20);
            this.menuAjuda.Text = "A&juda";
            // 
            // acaoSobre
            // 
            this.acaoSobre.Name = "acaoSobre";
            this.acaoSobre.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.acaoSobre.Size = new System.Drawing.Size(169, 22);
            this.acaoSobre.Text = "&Sobre...";
            // 
            // gbxPalavraSorteada
            // 
            this.gbxPalavraSorteada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPalavraSorteada.AutoSize = true;
            this.gbxPalavraSorteada.Enabled = false;
            this.gbxPalavraSorteada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPalavraSorteada.Location = new System.Drawing.Point(12, 27);
            this.gbxPalavraSorteada.MinimumSize = new System.Drawing.Size(565, 90);
            this.gbxPalavraSorteada.Name = "gbxPalavraSorteada";
            this.gbxPalavraSorteada.Size = new System.Drawing.Size(765, 90);
            this.gbxPalavraSorteada.TabIndex = 3;
            this.gbxPalavraSorteada.TabStop = false;
            this.gbxPalavraSorteada.Text = "Palavra sorteada";
            // 
            // gbxPalavraMontada
            // 
            this.gbxPalavraMontada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPalavraMontada.AutoSize = true;
            this.gbxPalavraMontada.Enabled = false;
            this.gbxPalavraMontada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPalavraMontada.Location = new System.Drawing.Point(12, 123);
            this.gbxPalavraMontada.MinimumSize = new System.Drawing.Size(565, 90);
            this.gbxPalavraMontada.Name = "gbxPalavraMontada";
            this.gbxPalavraMontada.Size = new System.Drawing.Size(765, 90);
            this.gbxPalavraMontada.TabIndex = 4;
            this.gbxPalavraMontada.TabStop = false;
            this.gbxPalavraMontada.Text = "Palavra montada";
            // 
            // btnVerificar
            // 
            this.btnVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificar.Enabled = false;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.Red;
            this.btnVerificar.Location = new System.Drawing.Point(682, 282);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(95, 43);
            this.btnVerificar.TabIndex = 5;
            this.btnVerificar.Text = "&Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.VerificaPalavraMontada);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Combinações encontradas:";
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(3, 56);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(61, 16);
            this.lblTempo.TabIndex = 8;
            this.lblTempo.Text = "Tempo:";
            // 
            // tlpInformacoes
            // 
            this.tlpInformacoes.ColumnCount = 2;
            this.tlpInformacoes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.61207F));
            this.tlpInformacoes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.38793F));
            this.tlpInformacoes.Controls.Add(this.lblNumLevel, 1, 4);
            this.tlpInformacoes.Controls.Add(this.lblNumPontos, 1, 3);
            this.tlpInformacoes.Controls.Add(this.lblNumTempo, 1, 2);
            this.tlpInformacoes.Controls.Add(this.lblNumCombinacoesEncontradas, 1, 1);
            this.tlpInformacoes.Controls.Add(this.label1, 0, 0);
            this.tlpInformacoes.Controls.Add(this.lblTempo, 0, 2);
            this.tlpInformacoes.Controls.Add(this.label2, 0, 1);
            this.tlpInformacoes.Controls.Add(this.lblPontos, 0, 3);
            this.tlpInformacoes.Controls.Add(this.lblLevel, 0, 4);
            this.tlpInformacoes.Controls.Add(this.lblNumCombinacoesPossiveis, 1, 0);
            this.tlpInformacoes.Enabled = false;
            this.tlpInformacoes.Location = new System.Drawing.Point(23, 219);
            this.tlpInformacoes.Name = "tlpInformacoes";
            this.tlpInformacoes.RowCount = 5;
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpInformacoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInformacoes.Size = new System.Drawing.Size(464, 135);
            this.tlpInformacoes.TabIndex = 9;
            // 
            // lblNumLevel
            // 
            this.lblNumLevel.AutoSize = true;
            this.lblNumLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLevel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNumLevel.Location = new System.Drawing.Point(209, 110);
            this.lblNumLevel.Name = "lblNumLevel";
            this.lblNumLevel.Size = new System.Drawing.Size(0, 16);
            this.lblNumLevel.TabIndex = 15;
            // 
            // lblNumPontos
            // 
            this.lblNumPontos.AutoSize = true;
            this.lblNumPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPontos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNumPontos.Location = new System.Drawing.Point(209, 82);
            this.lblNumPontos.Name = "lblNumPontos";
            this.lblNumPontos.Size = new System.Drawing.Size(0, 16);
            this.lblNumPontos.TabIndex = 14;
            // 
            // lblNumTempo
            // 
            this.lblNumTempo.AutoSize = true;
            this.lblNumTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTempo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNumTempo.Location = new System.Drawing.Point(209, 56);
            this.lblNumTempo.Name = "lblNumTempo";
            this.lblNumTempo.Size = new System.Drawing.Size(0, 16);
            this.lblNumTempo.TabIndex = 13;
            // 
            // lblNumCombinacoesEncontradas
            // 
            this.lblNumCombinacoesEncontradas.AutoSize = true;
            this.lblNumCombinacoesEncontradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCombinacoesEncontradas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNumCombinacoesEncontradas.Location = new System.Drawing.Point(209, 28);
            this.lblNumCombinacoesEncontradas.Name = "lblNumCombinacoesEncontradas";
            this.lblNumCombinacoesEncontradas.Size = new System.Drawing.Size(0, 16);
            this.lblNumCombinacoesEncontradas.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Combinações possíveis:";
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontos.Location = new System.Drawing.Point(3, 82);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(60, 16);
            this.lblPontos.TabIndex = 9;
            this.lblPontos.Text = "Pontos:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(3, 110);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(50, 16);
            this.lblLevel.TabIndex = 10;
            this.lblLevel.Text = "Level:";
            // 
            // lblNumCombinacoesPossiveis
            // 
            this.lblNumCombinacoesPossiveis.AutoSize = true;
            this.lblNumCombinacoesPossiveis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCombinacoesPossiveis.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNumCombinacoesPossiveis.Location = new System.Drawing.Point(209, 0);
            this.lblNumCombinacoesPossiveis.Name = "lblNumCombinacoesPossiveis";
            this.lblNumCombinacoesPossiveis.Size = new System.Drawing.Size(0, 16);
            this.lblNumCombinacoesPossiveis.TabIndex = 11;
            // 
            // Temporizador
            // 
            this.Temporizador.Interval = 1000;
            this.Temporizador.Tick += new System.EventHandler(this.Temporizador_Tick);
            // 
            // btnDesistir
            // 
            this.btnDesistir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesistir.Enabled = false;
            this.btnDesistir.Location = new System.Drawing.Point(682, 331);
            this.btnDesistir.Name = "btnDesistir";
            this.btnDesistir.Size = new System.Drawing.Size(95, 23);
            this.btnDesistir.TabIndex = 10;
            this.btnDesistir.Text = "&Desistir";
            this.btnDesistir.UseVisualStyleBackColor = true;
            this.btnDesistir.Click += new System.EventHandler(this.BotaoDesistirClicado);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 366);
            this.Controls.Add(this.btnDesistir);
            this.Controls.Add(this.tlpInformacoes);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.gbxPalavraMontada);
            this.Controls.Add(this.gbxPalavraSorteada);
            this.Controls.Add(this.barraDeMenu);
            this.MainMenuStrip = this.barraDeMenu;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainWindow";
            this.Text = "Letrex";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_Closed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.barraDeMenu.ResumeLayout(false);
            this.barraDeMenu.PerformLayout();
            this.tlpInformacoes.ResumeLayout(false);
            this.tlpInformacoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip barraDeMenu;
        private System.Windows.Forms.ToolStripMenuItem menuArquivo;
        private System.Windows.Forms.ToolStripMenuItem acaoNovoJogo;
        private System.Windows.Forms.ToolStripMenuItem acaoSair;
        private System.Windows.Forms.ToolStripMenuItem menuVer;
        private System.Windows.Forms.ToolStripMenuItem acaoPontuacao;
        private System.Windows.Forms.ToolStripMenuItem menuAjuda;
        private System.Windows.Forms.ToolStripMenuItem acaoSobre;
        private System.Windows.Forms.GroupBox gbxPalavraSorteada;
        private System.Windows.Forms.GroupBox gbxPalavraMontada;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.TableLayoutPanel tlpInformacoes;
        private System.Windows.Forms.Label lblPontos;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblNumLevel;
        private System.Windows.Forms.Label lblNumPontos;
        private System.Windows.Forms.Label lblNumTempo;
        private System.Windows.Forms.Label lblNumCombinacoesEncontradas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumCombinacoesPossiveis;
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Button btnDesistir;
    }
}

