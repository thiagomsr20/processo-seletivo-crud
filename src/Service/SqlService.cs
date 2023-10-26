﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using erpfake.Model;

namespace erpfake.Data.Service
{
    public class SqlService
    {
        private const string StringDeConexao = @"Data Source=THIAGOPC;integrated security=SSPI;initial catalog=ERPFAKE;";
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
            string Query1 = $"DELETE FROM CODIGO WHERE CODIGO = {ID};";
            string Query2 = $"DELETE FROM MATERIAL WHERE CODIGO = {ID};";

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                cnn.Open();

                SqlCommand cmd1 = new SqlCommand(Query1, cnn);
                SqlCommand cmd2 = new SqlCommand(Query2, cnn);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }

        public Material Pesquisar(int ID)
        {
            Material Material = new Material();
            string Query = $@"SELECT CODIGO, DESCRICAO, FAMILIA, SUBFAMILIA, UNIDADE_DE_MEDIDA FROM MATERIAL
                                WHERE CODIGO = @ID;";

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(Query, cnn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID); // Define o parâmetro @ID com o valor recebido

                    using (SqlDataReader leitor = cmd.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            // Atribui os valores das colunas ao objeto Material
                            Material.Codigo = Convert.ToInt32(leitor["CODIGO"]);
                            Material.Descricao = leitor["DESCRICAO"].ToString();
                            Material.Familia = leitor["FAMILIA"].ToString();
                            Material.SubFamilia = leitor["SUBFAMILIA"].ToString();
                            Material.UnidadeDeMedida = leitor["UNIDADE_DE_MEDIDA"].ToString();
                        }
                    }
                }
            }
            return Material;
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