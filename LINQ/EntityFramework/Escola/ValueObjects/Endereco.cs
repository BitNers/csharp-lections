using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.EntityFramework.Escola.ValueObjects
{
    internal class Endereco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Complemento { get; set; }
        public uint Numero { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string CEP_Codigo{ get; set; }

        public Endereco(int id, string nome, string complemento, uint numero, string bairro, string cidade, string estado, string cep)
        {
            Id = id;
            Nome = nome;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP_Codigo = cep;
        }
    }
}
