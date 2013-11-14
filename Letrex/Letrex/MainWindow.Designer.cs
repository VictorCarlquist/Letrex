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
            this.barraDeMenu = new System.Windows.Forms.MenuStrip();
            this.menuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAjuda = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoNovoJogo = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.acaoPontuacao = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNovoJogo = new System.Windows.Forms.Button();
            this.barraDeMenu.SuspendLayout();
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
            this.barraDeMenu.Size = new System.Drawing.Size(584, 24);
            this.barraDeMenu.TabIndex = 0;
            this.barraDeMenu.Text = "Barra de Menu";
            // 
            // menuArquivo
            // 
            this.menuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoNovoJogo,
            this.acaoSair});
            this.menuArquivo.Name = "menuArquivo";
            this.menuArquivo.Size = new System.Drawing.Size(61, 20);
            this.menuArquivo.Text = "&Arquivo";
            // 
            // menuVer
            // 
            this.menuVer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoPontuacao});
            this.menuVer.Name = "menuVer";
            this.menuVer.Size = new System.Drawing.Size(36, 20);
            this.menuVer.Text = "&Ver";
            // 
            // menuAjuda
            // 
            this.menuAjuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acaoSobre});
            this.menuAjuda.Name = "menuAjuda";
            this.menuAjuda.Size = new System.Drawing.Size(50, 20);
            this.menuAjuda.Text = "A&juda";
            // 
            // acaoSobre
            // 
            this.acaoSobre.Name = "acaoSobre";
            this.acaoSobre.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.acaoSobre.Size = new System.Drawing.Size(159, 22);
            this.acaoSobre.Text = "&Sobre...";
            // 
            // acaoNovoJogo
            // 
            this.acaoNovoJogo.Name = "acaoNovoJogo";
            this.acaoNovoJogo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.acaoNovoJogo.Size = new System.Drawing.Size(183, 22);
            this.acaoNovoJogo.Text = "&Novo Jogo...";
            this.acaoNovoJogo.Click += new System.EventHandler(this.comecarNovoJogo);
            // 
            // acaoSair
            // 
            this.acaoSair.Name = "acaoSair";
            this.acaoSair.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.acaoSair.Size = new System.Drawing.Size(183, 22);
            this.acaoSair.Text = "&Sair";
            this.acaoSair.Click += new System.EventHandler(this.acaoSair_Click);
            // 
            // acaoPontuacao
            // 
            this.acaoPontuacao.Name = "acaoPontuacao";
            this.acaoPontuacao.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.acaoPontuacao.Size = new System.Drawing.Size(180, 22);
            this.acaoPontuacao.Text = "&Pontuação...";
            // 
            // btnNovoJogo
            // 
            this.btnNovoJogo.Location = new System.Drawing.Point(209, 156);
            this.btnNovoJogo.Name = "btnNovoJogo";
            this.btnNovoJogo.Size = new System.Drawing.Size(150, 46);
            this.btnNovoJogo.TabIndex = 1;
            this.btnNovoJogo.Text = "Novo Jogo";
            this.btnNovoJogo.UseVisualStyleBackColor = true;
            this.btnNovoJogo.Click += new System.EventHandler(this.comecarNovoJogo);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.btnNovoJogo);
            this.Controls.Add(this.barraDeMenu);
            this.MainMenuStrip = this.barraDeMenu;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainWindow";
            this.Text = "Letrex";
            this.barraDeMenu.ResumeLayout(false);
            this.barraDeMenu.PerformLayout();
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
        private System.Windows.Forms.Button btnNovoJogo;
    }
}

