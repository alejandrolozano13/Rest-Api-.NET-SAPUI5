using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoWebPuc
{
    public interface InterfaceCliente
    {
        List<Cliente> obterTodos();

        void adicionarCliente(Cliente cliente);

        void removerCliente(int id);

        void atualizarCliente(Cliente cliente);
    }
}
