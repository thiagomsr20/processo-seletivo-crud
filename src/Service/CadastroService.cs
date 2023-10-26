using erpfake.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erpfake.Cadastro.Service
{
    class CadastroService
    {
        private Form1 Form1Service;
        public CadastroService(Form1 Form1) => Form1Service = Form1;
        private Material Material;

        public bool InformacoesCadastraisValidas()
        {
            Material = new Material();
            bool Validacao = false;

            return false;
        }

    }
}
