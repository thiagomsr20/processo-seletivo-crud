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
        // Serviçoes para permitirem acesso a atributos de Form1
        private Form1 Form1Service;
        public SqlService(Form1 Form1) => Form1Service = Form1;


        private const string StringDeConexao = @"Data Source=THIAGOPC;integrated security=SSPI;initial catalog=TESTE;";
        private bool InvalidoParaInsercaoNoBanco(Material Obj)
        {
            bool ModeloValido = false;

            List<bool> AtributosNulosNoModelo = new List<bool>() {
                string.IsNullOrEmpty(Obj.Descricao),
                string.IsNullOrEmpty(Obj.Familia),
                string.IsNullOrEmpty(Obj.SubFamilia),
                string.IsNullOrEmpty(Obj.UnidadeDeMedida)
            };

            if (AtributosNulosNoModelo.Any(x => x is true))
            {
                ModeloValido = true;
            }

            return ModeloValido;
        }

        public void Inserir(Material Obj)
        {
            if (InvalidoParaInsercaoNoBanco(Obj))
            {
                throw new ArgumentException("Elemento não é válido, verifique se há atributos nulos");
            }

            using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            {
                // Inserção em ambas tabelas "MATERIAL" e "CODIGO" usando transação, se ocorrer erro na inserção de uma, cancelar a da outra para não haver erro
                string Query = $@"BEGIN TRANSACTION;

                                    BEGIN TRY

                                        INSERT INTO MATERIAL (CODIGO,DESCRICAO,FAMILIA,SUBFAMILIA,UNIDADE_DE_MEDIDA)
                                        VALUES ('{Obj.Codigo}','{Obj.Descricao}','{Obj.Familia}','{Obj.SubFamilia}','{Obj.UnidadeDeMedida}');
    
                                        INSERT INTO CODIGO (CODIGO)
                                        VALUES ('{Obj.Codigo}');
    
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
         
        public void Atualizar(string Query)
        {

        }

        public void Deletar(string Query)
        {

        }

        public void Pesquisar(string Query)
        {

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

        public string[] SubFamiliaComboBoxItens()
        {
            string Query = $@"SELECT * FROM SUBFAMILIA
                            WHERE FAMILIA='{Form1Service.FamiliaComboBoxItens.Selected}'";

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
                            string Subfamilia = leitor["FAMILIA"].ToString();
                            SubFamilias.Add(Subfamilia);
                        }
                    }
                }
            }

            string[] arrayDeFamilias = SubFamilias.ToArray();
            return arrayDeFamilias;
        }
    }
}