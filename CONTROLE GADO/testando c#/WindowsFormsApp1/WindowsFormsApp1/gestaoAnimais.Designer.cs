namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.criarAtualizarExcluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçõesLoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarAtualizarExcluirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1368, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // criarAtualizarExcluirToolStripMenuItem
            // 
            this.criarAtualizarExcluirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gadoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.informaçõesLoteToolStripMenuItem});
            this.criarAtualizarExcluirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criarAtualizarExcluirToolStripMenuItem.Name = "criarAtualizarExcluirToolStripMenuItem";
            this.criarAtualizarExcluirToolStripMenuItem.Size = new System.Drawing.Size(83, 36);
            this.criarAtualizarExcluirToolStripMenuItem.Text = "Gado";
            this.criarAtualizarExcluirToolStripMenuItem.Click += new System.EventHandler(this.criarAtualizarExcluirToolStripMenuItem_Click);
            // 
            // gadoToolStripMenuItem
            // 
            this.gadoToolStripMenuItem.Name = "gadoToolStripMenuItem";
            this.gadoToolStripMenuItem.Size = new System.Drawing.Size(453, 36);
            this.gadoToolStripMenuItem.Text = "Cadastrar E Visualizar Informações";
            this.gadoToolStripMenuItem.Click += new System.EventHandler(this.gadoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(453, 36);
            this.toolStripMenuItem1.Text = "Cadastrar Lote";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // informaçõesLoteToolStripMenuItem
            // 
            this.informaçõesLoteToolStripMenuItem.Name = "informaçõesLoteToolStripMenuItem";
            this.informaçõesLoteToolStripMenuItem.Size = new System.Drawing.Size(453, 36);
            this.informaçõesLoteToolStripMenuItem.Text = "Informações Lote";
            this.informaçõesLoteToolStripMenuItem.Click += new System.EventHandler(this.informaçõesLoteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 761);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CADASTRO ANIMAIS ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem criarAtualizarExcluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informaçõesLoteToolStripMenuItem;
    }
}

