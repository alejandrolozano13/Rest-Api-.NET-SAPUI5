using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
namespace ConsoleApp1
{
    public class RepositorioBancoDeDados : InterfaceCliente
    {
        public void adicionarCliente(Cliente novocliente)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123";
            using (var conexao = new SqlConnection(connectionString))
            {
                var sqlInsere = "INSERT INTO ClientePUC (Nome, Data_Nascimento," +
                    " Email, Profissao) VALUES (@NOME, @Data_Nascimento, @Email, @Profissao)";

                var comando = new SqlCommand(sqlInsere, conexao);

                comando.Parameters.Add(new SqlParameter("@NOME", novocliente.Nome));
                comando.Parameters.Add(new SqlParameter("@Data_Nascimento", novocliente.Nascimento));
                comando.Parameters.Add(new SqlParameter("@Email", novocliente.Email));
                comando.Parameters.Add(new SqlParameter("@Profissao", novocliente.Profissao));

                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void atualizarCliente(Cliente cliente)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123";
            using (var conexao = new SqlConnection(connectionString))
            {
                var sql = "UPDATE ClientePUC SET Nome=@Nome, Data_Nascimento=@Data_Nascimento, Email=@Email, Profissao=@Profissao Where @cpf=CPF";
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.Add(new SqlParameter("@cpf", cliente.Cpf));
                comando.Parameters.Add(new SqlParameter("@NOME", cliente.Nome));
                comando.Parameters.Add(new SqlParameter("@Data_Nascimento", cliente.Nascimento));
                comando.Parameters.Add(new SqlParameter("@Email", cliente.Email));
                comando.Parameters.Add(new SqlParameter("@Profissao", cliente.Profissao));

                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente obterPorCpf(int cpf)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123";
            using (var conexao = new SqlConnection(connectionString))
            {
                var sqlObterPorId = "SELECT * FROM ClientePUC WHERE @CPF = CPF";

                var sqlComando = new SqlCommand(sqlObterPorId, conexao);
                sqlComando.Parameters.AddWithValue("@CPF", cpf);

                conexao.Open();
                var leitor = sqlComando.ExecuteReader();
                var clienteCpf = new Cliente();

                while (leitor.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        Cpf = (int)leitor.GetInt64(0),
                        Nome = leitor.GetString(1),
                        Nascimento = leitor.GetDateTime(2),
                        Email = leitor.GetString(3),
                        Profissao = leitor.GetString(4)
                    };
                    clienteCpf = cliente;
                }
                conexao.Close();
                return clienteCpf;
            }
        }

        public List<Cliente> obterTodos()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123";
            using (var conexao = new SqlConnection(connectionString))
            {

                string sql = "Select * from ClientePUC";

                var lista = new List<Cliente>();
                conexao.Open();

                var comando = new SqlCommand(sql, conexao);

                var leitor = comando.ExecuteReader();

                while (leitor.Read())
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
        }

        public void removerCliente(int cpf)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123";
            using (var conexao = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM ClientePUC where @cpf=CPF";

                conexao.Open();
                var comando = new SqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@CPF", cpf);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
