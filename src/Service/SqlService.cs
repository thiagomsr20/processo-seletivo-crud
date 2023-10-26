using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using erpfake.Model;

namespace erpfake.Data.Service
{
    public class SqlService
    {
        private const string StringDeConexao = @"Data Source=THIAGOPC;integrated security=SSPI;initial catalog=TESTE;";
        public bool MaterialJaCadastrado(int ID)
        {
            bool MaterialCadastrado = false;
            string Query = $@"SELECT * FROM CODIGO
                            WHERE CODIGO ='{ID}'";

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        if (leitor.HasRows)
                        {
                            MaterialCadastrado = true;
                        }
                    }
                }
            }

            return MaterialCadastrado;
        }

        public void Inserir(Material Obj)
        {
            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                // Inserção em ambas tabelas "MATERIAL" e "CODIGO" usando transação, se ocorrer erro na inserção de uma, cancelar a da outra para não haver erro
                string Query = $@"BEGIN TRANSACTION;

                                    BEGIN TRY

                                        INSERT INTO MATERIAL (CODIGO,DESCRICAO,FAMILIA,SUBFAMILIA,UNIDADE_DE_MEDIDA)
                                        VALUES ('{Obj.Codigo}','{Obj.Descricao}','{Obj.Familia}','{Obj.SubFamilia}','{Obj.UnidadeDeMedida}');
    
                                        INSERT INTO CODIGO (CODIGO, DATADECADASTRO)
                                        VALUES ('{Obj.Codigo}', GETDATE());
    
                                        COMMIT;

                                    END TRY

                                    BEGIN CATCH

                                        ROLLBACK;

                                    END CATCH;";

                SqlCommand cmd = new SqlCommand(Query, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int ID)
        {
            string codigoQuery = $"DELETE FROM CODIGO WHERE codigo = SeuParametro;";
            string materialQuery = $"DELETE FROM MATERIAL WHERE codigo = SeuParametro;";

            // Execute as instruções SQL de exclusão usando sua conexão com o banco de dados.
            using(SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();

                
            }
        }

        public void Pesquisar(int ID)
        {
            string Query = $@"SELECT";
        }

        public string[] FamiliaComboBoxItens()
        {
            string Query = "SELECT FAMILIA FROM FAMILIA";

            List<string> Familias = new List<string>();

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            string familia = leitor["FAMILIA"].ToString();
                            Familias.Add(familia);
                        }
                    }
                }
            }

            string[] arrayDeFamilias = Familias.ToArray();
            return arrayDeFamilias;
        }

        public string[] SubFamiliaComboBoxItens(string Familia)
        {
            string Query = $@"SELECT SUBFAMILIA FROM SUBFAMILIA
                            WHERE FAMILIA='{Familia}'";

            List<string> SubFamilias = new List<string>();

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            string Subfamilia = leitor["SUBFAMILIA"].ToString();
                            SubFamilias.Add(Subfamilia);
                        }
                    }
                }
            }

            string[] ArrayDeSubFamiliasFamilias = SubFamilias.ToArray();
            return ArrayDeSubFamiliasFamilias;
        }
    }
}