using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Domain.Enums;
public enum ETipoAutenticacaoAcesso : byte
{
    Email = 1,
    SenhaSegura = 2,
    MicrosoftAuthenticator = 3
}
