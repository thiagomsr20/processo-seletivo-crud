﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erpfake.Data.Service;
using erpfake.Model;

namespace erpfake
{
    public partial class Form1 : Form
    {
        public SqlService ServicoSQL = new SqlService();
        public Form1()
        {
            InitializeComponent();
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

        private void InserirButton_Click(object sender, EventArgs e)
        {
            Material NovoMaterial = new Material()
            {
                Codigo = Convert.ToInt32(CodigoTextBox.Text),
                Descricao = DescricaoTextBox.Text,
                Familia = FamiliaComboBox.SelectedText,
                SubFamilia = SubFamiliaComboBox.SelectedText,
                UnidadeDeMedida = UnidadeDeMedidaComboBox.SelectedText
            };

            ServicoSQL.Inserir(NovoMaterial);
        }

        private void SubFamiliaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FamiliaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FamiliaComboBox.SelectedItem != null)
            {
                string familiaSelecionada = FamiliaComboBox.SelectedItem.ToString();

                string[] SubFamilias = ServicoSQL.SubFamiliaComboBoxItens(familiaSelecionada);

                SubFamiliaComboBox.Items.AddRange(SubFamilias);
            }
        }
    }
}
