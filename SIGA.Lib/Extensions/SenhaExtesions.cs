using SecureIdentity.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Lib.Extensions;
public static class SenhaExtesions
{
    public static string GerarSenha(this string password) => PasswordHasher.Hash(password);
}
