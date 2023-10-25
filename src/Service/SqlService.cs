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
            //if (InvalidoParaInsercaoNoBanco(Obj))
            //{
            //    throw new ArgumentException("Elemento não é válido, cheque atributos nulos");
            //}

            //using (SqlConnection cnn = new SqlConnection(StringDeConexao))
            //{
            //    string Query = $@"INSERT INTO MATERIAL (CODIGO,DESCRICAO,FAMILIA,SUBFAMILIA,UNIDADE_DE_MEDIDA)
            //                        VALUES ('{Obj.Codigo}','{Obj.Descricao}','{Obj.Familia}','{Obj.SubFamilia}','{Obj.UnidadeDeMedida}');";

            //    SqlCommand cmd = new SqlCommand(Query, cnn);
            //    cmd.CommandType = CommandType.Text;

            //    cnn.Open();
            //    cmd.ExecuteNonQuery();
            //}
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
    }
}