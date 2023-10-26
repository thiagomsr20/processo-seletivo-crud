
using erpfake.Data.Service;
using System.Windows.Forms;

namespace erpfake
{
    partial class Form1
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

        public SqlService ServicoSQLSemParametro = new SqlService();

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DescricaoMensagemDeErro = new System.Windows.Forms.Label();
            this.CodigoMensagemDeErro = new System.Windows.Forms.Label();
            this.PesquisarButton = new System.Windows.Forms.Button();
            this.SairButton = new System.Windows.Forms.Button();
            this.Excluir = new System.Windows.Forms.Button();
            this.AtualizaButton = new System.Windows.Forms.Button();
            this.InserirButton = new System.Windows.Forms.Button();
            this.UnidadeDeMedidaComboBox = new System.Windows.Forms.ComboBox();
            this.SubFamiliaComboBox = new System.Windows.Forms.ComboBox();
            this.FamiliaComboBox = new System.Windows.Forms.ComboBox();
            this.DescricaoTextBox = new System.Windows.Forms.TextBox();
            this.CodigoTextBox = new System.Windows.Forms.TextBox();
            this.UnidadeDeMedidaLabel = new System.Windows.Forms.Label();
            this.SubFamiliaLabel = new System.Windows.Forms.Label();
            this.FamiliaLabel = new System.Windows.Forms.Label();
            this.DescricaoLabel = new System.Windows.Forms.Label();
            this.CodigoLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DescricaoMensagemDeErro);
            this.groupBox1.Controls.Add(this.CodigoMensagemDeErro);
            this.groupBox1.Controls.Add(this.PesquisarButton);
            this.groupBox1.Controls.Add(this.SairButton);
            this.groupBox1.Controls.Add(this.Excluir);
            this.groupBox1.Controls.Add(this.AtualizaButton);
            this.groupBox1.Controls.Add(this.InserirButton);
            this.groupBox1.Controls.Add(this.UnidadeDeMedidaComboBox);
            this.groupBox1.Controls.Add(this.SubFamiliaComboBox);
            this.groupBox1.Controls.Add(this.FamiliaComboBox);
            this.groupBox1.Controls.Add(this.DescricaoTextBox);
            this.groupBox1.Controls.Add(this.CodigoTextBox);
            this.groupBox1.Controls.Add(this.UnidadeDeMedidaLabel);
            this.groupBox1.Controls.Add(this.SubFamiliaLabel);
            this.groupBox1.Controls.Add(this.FamiliaLabel);
            this.groupBox1.Controls.Add(this.DescricaoLabel);
            this.groupBox1.Controls.Add(this.CodigoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados cadastrais";
            // 
            // DescricaoMensagemDeErro
            // 
            this.DescricaoMensagemDeErro.AutoSize = true;
            this.DescricaoMensagemDeErro.Location = new System.Drawing.Point(117, 82);
            this.DescricaoMensagemDeErro.Name = "DescricaoMensagemDeErro";
            this.DescricaoMensagemDeErro.Size = new System.Drawing.Size(0, 13);
            this.DescricaoMensagemDeErro.TabIndex = 16;
            // 
            // CodigoMensagemDeErro
            // 
            this.CodigoMensagemDeErro.AutoSize = true;
            this.CodigoMensagemDeErro.Location = new System.Drawing.Point(117, 41);
            this.CodigoMensagemDeErro.Name = "CodigoMensagemDeErro";
            this.CodigoMensagemDeErro.Size = new System.Drawing.Size(0, 13);
            this.CodigoMensagemDeErro.TabIndex = 15;
            // 
            // PesquisarButton
            // 
            this.PesquisarButton.Location = new System.Drawing.Point(384, 330);
            this.PesquisarButton.Name = "PesquisarButton";
            this.PesquisarButton.Size = new System.Drawing.Size(120, 40);
            this.PesquisarButton.TabIndex = 14;
            this.PesquisarButton.Text = "Pesquisar";
            this.PesquisarButton.UseVisualStyleBackColor = true;
            this.PesquisarButton.Click += new System.EventHandler(this.PesquisarButton_Click);
            // 
            // SairButton
            // 
            this.SairButton.Location = new System.Drawing.Point(510, 330);
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(120, 40);
            this.SairButton.TabIndex = 13;
            this.SairButton.Text = "Sair";
            this.SairButton.UseVisualStyleBackColor = true;
            this.SairButton.Click += new System.EventHandler(this.SairButton_Click);
            // 
            // Excluir
            // 
            this.Excluir.Location = new System.Drawing.Point(258, 330);
            this.Excluir.Name = "Excluir";
            this.Excluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Excluir.Size = new System.Drawing.Size(120, 40);
            this.Excluir.TabIndex = 12;
            this.Excluir.Text = "Excluir";
            this.Excluir.UseVisualStyleBackColor = true;
            // 
            // AtualizaButton
            // 
            this.AtualizaButton.Location = new System.Drawing.Point(132, 330);
            this.AtualizaButton.Name = "AtualizaButton";
            this.AtualizaButton.Size = new System.Drawing.Size(120, 40);
            this.AtualizaButton.TabIndex = 11;
            this.AtualizaButton.Text = "Atualizar";
            this.AtualizaButton.UseVisualStyleBackColor = true;
            // 
            // InserirButton
            // 
            this.InserirButton.Location = new System.Drawing.Point(6, 330);
            this.InserirButton.Name = "InserirButton";
            this.InserirButton.Size = new System.Drawing.Size(120, 40);
            this.InserirButton.TabIndex = 10;
            this.InserirButton.Text = "Inserir";
            this.InserirButton.UseVisualStyleBackColor = true;
            this.InserirButton.Click += new System.EventHandler(this.InserirButton_Click);
            // 
            // UnidadeDeMedidaComboBox
            // 
            this.UnidadeDeMedidaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnidadeDeMedidaComboBox.FormattingEnabled = true;
            this.UnidadeDeMedidaComboBox.Items.AddRange(new object[] {
            "Milimetro",
            "Polegada"});
            this.UnidadeDeMedidaComboBox.Location = new System.Drawing.Point(120, 216);
            this.UnidadeDeMedidaComboBox.Name = "UnidadeDeMedidaComboBox";
            this.UnidadeDeMedidaComboBox.Size = new System.Drawing.Size(176, 21);
            this.UnidadeDeMedidaComboBox.TabIndex = 9;
            // 
            // SubFamiliaComboBox
            // 
            this.SubFamiliaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubFamiliaComboBox.FormattingEnabled = true;
            this.SubFamiliaComboBox.Location = new System.Drawing.Point(120, 175);
            this.SubFamiliaComboBox.Name = "SubFamiliaComboBox";
            this.SubFamiliaComboBox.Size = new System.Drawing.Size(176, 21);
            this.SubFamiliaComboBox.TabIndex = 8;
            // 
            // FamiliaComboBox
            // 
            this.FamiliaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamiliaComboBox.FormattingEnabled = true;
            this.FamiliaComboBox.Location = new System.Drawing.Point(120, 135);
            this.FamiliaComboBox.Name = "FamiliaComboBox";
            this.FamiliaComboBox.Size = new System.Drawing.Size(176, 21);
            this.FamiliaComboBox.TabIndex = 7;
            this.FamiliaComboBox.SelectedIndexChanged += new System.EventHandler(this.FamiliaComboBox_SelectedIndexChanged);
            // 
            // DescricaoTextBox
            // 
            this.DescricaoTextBox.Location = new System.Drawing.Point(120, 98);
            this.DescricaoTextBox.MaxLength = 100;
            this.DescricaoTextBox.Name = "DescricaoTextBox";
            this.DescricaoTextBox.Size = new System.Drawing.Size(510, 20);
            this.DescricaoTextBox.TabIndex = 6;
            // 
            // CodigoTextBox
            // 
            this.CodigoTextBox.Location = new System.Drawing.Point(120, 57);
            this.CodigoTextBox.Name = "CodigoTextBox";
            this.CodigoTextBox.Size = new System.Drawing.Size(176, 20);
            this.CodigoTextBox.TabIndex = 5;
            this.CodigoTextBox.TextChanged += new System.EventHandler(this.CodigoTextBox_TextChanged);
            // 
            // UnidadeDeMedidaLabel
            // 
            this.UnidadeDeMedidaLabel.AutoSize = true;
            this.UnidadeDeMedidaLabel.Location = new System.Drawing.Point(11, 219);
            this.UnidadeDeMedidaLabel.Name = "UnidadeDeMedidaLabel";
            this.UnidadeDeMedidaLabel.Size = new System.Drawing.Size(103, 13);
            this.UnidadeDeMedidaLabel.TabIndex = 4;
            this.UnidadeDeMedidaLabel.Text = "Unidade de Medida:";
            // 
            // SubFamiliaLabel
            // 
            this.SubFamiliaLabel.AutoSize = true;
            this.SubFamiliaLabel.Location = new System.Drawing.Point(51, 178);
            this.SubFamiliaLabel.Name = "SubFamiliaLabel";
            this.SubFamiliaLabel.Size = new System.Drawing.Size(63, 13);
            this.SubFamiliaLabel.TabIndex = 3;
            this.SubFamiliaLabel.Text = "Sub família:";
            // 
            // FamiliaLabel
            // 
            this.FamiliaLabel.AutoSize = true;
            this.FamiliaLabel.Location = new System.Drawing.Point(70, 138);
            this.FamiliaLabel.Name = "FamiliaLabel";
            this.FamiliaLabel.Size = new System.Drawing.Size(44, 13);
            this.FamiliaLabel.TabIndex = 2;
            this.FamiliaLabel.Text = "Família:";
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.Location = new System.Drawing.Point(56, 101);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(58, 13);
            this.DescricaoLabel.TabIndex = 1;
            this.DescricaoLabel.Text = "Descrição:";
            // 
            // CodigoLabel
            // 
            this.CodigoLabel.AutoSize = true;
            this.CodigoLabel.Location = new System.Drawing.Point(71, 60);
            this.CodigoLabel.Name = "CodigoLabel";
            this.CodigoLabel.Size = new System.Drawing.Size(43, 13);
            this.CodigoLabel.TabIndex = 0;
            this.CodigoLabel.Text = "Código:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 400);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Material";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public GroupBox groupBox1;
        public Label UnidadeDeMedidaLabel;
        public Label SubFamiliaLabel;
        public Label FamiliaLabel;
        public Label DescricaoLabel;
        public Label CodigoLabel;
        public TextBox DescricaoTextBox;
        public TextBox CodigoTextBox;
        public ComboBox UnidadeDeMedidaComboBox;
        public ComboBox SubFamiliaComboBox;
        public ComboBox FamiliaComboBox;
        public Button PesquisarButton;
        public Button SairButton;
        public Button Excluir;
        public Button AtualizaButton;
        public Button InserirButton;
        public Label CodigoMensagemDeErro;
        public Label DescricaoMensagemDeErro;
    }
}

