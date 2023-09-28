using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projetoWebPuc
{
    public class Cliente
    {
        public Cliente() { }
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
    }
}
