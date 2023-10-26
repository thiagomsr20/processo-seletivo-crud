using System;
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
        public SqlService SqlService = new SqlService();
        public Form1()
        {
            InitializeComponent();
            // Inicializar opção no comboBox da Família
            string[] familias = SqlService.FamiliaComboBoxItens();
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

        private void CodigoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back){
                e.Handled = true;
                CodigoMensagemDeErro.Text = "Apenas números inteiros válidos";
            }
            else{
                CodigoMensagemDeErro.Text = "";
            }
        }


        private void InserirButton_Click(object sender, EventArgs e)
        {
            Material MaterialParaCadastro = new Material();
            MaterialParaCadastro.Codigo = CodigoTextBox.Text.Length == 0 ? -1 : Convert.ToInt32(CodigoTextBox.Text);
            if(MaterialParaCadastro.Codigo == -1)
            {
                MessageBox.Show($"Necessário código de material para cadastro");
                return;
            }

            MaterialParaCadastro.Descricao = DescricaoTextBox.Text;
            MaterialParaCadastro.Familia = FamiliaComboBox.SelectedItem.ToString();
            MaterialParaCadastro.SubFamilia = SubFamiliaComboBox.SelectedItem.ToString();
            MaterialParaCadastro.UnidadeDeMedida = UnidadeDeMedidaComboBox.SelectedItem.ToString();

            if (SqlService.MaterialJaCadastrado(MaterialParaCadastro.Codigo))
            {
                MessageBox.Show("Material já cadastrado no banco");
                return;
            }
            SqlService.Inserir(MaterialParaCadastro);
            MessageBox.Show("Material cadastrado com sucesso");
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
