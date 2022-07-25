namespace WindowsFormsApp1
{
    partial class pop_up_peso
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
            this.listBoxPesoV = new System.Windows.Forms.ListBox();
            this.listBoxDataPesoV = new System.Windows.Forms.ListBox();
            this.buttonEnviarPeso = new System.Windows.Forms.Button();
            this.maskedTextBoxData = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAddP = new System.Windows.Forms.TextBox();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExcuir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelarroba = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // listBoxPesoV
            // 
            this.listBoxPesoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPesoV.FormattingEnabled = true;
            this.listBoxPesoV.ItemHeight = 24;
            this.listBoxPesoV.Location = new System.Drawing.Point(296, 57);
            this.listBoxPesoV.Name = "listBoxPesoV";
            this.listBoxPesoV.Size = new System.Drawing.Size(74, 196);
            this.listBoxPesoV.TabIndex = 4;
            this.listBoxPesoV.TabStop = false;
            this.listBoxPesoV.SelectedIndexChanged += new System.EventHandler(this.listBoxPesoV_SelectedIndexChanged);
            // 
            // listBoxDataPesoV
            // 
            this.listBoxDataPesoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDataPesoV.FormattingEnabled = true;
            this.listBoxDataPesoV.ItemHeight = 24;
            this.listBoxDataPesoV.Location = new System.Drawing.Point(367, 57);
            this.listBoxDataPesoV.Name = "listBoxDataPesoV";
            this.listBoxDataPesoV.Size = new System.Drawing.Size(111, 196);
            this.listBoxDataPesoV.TabIndex = 5;
            this.listBoxDataPesoV.TabStop = false;
            this.listBoxDataPesoV.SelectedIndexChanged += new System.EventHandler(this.listBoxDataPesoV_SelectedIndexChanged);
            // 
            // buttonEnviarPeso
            // 
            this.buttonEnviarPeso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonEnviarPeso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnviarPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviarPeso.Location = new System.Drawing.Point(111, 198);
            this.buttonEnviarPeso.Name = "buttonEnviarPeso";
            this.buttonEnviarPeso.Size = new System.Drawing.Size(150, 45);
            this.buttonEnviarPeso.TabIndex = 3;
            this.buttonEnviarPeso.Text = "Adicionar";
            this.buttonEnviarPeso.UseVisualStyleBackColor = false;
            this.buttonEnviarPeso.Click += new System.EventHandler(this.buttonEnviarPeso_Click);
            // 
            // maskedTextBoxData
            // 
            this.maskedTextBoxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxData.Location = new System.Drawing.Point(137, 154);
            this.maskedTextBoxData.Mask = "00/00/0000";
            this.maskedTextBoxData.Name = "maskedTextBoxData";
            this.maskedTextBoxData.Size = new System.Drawing.Size(100, 29);
            this.maskedTextBoxData.TabIndex = 2;
            this.maskedTextBoxData.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxAddP
            // 
            this.textBoxAddP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddP.Location = new System.Drawing.Point(127, 104);
            this.textBoxAddP.Name = "textBoxAddP";
            this.textBoxAddP.Size = new System.Drawing.Size(150, 29);
            this.textBoxAddP.TabIndex = 1;
            this.textBoxAddP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddP_KeyPress);
            // 
            // comboBoxID
            // 
            this.comboBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(127, 54);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(121, 32);
            this.comboBoxID.TabIndex = 0;
            this.comboBoxID.DropDown += new System.EventHandler(this.comboBoxID_DropDown);
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            this.comboBoxID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Novo peso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(83, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(80, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "ID:";
            // 
            // buttonExcuir
            // 
            this.buttonExcuir.BackColor = System.Drawing.Color.Red;
            this.buttonExcuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcuir.Location = new System.Drawing.Point(336, 268);
            this.buttonExcuir.Name = "buttonExcuir";
            this.buttonExcuir.Size = new System.Drawing.Size(183, 47);
            this.buttonExcuir.TabIndex = 6;
            this.buttonExcuir.Text = "Excluir";
            this.buttonExcuir.UseVisualStyleBackColor = false;
            this.buttonExcuir.Click += new System.EventHandler(this.buttonExcuir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "usar \" virgula \" para casas decimais";
            // 
            // labelarroba
            // 
            this.labelarroba.AutoSize = true;
            this.labelarroba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelarroba.Location = new System.Drawing.Point(484, 54);
            this.labelarroba.Name = "labelarroba";
            this.labelarroba.Size = new System.Drawing.Size(107, 24);
            this.labelarroba.TabIndex = 22;
            this.labelarroba.Text = "labelArroba";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(73, 284);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 23;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox1.Visible = false;
            // 
            // pop_up_peso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(608, 362);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.labelarroba);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonExcuir);
            this.Controls.Add(this.listBoxPesoV);
            this.Controls.Add(this.listBoxDataPesoV);
            this.Controls.Add(this.buttonEnviarPeso);
            this.Controls.Add(this.maskedTextBoxData);
            this.Controls.Add(this.textBoxAddP);
            this.Controls.Add(this.comboBoxID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pop_up_peso";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Peso";
            this.Load += new System.EventHandler(this.pop_up_peso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPesoV;
        private System.Windows.Forms.ListBox listBoxDataPesoV;
        private System.Windows.Forms.Button buttonEnviarPeso;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxData;
        private System.Windows.Forms.TextBox textBoxAddP;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExcuir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelarroba;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}