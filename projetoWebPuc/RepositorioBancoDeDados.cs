using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoWebPuc
{
    public class RepositorioBancoDeDados : InterfaceCliente
    {
        public void adicionarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void atualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> obterTodos()
        {
            var conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings
                ["ClienteConexao"].ToString());
            
            string sql = "Select * from ClientePUC";

            var lista = new List<Cliente>();
            conexao.Open();

            var comando = new SqlCommand(sql, conexao);

            var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                Cliente cliente = new Cliente()
                {
                    Cpf = (int)leitor.GetInt64(0),
                    Nome = leitor.GetString(1),
                    Nascimento = leitor.GetDateTime(2),
                    Email = leitor.GetString(3),
                    Profissao = leitor.GetString(4)
                };
                lista.Add(cliente);
            }
            conexao.Close();

            return lista;
        }

        public void removerCliente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
