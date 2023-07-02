using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        public Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
