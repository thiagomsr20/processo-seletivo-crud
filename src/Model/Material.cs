using System;

namespace erpfake.Model
{
    public class Material
    {
        public int Codigo { get; set; }
        private string _descricao = string.Empty;
        public string Descricao
        {
            get{
                return _descricao;
            }
            set{
                if(value.Length > 100)
                {
                    throw new System.ArgumentException("Descricao excedeu limite de caracteres");
                }
                _descricao = value;
            }
        }
        public string Familia { get; set; } = string.Empty;
        public string SubFamilia { get; set; } = string.Empty;
        public string UnidadeDeMedida { get; set; } = string.Empty;
    }
}