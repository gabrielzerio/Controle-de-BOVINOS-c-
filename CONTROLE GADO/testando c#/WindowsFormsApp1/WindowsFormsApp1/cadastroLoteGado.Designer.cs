namespace WindowsFormsApp1
{
    partial class pop_up_cadastroLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pop_up_cadastroLote));
            this.textBoxNumLote = new System.Windows.Forms.TextBox();
            this.textBoxCadastroCidade = new System.Windows.Forms.TextBox();
            this.textBoxPCLote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.maskedTextBoxDataCompra = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxMostraLote = new System.Windows.Forms.ComboBox();
            this.buttonDeletaLote = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFornecedor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNumLote
            // 
            this.textBoxNumLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumLote.Location = new System.Drawing.Point(180, 109);
            this.textBoxNumLote.Name = "textBoxNumLote";
            this.textBoxNumLote.Size = new System.Drawing.Size(100, 26);
            this.textBoxNumLote.TabIndex = 2;
            this.textBoxNumLote.TextChanged += new System.EventHandler(this.textBoxNumLote_TextChanged);
            // 
            // textBoxCadastroCidade
            // 
            this.textBoxCadastroCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCadastroCidade.Location = new System.Drawing.Point(180, 141);
            this.textBoxCadastroCidade.Name = "textBoxCadastroCidade";
            this.textBoxCadastroCidade.Size = new System.Drawing.Size(100, 26);
            this.textBoxCadastroCidade.TabIndex = 3;
            // 
            // textBoxPCLote
            // 
            this.textBoxPCLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPCLote.Location = new System.Drawing.Point(180, 77);
            this.textBoxPCLote.Name = "textBoxPCLote";
            this.textBoxPCLote.Size = new System.Drawing.Size(100, 26);
            this.textBoxPCLote.TabIndex = 1;
            this.textBoxPCLote.TextChanged += new System.EventHandler(this.textBoxPCLote_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Preço de custo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Numero do Lote:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cidade:";
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviar.Image = ((System.Drawing.Image)(resources.GetObject("buttonEnviar.Image")));
            this.buttonEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEnviar.Location = new System.Drawing.Point(69, 215);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(186, 47);
            this.buttonEnviar.TabIndex = 1;
            this.buttonEnviar.Text = "    Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = false;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // maskedTextBoxDataCompra
            // 
            this.maskedTextBoxDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDataCompra.Location = new System.Drawing.Point(180, 42);
            this.maskedTextBoxDataCompra.Mask = "00/00/0000";
            this.maskedTextBoxDataCompra.Name = "maskedTextBoxDataCompra";
            this.maskedTextBoxDataCompra.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBoxDataCompra.TabIndex = 0;
            this.maskedTextBoxDataCompra.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDataCompra.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // comboBoxMostraLote
            // 
            this.comboBoxMostraLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMostraLote.FormattingEnabled = true;
            this.comboBoxMostraLote.Location = new System.Drawing.Point(426, 97);
            this.comboBoxMostraLote.Name = "comboBoxMostraLote";
            this.comboBoxMostraLote.Size = new System.Drawing.Size(121, 28);
            this.comboBoxMostraLote.TabIndex = 4;
            this.comboBoxMostraLote.DropDown += new System.EventHandler(this.comboBoxMostraLote_DropDown);
            this.comboBoxMostraLote.TextChanged += new System.EventHandler(this.comboBoxMostraLote_TextChanged);
            this.comboBoxMostraLote.Leave += new System.EventHandler(this.comboBoxMostraLote_Leave);
            // 
            // buttonDeletaLote
            // 
            this.buttonDeletaLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonDeletaLote.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeletaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeletaLote.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletaLote.Image")));
            this.buttonDeletaLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeletaLote.Location = new System.Drawing.Point(429, 134);
            this.buttonDeletaLote.Name = "buttonDeletaLote";
            this.buttonDeletaLote.Size = new System.Drawing.Size(104, 40);
            this.buttonDeletaLote.TabIndex = 5;
            this.buttonDeletaLote.Text = "     Deletar";
            this.buttonDeletaLote.UseVisualStyleBackColor = false;
            this.buttonDeletaLote.Click += new System.EventHandler(this.buttonDeletaLote_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(360, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "nLote:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Excluir Lote";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(25, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 36);
            this.panel1.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cadastrar Lote";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(387, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 43);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.buttonEnviar);
            this.panel3.Controls.Add(this.textBoxFornecedor);
            this.panel3.Location = new System.Drawing.Point(25, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 279);
            this.panel3.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Vendedor";
            // 
            // textBoxFornecedor
            // 
            this.textBoxFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFornecedor.Location = new System.Drawing.Point(92, 178);
            this.textBoxFornecedor.Name = "textBoxFornecedor";
            this.textBoxFornecedor.Size = new System.Drawing.Size(220, 26);
            this.textBoxFornecedor.TabIndex = 0;
            // 
            // pop_up_cadastroLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 291);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDeletaLote);
            this.Controls.Add(this.comboBoxMostraLote);
            this.Controls.Add(this.maskedTextBoxDataCompra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPCLote);
            this.Controls.Add(this.textBoxCadastroCidade);
            this.Controls.Add(this.textBoxNumLote);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "pop_up_cadastroLote";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Lote";
            this.Load += new System.EventHandler(this.pop_up_cadastroLote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNumLote;
        private System.Windows.Forms.TextBox textBoxCadastroCidade;
        private System.Windows.Forms.TextBox textBoxPCLote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataCompra;
        private System.Windows.Forms.ComboBox comboBoxMostraLote;
        private System.Windows.Forms.Button buttonDeletaLote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFornecedor;
    }
}