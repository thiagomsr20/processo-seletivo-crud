﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erpfake.Cadastro.Service;
using erpfake.Data.Service;
using erpfake.Model;

namespace erpfake
{
    public partial class Form1 : Form
    {
        public SqlService SqlService = new SqlService();

        private CadastroService CadastroService;
        public Form1()
        {
            InitializeComponent();
            CadastroService = new CadastroService(this);

            // Inicializar opção na comboBox da Família
            string[] familias = ServicoSQLSemParametro.FamiliaComboBoxItens();
            FamiliaComboBox.Items.AddRange(familias);
        }

        private void SairButton_Click(object sender, EventArgs e)
        {
            bool[] CondicoesParaFecharJanela =
            {
                FamiliaComboBox.SelectedItem is null,
                SubFamiliaComboBox.SelectedItem is null,
                string.IsNullOrEmpty(CodigoTextBox.Text),
                string.IsNullOrEmpty(DescricaoTextBox.Text)
            };

            if (CondicoesParaFecharJanela.Any(x => x is false))
            {
                DialogResult AvisoParaFecharPrograma = MessageBox.Show("Existem campos preenchidos, deseja mesmo fechar o programa?", "Aviso!", MessageBoxButtons.YesNo);

                if (AvisoParaFecharPrograma == DialogResult.Yes)
                {
                    this.Close();
                }
                return;
            }
            this.Close();
        }

        private void CodigoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InserirButton_Click(object sender, EventArgs e)
        {
            if (SqlService.MaterialJaCadastrado(589))
            {
                MessageBox.Show("Item já cadastrado no banco");
                return;
            }
        }

        private void FamiliaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubFamiliaComboBox.Items.Clear();
            if (FamiliaComboBox.SelectedItem != null)
            {
                string familiaSelecionada = FamiliaComboBox.SelectedItem.ToString();

                string[] SubFamilias = SqlService.SubFamiliaComboBoxItens(familiaSelecionada);

                SubFamiliaComboBox.Items.AddRange(SubFamilias);
            }
        }

        private void PesquisarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
