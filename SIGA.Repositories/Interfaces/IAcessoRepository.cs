using SIGA.Lib.Enums;
using SIGA.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Repositories.Interfaces;
public interface IAcessoRepository : IRepository<Acesso>
{
    Task<IEnumerable<Acesso>> GetAllByTipoAcesso(ETipoAcesso tipoAcesso);
}
