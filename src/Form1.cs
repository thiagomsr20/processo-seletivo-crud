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
                CodigoMensagemDeErro.Text = string.Empty;
            }
        }

        private void DescricaoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DescricaoTextBox.Text.Length >= 100)
            {
                e.Handled = true;
                DescricaoMensagemDeErro.Text = "Limite de caracteres atingido (100)";
            }
            else
            {
                DescricaoMensagemDeErro.Text = string.Empty;
            }
        }

        private void InserirButton_Click(object sender, EventArgs e)
        {
            bool[] VaidacaoDeCampoVazioOuNulo =
            {
                string.IsNullOrEmpty(DescricaoTextBox.Text),
                FamiliaComboBox.SelectedItem is null,
                SubFamiliaComboBox.SelectedItem is null,
                UnidadeDeMedidaComboBox.SelectedItem is null
            };

            Material MaterialParaCadastro = new Material();
            MaterialParaCadastro.Codigo = CodigoTextBox.Text.Length == 0 ? -1 : Convert.ToInt32(CodigoTextBox.Text);

            if (VaidacaoDeCampoVazioOuNulo.Any(x => x is true))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar um material");
                return;
            }
            else if (MaterialParaCadastro.Codigo == -1)
            {
                MessageBox.Show("Necessário código de material para cadastro");
                return;
            }
            else if (SqlService.MaterialJaCadastrado(MaterialParaCadastro.Codigo))
            {
                MessageBox.Show("Material já cadastrado no banco");
                return;
            }

            MaterialParaCadastro.Descricao = DescricaoTextBox.Text;
            MaterialParaCadastro.Familia = FamiliaComboBox.SelectedItem.ToString();
            MaterialParaCadastro.SubFamilia = SubFamiliaComboBox.SelectedItem.ToString();
            MaterialParaCadastro.UnidadeDeMedida = UnidadeDeMedidaComboBox.SelectedItem.ToString();

            SqlService.Inserir(MaterialParaCadastro);

            UltimoCadastroCodigo.Text = $"Código: {MaterialParaCadastro.Codigo}";
            UltimoCadastroDescricao.Text = $"Descrição: {MaterialParaCadastro.Descricao}";
            UltimoCadastroFamilia.Text= $"Família: {MaterialParaCadastro.Familia}";
            UltimoCadastroSubFamilia.Text = $"Sub família: {MaterialParaCadastro.SubFamilia}";
            UltimoCadastroUnMedida.Text = $"Unidade de medida: {MaterialParaCadastro.UnidadeDeMedida}";

            groupBox2.Visible = true;
            MessageBox.Show("Material cadastrado com sucesso");

            // Limpar configurador de material
            CodigoTextBox.Clear();
            DescricaoTextBox.Clear();
            FamiliaComboBox.SelectedIndex = -1;
            SubFamiliaComboBox.SelectedIndex = -1;
            UnidadeDeMedidaComboBox.SelectedIndex = -1;
        }

        private void PesquisarButton_Click(object sender, EventArgs e)
        {
            int MaterialID = CodigoTextBox.Text.Length == 0 ? -1 : Convert.ToInt32(CodigoTextBox.Text);
            if (MaterialID == -1)
            {
                MessageBox.Show("Necessário o código do material para pesquisa");
                return;
            }

            if (SqlService.MaterialJaCadastrado(MaterialID))
            {
                Material Material = SqlService.Pesquisar(MaterialID);
                DescricaoTextBox.Text = Material.Descricao;
                FamiliaComboBox.SelectedItem = Material.Familia;
                SubFamiliaComboBox.SelectedItem = Material.SubFamilia;
                UnidadeDeMedidaComboBox.SelectedItem = Material.UnidadeDeMedida;
                return;
            }
            MessageBox.Show($"Cadastro: ({MaterialID}) inexistente");
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            int MaterialID = CodigoTextBox.Text.Length == 0 ? -1 : Convert.ToInt32(CodigoTextBox.Text);
            if (MaterialID == -1)
            {
                MessageBox.Show("Necessário o código do material para excluir");
                return;
            }

            else if (SqlService.MaterialJaCadastrado(MaterialID))
            {
                DialogResult AvisoParaDeletarUmCadastro = MessageBox.Show($"Deletar todos os dados do cadastro: {MaterialID} ?", "Aviso!", MessageBoxButtons.YesNo);
                if (AvisoParaDeletarUmCadastro == DialogResult.Yes)
                {
                    SqlService.Deletar(MaterialID);

                    // Limpar configurador de material
                    CodigoTextBox.Clear();
                    DescricaoTextBox.Clear();
                    FamiliaComboBox.SelectedIndex = -1;
                    SubFamiliaComboBox.SelectedIndex = -1;
                    UnidadeDeMedidaComboBox.SelectedIndex = -1;

                    AvisoParaDeletarUmCadastro = MessageBox.Show("Material excluído com sucesso");

                }
                return;
            }

            MessageBox.Show($"Cadastro: ({MaterialID}) inexistente");
        }

        private void AtualizaButton_Click(object sender, EventArgs e)
        {
            int MaterialID = CodigoTextBox.Text.Length == 0 ? -1 : Convert.ToInt32(CodigoTextBox.Text);

            bool[] VaidacaoDeCampoVazioOuNulo =
            {
                string.IsNullOrEmpty(DescricaoTextBox.Text),
                FamiliaComboBox.SelectedItem is null,
                SubFamiliaComboBox.SelectedItem is null,
                UnidadeDeMedidaComboBox.SelectedItem is null
            };

            if (VaidacaoDeCampoVazioOuNulo.Any(x => x is true))
            {
                MessageBox.Show("Preencha todos os campos para cadastrar um material");
                return;
            }
            else if (MaterialID == -1)
            {
                MessageBox.Show("Necessário código do material para atualizar");
                return;
            }
            else if (SqlService.MaterialJaCadastrado(MaterialID))
            {
                Material NovoMaterial = new Material();

                NovoMaterial.Codigo = MaterialID;
                NovoMaterial.Descricao = DescricaoTextBox.Text;
                NovoMaterial.Familia = FamiliaComboBox.SelectedItem.ToString();
                NovoMaterial.SubFamilia = SubFamiliaComboBox.SelectedItem.ToString();
                NovoMaterial.UnidadeDeMedida = UnidadeDeMedidaComboBox.SelectedItem.ToString();

                SqlService.Atualizar(NovoMaterial);

                MessageBox.Show("Material atualizado com sucesso");
            }
            else
            {
                MessageBox.Show($"Cadastro: ({MaterialID}) inexistente");
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
    }
}